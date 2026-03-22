using AutoMapper;
using System;
using System.Text;
using System.Globalization;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Hangfire;
using Microsoft.Extensions.Logging;

namespace SmartRecruit.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeminiService _geminiService;
        private readonly IWalletRepository _walletRepository;
        private readonly IAILogRepository _aiLogRepository;
        private readonly Hangfire.IBackgroundJobClient _backgroundJobClient;
        private readonly INotificationService _notificationService;
        private readonly ILogger<JobService> _logger;

        public JobService(
            IJobRepository jobRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IGeminiService geminiService, 
            IWalletRepository walletRepository, 
            IAILogRepository aiLogRepository, 
            Hangfire.IBackgroundJobClient backgroundJobClient, 
            INotificationService notificationService,
            ILogger<JobService> logger)
        {
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _geminiService = geminiService;
            _walletRepository = walletRepository;
            _aiLogRepository = aiLogRepository;
            _backgroundJobClient = backgroundJobClient;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<PagedList<JobResponse>> GetJobsByRecruiterAsync(long recruiterId, int page = 1, int pageSize = 10)
        {
            var request = new JobSearchRequest(null, null, null, null, null, null, null, null, page, pageSize, true, true)
            {
                RecruiterId = recruiterId
            };
            return await GetJobsAsync(request);
        }

        public async Task<PagedList<JobResponse>> GetJobsAsync(JobSearchRequest request)
        {
            var jobs = await _jobRepository.GetJobsAsync(request);
            var jobResponses = _mapper.Map<List<JobResponse>>(jobs);
            return new PagedList<JobResponse>(jobResponses, jobs.TotalCount, jobs.CurrentPage, jobs.PageSize);
        }

        public async Task<JobResponse> GetJobByIdAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");

            // Increment ViewCount
            job.ViewCount++;
            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> CreateJobAsync(JobCreateRequest request)
        {
            // 1. Create Job with DRAFT status - No charging, no AI
            var job = new Job
            {
                Title = request.Title,
                Company = request.Company,
                Benefits = request.Benefits,
                Description = request.Description,
                Requirement = request.Requirement,
                SkillsRequired = request.SkillsRequired,
                SalaryMin = request.SalaryMin,
                SalaryMax = request.SalaryMax,
                JobType = request.JobType,
                Location = request.Location,
                CategoryId = request.CategoryId,
                ExpireDate = request.ExpireDate,
                RecruiterId = request.RecruiterId,
                CreatedAt = DateTime.UtcNow,
                Status = JobStatus.DRAFT 
            };

            await _jobRepository.AddAsync(job);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("CreateJob usage: Job {JobId} created as DRAFT. No fees deducted, no AI screening triggered.", job.Id);

            var createdJob = await _jobRepository.GetByIdAsync(job.Id);
            return _mapper.Map<JobResponse>(createdJob!);
        }

        public async Task ModerateJobAsync(long jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) return;

            try
            {
                var screeningResult = await _geminiService.CheckJobContentAsync(job.Title, job.Description);

                var aiLog = new AILog
                {
                    JobId = job.Id,
                    AIType = AIType.SCREENING,
                    InputText = $"Title: {job.Title}\nDescription: {job.Description}",
                    OutputResult = System.Text.Json.JsonSerializer.Serialize(screeningResult),
                    Decision = screeningResult.IsSafe ? "Approved" : "Blocked",
                    Reason = screeningResult.IsSafe ? "No policy violations detected." : $"{screeningResult.ViolationType} - {screeningResult.Analysis}",
                    CreatedAt = DateTime.UtcNow
                };

                await _aiLogRepository.AddAsync(aiLog);

                if (screeningResult.IsSafe)
                {
                    job.Status = JobStatus.APPROVED;
                    job.ModerationNote = "Approved by AI.";
                    _logger.LogInformation("ModerateJob use-case: Job {JobId} APPROVED by AI", jobId);

                    // Real-time Notification for AI Approval
                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            job.RecruiterId,
                            "Job Approved",
                            $"Your job posting '{job.Title}' has been approved by AI and is now public.",
                            NotificationType.JOB,
                            $"/JobDetail?Id={job.Id}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to send AI approval notification for JobId {JobId}", jobId);
                    }
                }
                else
                {
                    job.Status = JobStatus.BLOCKED;
                    job.ModerationNote = $"Blocked by AI: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                    _logger.LogWarning("ModerateJob use-case: Job {JobId} BLOCKED by AI. Reason: {Violations}", jobId, job.ModerationNote);

                    // Real-time Notification for AI Blocking
                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            job.RecruiterId,
                            "Job Blocked",
                            $"Your job posting '{job.Title}' was blocked due to: {screeningResult.ViolationType}. You can appeal this decision.",
                            NotificationType.JOB,
                            $"/JobDetail?Id={job.Id}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to send AI blocking notification for JobId {JobId}", jobId);
                    }
                }
            }
            catch (Exception ex)
            {
                // Check for transient errors to allow Hangfire to retry
                if (ex.Message.Contains("503") || ex.Message.Contains("429") || ex.Message.Contains("The model is overloaded"))
                {
                    _logger.LogWarning(ex, "ModerateJob use-case transient error for JobId {JobId}, retrying...", jobId);
                    throw; // Re-throw to let Hangfire retry with exponential backoff
                }

                // Permanent errors (config missing, validation, etc.) -> Block job
                _logger.LogError(ex, "ModerateJob use-case failed for JobId {JobId}", jobId);
                job.Status = JobStatus.BLOCKED;
                job.ModerationNote = $"AI Check Failed: {ex.Message}";
            }

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<JobResponse> UpdateJobAsync(long id, JobUpdateRequest request, long currentUserId, UserRole currentUserRole)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");

            if (currentUserRole != UserRole.ADMIN && job.RecruiterId != currentUserId)
            {
                throw new UnauthorizedAccessException("You don't have permission to edit this job.");
            }

            // For backward compatibility, this updates the draft if it's a DRAFT/CHECKING job, 
            // or redirects to DraftChanges if it's already APPROVED.
            var draftReq = new JobDraftRequest
            {
                Title = request.Title,
                Company = request.Company,
                Benefits = request.Benefits,
                Description = request.Description,
                Requirement = request.Requirement,
                SkillsRequired = request.SkillsRequired,
                SalaryMin = request.SalaryMin,
                SalaryMax = request.SalaryMax,
                JobType = request.JobType,
                Location = request.Location,
                CategoryId = request.CategoryId,
                ExpireDate = request.ExpireDate
            };

            return await SaveDraftAsync(id, draftReq, currentUserId);
        }

        public async Task<JobResponse> GetJobForEditAsync(long id, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");
            if (job.RecruiterId != userId) throw new UnauthorizedAccessException();

            if (!string.IsNullOrEmpty(job.DraftChanges))
            {
                try
                {
                    var draft = System.Text.Json.JsonSerializer.Deserialize<JobDraftRequest>(job.DraftChanges);
                    if (draft != null)
                    {
                        var response = _mapper.Map<JobResponse>(job);
                        // Merge draft values into response for the UI to show current changes
                        return response with
                        {
                            Title = draft.Title,
                            Company = draft.Company,
                            Benefits = draft.Benefits,
                            Description = draft.Description,
                            Requirement = draft.Requirement,
                            SkillsRequired = draft.SkillsRequired,
                            SalaryMin = draft.SalaryMin,
                            SalaryMax = draft.SalaryMax,
                            JobType = draft.JobType.ToString(),
                            Location = draft.Location,
                            CategoryId = draft.CategoryId,
                            ExpireDate = draft.ExpireDate
                        };
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deserializing DraftChanges for Job {JobId}", id);
                }
            }

            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> SaveDraftAsync(long id, JobDraftRequest request, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");
            if (job.RecruiterId != userId) throw new UnauthorizedAccessException();

            if (job.Status == JobStatus.DRAFT || job.Status == JobStatus.CHECKING || job.Status == JobStatus.BLOCKED)
            {
                // Update main fields directly if not yet live or blocked
                job.Title = request.Title;
                job.Company = request.Company;
                job.Benefits = request.Benefits;
                job.Description = request.Description;
                job.Requirement = request.Requirement;
                job.SkillsRequired = request.SkillsRequired;
                job.SalaryMin = request.SalaryMin;
                job.SalaryMax = request.SalaryMax;
                job.JobType = request.JobType;
                job.Location = request.Location;
                job.CategoryId = request.CategoryId;
                job.ExpireDate = request.ExpireDate;
                job.DraftChanges = null; // Clear any existing draft since we're updating main
            }
            else if (job.Status == JobStatus.APPROVED)
            {
                // Save to JSON for live jobs
                job.DraftChanges = System.Text.Json.JsonSerializer.Serialize(request);
            }

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> PublishJobAsync(long id, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");
            if (job.RecruiterId != userId) throw new UnauthorizedAccessException();

            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) throw new KeyNotFoundException("Wallet not found.");

            // 1. Determine Cost
            decimal cost = (job.Status == JobStatus.APPROVED) ? 25000 : 50000;
            if (wallet.Balance < cost) throw new InvalidOperationException("Insufficient balance to publish.");

            // 2. Charge Wallet
            wallet.Balance -= cost;
            _walletRepository.Update(wallet);

            // 3. Create Transaction Record
            var transaction = new Transaction
            {
                UserId = userId,
                WalletId = wallet.Id,
                Amount = -cost,
                Type = TransactionType.JOB_POST,
                Status = TransactionStatus.SUCCESS,
                Description = $"Publish job: {job.Title}",
                CreatedAt = DateTime.UtcNow
            };
            await _walletRepository.AddTransactionAsync(transaction);

            // 4. Update Status and Enqueue Background Job
            job.Status = JobStatus.CHECKING;
            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            // 5. Notify Transaction Success
            try
            {
                await _notificationService.SendNotificationAsync(
                    userId,
                    "Transaction Success",
                    $"Successfully paid {cost:N0} VNĐ to publish job: {job.Title}.",
                    NotificationType.PAYMENT,
                    "/Wallet");
            }
            catch { /* Ignore notification failures */ }

            // Enqueue the background processing
            BackgroundJob.Enqueue<IJobService>(x => x.ProcessJobPublishingAsync(job.Id, userId));

            return _mapper.Map<JobResponse>(job);
        }

        public async Task ProcessJobPublishingAsync(long jobId, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) return;

            // 1. Content to Screen
            string title = job.Title, desc = job.Description, req = job.Requirement, skills = job.SkillsRequired;
            JobDraftRequest? draft = null;
            if (!string.IsNullOrEmpty(job.DraftChanges))
            {
                draft = System.Text.Json.JsonSerializer.Deserialize<JobDraftRequest>(job.DraftChanges);
                if (draft != null)
                {
                    title = draft.Title;
                    desc = draft.Description;
                    req = draft.Requirement;
                    skills = draft.SkillsRequired;
                }
            }

            // 2. AI Screening
            try
            {
                var combinedContent = $"{desc}\nRequirements: {req}\nSkills: {skills}";
                var screeningResult = await _geminiService.CheckJobContentAsync(title, combinedContent);

                // Logging AI Decision
                var aiLog = new AILog
                {
                    JobId = job.Id,
                    AIType = AIType.SCREENING,
                    InputText = $"Title: {title}\nContent: {combinedContent}",
                    OutputResult = System.Text.Json.JsonSerializer.Serialize(screeningResult),
                    Decision = screeningResult.IsSafe ? "Approved" : "Blocked",
                    Reason = screeningResult.IsSafe ? "Safe" : screeningResult.Analysis,
                    CreatedAt = DateTime.UtcNow
                };
                await _aiLogRepository.AddAsync(aiLog);

                if (screeningResult.IsSafe)
                {
                    // Merge draft changes if they exist
                    if (draft != null)
                    {
                        job.Title = draft.Title;
                        job.Company = draft.Company;
                        job.Benefits = draft.Benefits;
                        job.Description = draft.Description;
                        job.Requirement = draft.Requirement;
                        job.SkillsRequired = draft.SkillsRequired;
                        job.SalaryMin = draft.SalaryMin;
                        job.SalaryMax = draft.SalaryMax;
                        job.JobType = draft.JobType;
                        job.Location = draft.Location;
                        job.CategoryId = draft.CategoryId;
                        job.ExpireDate = draft.ExpireDate;
                        job.DraftChanges = null;
                    }
                    job.Status = JobStatus.APPROVED;
                    job.ModerationNote = "Approved by AI screening.";
                }
                else
                {
                    if (draft != null)
                    {
                        // This was a re-publish of a previously live (APPROVED) job.
                        // The fraudulent draft is rejected, but we KEEP DraftChanges so the recruiter
                        // can still see and fix their draft before re-publishing.
                        // The job remains APPROVED and visible to candidates with the old content.
                        job.Status = JobStatus.APPROVED;
                        job.ModerationNote = $"Edit blocked by AI: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                        // job.DraftChanges is intentionally NOT cleared - recruiter needs to fix their draft
                        _logger.LogWarning("ProcessJobPublishing: Job {JobId} re-publish BLOCKED. Job reverted to APPROVED. DraftChanges preserved for recruiter to fix.", jobId);
                    }
                    else
                    {
                        // Fresh publish that got blocked (was DRAFT or previously BLOCKED).
                        job.Status = JobStatus.BLOCKED;
                        job.ModerationNote = $"Blocked by AI: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                        _logger.LogWarning("ProcessJobPublishing: Fresh publish for Job {JobId} BLOCKED.", jobId);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("503") || ex.Message.Contains("429") || ex.Message.Contains("overloaded"))
                {
                    _logger.LogWarning(ex, "Transient error in ProcessJobPublishingAsync for JobId {JobId}, retrying...", jobId);
                    throw; // Re-throw for Hangfire retry
                }

                _logger.LogError(ex, "Permanent error in ProcessJobPublishingAsync for JobId {JobId}", jobId);
                
                if (job.Status == JobStatus.CHECKING)
                {
                    job.Status = JobStatus.DRAFT;
                }
                job.ModerationNote = $"AI Screening failed: {ex.Message}. Please try again.";
            }

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            // 3. Notify Recruiter
            try
            {
                string notifTitle, notifBody;
                if (job.Status == JobStatus.APPROVED && job.ModerationNote?.StartsWith("Edit blocked") == true)
                {
                    // Re-publish blocked, job still live
                    notifTitle = "Chỉnh sửa Job bị từ chối";
                    notifBody = $"Nội dung chỉnh sửa của job '{job.Title}' vi phạm chính sách và đã bị từ chối. Job của bạn vẫn đang hoạt động bình thường với nội dung cũ.";
                }
                else if (job.Status == JobStatus.APPROVED)
                {
                    notifTitle = "Phát hành Job thành công";
                    notifBody = $"Công việc '{job.Title}' đã được duyệt và đăng tải.";
                }
                else
                {
                    notifTitle = "Job bị từ chối";
                    notifBody = $"Công việc '{job.Title}' không vượt qua kiểm duyệt AI.";
                }

                await _notificationService.SendNotificationAsync(
                    userId,
                    notifTitle,
                    notifBody,
                    NotificationType.JOB,
                    $"/JobDetail?id={job.Id}");
            }
            catch { /* Ignore notification failures */ }
        }

        public async Task<bool> DeleteJobAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) return false;

            _jobRepository.Delete(job);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> ToggleVisibilityAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Job not found");

            bool isVisible = job.Status != JobStatus.HIDDEN; // Current state
            await _jobRepository.UpdateVisibilityAsync(id, !isVisible); // Toggle
            return !isVisible;
        }

        public async Task<bool> BoostJobAsync(long jobId, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

            // 1. Validation
            if (job.IsAppealed)
            {
                throw new InvalidOperationException("Cannot boost an appealed job.");
            }

            if (job.RecruiterId != userId)
            {
                throw new UnauthorizedAccessException("You can only boost your own jobs.");
            }

            // 2. Wallet & Balance Check
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) throw new KeyNotFoundException("Wallet not found for user.");

            const decimal boostCost = 20000;
            if (wallet.Balance < boostCost)
            {
                throw new InvalidOperationException("Insufficient balance to boost job.");
            }

            // 3. Process Payment
            wallet.Balance -= boostCost;
            _walletRepository.Update(wallet);

            // 4. Update Job Boost Time
            job.BoostExpiryTime = DateTime.UtcNow.AddMinutes(20);
            _jobRepository.Update(job);

            // 5. Create Transaction
            var transaction = new Transaction
            {
                UserId = userId,
                WalletId = wallet.Id,
                Amount = -boostCost,
                Type = TransactionType.BOOST,
                Status = TransactionStatus.SUCCESS,
                Description = $"Boost job {job.Id}: {job.Title}",
                CreatedAt = DateTime.UtcNow
            };
            await _walletRepository.AddTransactionAsync(transaction);

            // 6. Complete Unit of Work
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                _logger.LogInformation("BoostJob use-case success: Job {JobId} successfully boosted by User {UserId}", jobId, userId);
                
                // Push Notification for Payment Transparency
                try
                {
                    await _notificationService.SendNotificationAsync(
                        userId,
                        "Transaction Success",
                        $"Successfully paid {boostCost:N0} VNĐ to boost job: {job.Title}.",
                        NotificationType.PAYMENT,
                        "/Wallet");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send job boost fee notification for User {UserId}", userId);
                }
            }
            return result;
        }

        public async Task<IEnumerable<string>> GetLocationsAsync()
        {
            var rawLocations = await _jobRepository.GetLocationsAsync();
            
            // Clean & Normalize: "Hà Nội" vs "ha noi" or "HÀ NỘI"
            // We'll use a dictionary to keep track of the "pretty" version while deduplicating by normalized key
            var uniqueLocations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var loc in rawLocations)
            {
                var normalized = NormalizeString(loc);
                if (!uniqueLocations.ContainsKey(normalized))
                {
                    uniqueLocations[normalized] = loc; // Keep the first original one encountered
                }
            }

            return uniqueLocations.Values
                .OrderBy(x => x, StringComparer.CurrentCultureIgnoreCase)
                .ToList();
        }

        public async Task<IEnumerable<string>> GetTopLocationsAsync(int count)
        {
            return await _jobRepository.GetTopLocationsAsync(count);
        }

        public async Task<bool> AppealJobAsync(long jobId, string message)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

            job.IsAppealed = true;
            job.AppealMessage = message;
            
            _jobRepository.Update(job);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<PagedList<AppealResponse>> GetAppealedJobsAsync(int page, int pageSize)
        {
            // Use the repository method that includes the Recruiter
            var pagedJobs = await _jobRepository.GetAppealedJobsAsync(page, pageSize);

            var responses = new List<AppealResponse>();
            foreach (var job in pagedJobs)
            {
                var aiLog = (await _aiLogRepository.GetAILogsAsync(new DTO.AILog.AILogRequest { JobId = job.Id }))
                    .OrderByDescending(l => l.CreatedAt)
                    .FirstOrDefault();

                responses.Add(new AppealResponse
                {
                    JobId = job.Id,
                    JobTitle = job.Title,
                    RecruiterId = job.RecruiterId,
                    RecruiterName = job.Recruiter?.FullName ?? "Unknown",
                    AppealMessage = job.AppealMessage ?? string.Empty,
                    AILogReason = aiLog?.Reason,
                    CreatedAt = job.CreatedAt
                });
            }

            return new PagedList<AppealResponse>(responses, pagedJobs.TotalCount, page, pageSize);
        }

        public async Task<bool> OverrideAIAsync(long jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

            job.Status = JobStatus.APPROVED;
            job.IsAppealed = false; // Reset appeal state
            job.ModerationNote = $"Directly approved by Admin on {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";

            _jobRepository.Update(job);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                // Real-time Notification for Admin Override
                try
                {
                    await _notificationService.SendNotificationAsync(
                        job.RecruiterId,
                        "Job Approved by Admin",
                        $"Good news! Your appeal for '{job.Title}' was successful. The job is now live.",
                        NotificationType.JOB,
                        $"/JobDetail?id={job.Id}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send admin override notification for JobId {JobId}", jobId);
                }
            }
            return result;
        }

        public async Task<bool> RejectAppealAsync(long jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

            job.IsAppealed = false;
            job.ModerationNote = $"Appeal Rejected by Admin on {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";

            _jobRepository.Update(job);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                // Real-time Notification for Appeal Rejection
                try
                {
                    await _notificationService.SendNotificationAsync(
                        job.RecruiterId,
                        "Appeal Rejected",
                        $"Your appeal for '{job.Title}' was reviewed by Admin and the AI decision was upheld.",
                        NotificationType.JOB,
                        $"/JobDetail?id={job.Id}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send appeal rejection notification for JobId {JobId}", jobId);
                }
            }
            return result;
        }

        public async Task<RecruiterStatsResponse> GetRecruiterStatsAsync(long recruiterId)
        {
            return await _jobRepository.GetRecruiterStatsAsync(recruiterId);
        }

        public async Task<IEnumerable<JobResponse>> GetRecommendedJobsAsync(long userId)
        {
            var recommendedJobs = await _jobRepository.GetRecommendedJobsAsync(userId);
            return _mapper.Map<IEnumerable<JobResponse>>(recommendedJobs);
        }

        private string NormalizeString(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC).ToLowerInvariant().Trim();
        }
    }
}
