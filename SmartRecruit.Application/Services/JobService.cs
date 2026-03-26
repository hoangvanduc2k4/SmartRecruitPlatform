
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
using SmartRecruit.Domain.Constants;
using SmartRecruit.Domain.Exceptions;
using Microsoft.Extensions.Logging;

using FluentValidation;

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
        private readonly IValidator<JobCreateRequest> _createValidator;
        private readonly IValidator<JobUpdateRequest> _updateValidator;
        private readonly IValidator<JobDraftRequest> _draftValidator;

        public JobService(
            IJobRepository jobRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeminiService geminiService,
            IWalletRepository walletRepository,
            IAILogRepository aiLogRepository,
            Hangfire.IBackgroundJobClient backgroundJobClient,
            INotificationService notificationService,
            ILogger<JobService> logger,
            IValidator<JobCreateRequest> createValidator,
            IValidator<JobUpdateRequest> updateValidator,
            IValidator<JobDraftRequest> draftValidator)
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
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _draftValidator = draftValidator;
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
            if (job == null || job.IsDeleted) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

            // Increment ViewCount only if NOT deleted
            job.ViewCount++;
            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<JobResponse>(job);
        }

        public async Task<JobResponse> CreateJobAsync(JobCreateRequest request)
        {
            await _createValidator.ValidateAndThrowAsync(request);

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
                CategoryId = request.CategoryId!.Value,
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
                var fullContent = GetFullJobInfo(
                    job.Title, 
                    job.Company, 
                    job.Location, 
                    job.JobType.ToString(), 
                    job.SalaryMin, 
                    job.SalaryMax, 
                    job.Benefits, 
                    job.Description, 
                    job.Requirement, 
                    job.SkillsRequired);

                var screeningResult = await _geminiService.CheckJobContentAsync(job.Title, fullContent);

                var aiLog = new AILog
                {
                    JobId = job.Id,
                    AIType = AIType.SCREENING,
                    InputText = fullContent,
                    OutputResult = System.Text.Json.JsonSerializer.Serialize(screeningResult),
                    Decision = screeningResult.IsSafe ? "Approved" : "Blocked",
                    Reason = screeningResult.IsSafe ? "Không phát hiện vi phạm chính sách." : $"{screeningResult.ViolationType} - {screeningResult.Analysis}",
                    CreatedAt = DateTime.UtcNow
                };

                await _aiLogRepository.AddAsync(aiLog);

                if (screeningResult.IsSafe)
                {
                    job.Status = JobStatus.APPROVED;
                    job.ModerationNote = Messages.AiMsg.APPROVED_BY_AI;
                    _logger.LogInformation("ModerateJob use-case: Job {JobId} APPROVED by AI", jobId);

                    // Real-time Notification for AI Approval
                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            job.RecruiterId,
                            Messages.NotificationMsg.JOB_APPROVED_TITLE,
                            string.Format(Messages.NotificationMsg.JOB_APPROVED_CONTENT, job.Title),
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
                    job.ModerationNote = $"Bị AI chặn: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                    _logger.LogWarning("ModerateJob use-case: Job {JobId} BLOCKED by AI. Reason: {Violations}", jobId, job.ModerationNote);

                    // Real-time Notification for AI Blocking
                    try
                    {
                        await _notificationService.SendNotificationAsync(
                            job.RecruiterId,
                            Messages.NotificationMsg.JOB_BLOCKED_TITLE,
                            string.Format(Messages.NotificationMsg.JOB_BLOCKED_CONTENT, job.Title, screeningResult.ViolationType),
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
                job.ModerationNote = $"Kiểm tra AI thất bại: {ex.Message}";
            }

            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<JobResponse> UpdateJobAsync(long id, JobUpdateRequest request, long currentUserId, UserRole userRole)
        {
            await _updateValidator.ValidateAndThrowAsync(request);

            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new KeyNotFoundException("Không tìm thấy công việc");

            if (userRole != UserRole.ADMIN && job.RecruiterId != currentUserId)
            {
                throw new UnauthorizedException(Messages.JobMsg.NOT_OWNER);
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
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);
            if (job.RecruiterId != userId) throw new UnauthorizedException(Messages.JobMsg.NOT_OWNER);

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
            await _draftValidator.ValidateAndThrowAsync(request);
            
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);
            if (job.RecruiterId != userId) throw new UnauthorizedException(Messages.JobMsg.NOT_OWNER);

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
                job.CategoryId = request.CategoryId ?? job.CategoryId;
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
            if (job == null) throw new KeyNotFoundException("Không tìm thấy công việc");
            if (job.RecruiterId != userId) throw new UnauthorizedAccessException();

            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) throw new NotFoundException(Messages.WalletMsg.NOT_FOUND);

            // 1. Determine Cost
            decimal cost = (job.Status == JobStatus.APPROVED) ? 25000 : 50000;
            if (wallet.Balance < cost) throw new BadRequestException(Messages.WalletMsg.INSUFFICIENT_FUNDS);

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
                Description = string.Format(Messages.JobMsg.POST_JOB_DESC, job.Title),
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
                    Messages.NotificationMsg.PAYMENT_SUCCESS_TITLE,
                    string.Format(Messages.NotificationMsg.PAYMENT_SUCCESS_CONTENT, cost, job.Title),
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
            JobDraftRequest? draft = null;
            if (!string.IsNullOrEmpty(job.DraftChanges))
            {
                draft = System.Text.Json.JsonSerializer.Deserialize<JobDraftRequest>(job.DraftChanges);
            }

            // 2. AI Screening
            try
            {
                string fullContent = "";
                if (draft != null)
                {
                    fullContent = GetFullJobInfo(
                        draft.Title,
                        draft.Company,
                        draft.Location,
                        draft.JobType.ToString(),
                        draft.SalaryMin,
                        draft.SalaryMax,
                        draft.Benefits,
                        draft.Description,
                        draft.Requirement,
                        draft.SkillsRequired);
                }
                else
                {
                    fullContent = GetFullJobInfo(
                        job.Title,
                        job.Company,
                        job.Location,
                        job.JobType.ToString(),
                        job.SalaryMin,
                        job.SalaryMax,
                        job.Benefits,
                        job.Description,
                        job.Requirement,
                        job.SkillsRequired);
                }

                var screeningResult = await _geminiService.CheckJobContentAsync(draft?.Title ?? job.Title, fullContent);

                // Logging AI Decision
                var aiLog = new AILog
                {
                    JobId = job.Id,
                    AIType = AIType.SCREENING,
                    InputText = fullContent,
                    OutputResult = System.Text.Json.JsonSerializer.Serialize(screeningResult),
                    Decision = screeningResult.IsSafe ? "Approved" : "Blocked",
                    Reason = screeningResult.IsSafe ? "An toàn" : screeningResult.Analysis,
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
                        job.CategoryId = draft.CategoryId ?? job.CategoryId;
                        job.ExpireDate = draft.ExpireDate;
                        job.DraftChanges = null;
                    }
                    job.Status = JobStatus.APPROVED;
                    job.ModerationNote = "Đã được duyệt bởi AI.";
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
                        job.ModerationNote = $"Chỉnh sửa bị chặn bởi AI: {screeningResult.ViolationType} - {screeningResult.Analysis}";
                        // job.DraftChanges is intentionally NOT cleared - recruiter needs to fix their draft
                        _logger.LogWarning("ProcessJobPublishing: Job {JobId} re-publish BLOCKED. Job reverted to APPROVED. DraftChanges preserved for recruiter to fix.", jobId);
                    }
                    else
                    {
                        // Fresh publish that got blocked (was DRAFT or previously BLOCKED).
                        job.Status = JobStatus.BLOCKED;
                        job.ModerationNote = $"Bị AI chặn: {screeningResult.ViolationType} - {screeningResult.Analysis}";
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
                job.ModerationNote = $"Kiểm duyệt AI thất bại: {ex.Message}. Vui lòng thử lại.";
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
                    notifTitle = Messages.NotificationMsg.JOB_EDIT_REJECTED_TITLE;
                    notifBody = string.Format(Messages.NotificationMsg.JOB_EDIT_REJECTED_CONTENT, job.Title);
                }
                else if (job.Status == JobStatus.APPROVED)
                {
                    notifTitle = Messages.NotificationMsg.JOB_PUBLISHED_TITLE;
                    notifBody = string.Format(Messages.NotificationMsg.JOB_PUBLISHED_CONTENT, job.Title);
                }
                else
                {
                    notifTitle = Messages.NotificationMsg.JOB_REJECTED_TITLE;
                    notifBody = string.Format(Messages.NotificationMsg.JOB_REJECTED_CONTENT, job.Title);
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
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

            job.IsDeleted = true;
            _jobRepository.Update(job);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> ToggleVisibilityAsync(long id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

            bool isVisible = job.Status != JobStatus.HIDDEN; // Current state
            await _jobRepository.UpdateVisibilityAsync(id, !isVisible); // Toggle
            return !isVisible;
        }

        public async Task<bool> BoostJobAsync(long jobId, long userId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            if (job == null) throw new KeyNotFoundException("Không tìm thấy công việc");

            // 1. Validation
            if (job.IsAppealed)
            {
                throw new BadRequestException(Messages.JobMsg.JOB_UNDER_APPEAL);
            }

            if (job.RecruiterId != userId)
            {
                throw new UnauthorizedException(Messages.JobMsg.NOT_OWNER);
            }

            // 2. Wallet & Balance Check
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) throw new NotFoundException(Messages.WalletMsg.NOT_FOUND);

            const decimal boostCost = 20000;
            if (wallet.Balance < boostCost)
            {
                throw new BadRequestException(Messages.WalletMsg.INSUFFICIENT_FUNDS);
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
                Description = string.Format(Messages.JobMsg.BOOST_JOB_DESC, job.Id, job.Title),
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
                        Messages.NotificationMsg.PAYMENT_SUCCESS_TITLE,
                        string.Format(Messages.NotificationMsg.PAYMENT_SUCCESS_CONTENT, boostCost, job.Title),
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
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

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
                    RecruiterName = job.Recruiter?.FullName ?? "Không xác định",
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
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

            job.Status = JobStatus.APPROVED;
            job.IsAppealed = false; // Reset appeal state
            job.ModerationNote = $"Được quản trị viên duyệt trực tiếp vào lúc {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";

            _jobRepository.Update(job);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                // Real-time Notification for Admin Override
                try
                {
                    await _notificationService.SendNotificationAsync(
                        job.RecruiterId,
                        "Công việc đã được Admin duyệt",
                        $"Tin tốt! Khiếu nại của bạn cho '{job.Title}' đã thành công. Công việc hiện đã được hiển thị.",
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
            if (job == null) throw new NotFoundException(Messages.JobMsg.JOB_NOT_FOUND);

            job.IsAppealed = false;
            job.ModerationNote = $"Khiếu nại bị Admin từ chối vào lúc {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";

            _jobRepository.Update(job);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                // Real-time Notification for Appeal Rejection
                try
                {
                    await _notificationService.SendNotificationAsync(
                        job.RecruiterId,
                        "Khiếu nại bị từ chối",
                        $"Khiếu nại của bạn cho '{job.Title}' đã được Admin xem xét và quyết định của AI được giữ nguyên.",
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

        public async Task UpdateExpiredJobsAsync()
        {
            _logger.LogInformation("Hangfire Job: Checking for expired or expiring soon job postings...");

            var now = DateTime.UtcNow;
            var threeDaysFromNow = now.AddDays(3);

            // 1. Tìm các Job đã hết hạn (ExpireDate < now)
            var expiredJobs = await _jobRepository.FindAllAsync(j =>
                (j.Status == JobStatus.APPROVED || j.Status == JobStatus.EXPIRING_SOON || j.Status == JobStatus.CHECKING) &&
                j.ExpireDate.HasValue &&
                j.ExpireDate.Value < now &&
                !j.IsDeleted);

            foreach (var job in expiredJobs)
            {
                job.Status = JobStatus.EXPIRED;
                job.ModerationNote = $"Tự động đóng do hết hạn vào lúc {now:yyyy-MM-dd HH:mm:ss}";
                _jobRepository.Update(job);
                
                // Gửi thông báo hết hạn
                await _notificationService.SendNotificationAsync(
                    job.RecruiterId,
                    "Công việc đã hết hạn",
                    $"Bài đăng '{job.Title}' của bạn đã hết hạn và không còn hiển thị công khai.",
                    NotificationType.JOB,
                    $"/JobDetail?Id={job.Id}");
            }

            // 2. Tìm các Job sắp hết hạn (Bên dưới 3 ngày và đang APPROVED)
            var expiringSoonJobs = await _jobRepository.FindAllAsync(j =>
                j.Status == JobStatus.APPROVED &&
                j.ExpireDate.HasValue &&
                j.ExpireDate.Value <= threeDaysFromNow &&
                j.ExpireDate.Value >= now &&
                !j.IsDeleted);

            foreach (var job in expiringSoonJobs)
            {
                job.Status = JobStatus.EXPIRING_SOON;
                _jobRepository.Update(job);

                // Gửi thông báo sắp hết hạn
                await _notificationService.SendNotificationAsync(
                    job.RecruiterId,
                    "Công việc sắp hết hạn",
                    $"Bài đăng '{job.Title}' của bạn sẽ hết hạn trong vòng chưa đầy 3 ngày nữa ({job.ExpireDate:dd/MM/yyyy}).",
                    NotificationType.JOB,
                    $"/JobDetail?Id={job.Id}");
            }

            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("Hangfire Job: Finished processing job statuses.");
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

        private string GetFullJobInfo(string title, string company, string location, string jobType, decimal salaryMin, decimal salaryMax, string benefits, string description, string requirements, string skills)
        {
            return $@"Job Title: {title}
Company: {company}
Location: {location}
Job Type: {jobType}
Salary Range: {salaryMin:N0} - {salaryMax:N0} VNĐ
Benefits: {benefits}
Description: {description}
Requirements: {requirements}
Skills Required: {skills}";
        }
    }
}
