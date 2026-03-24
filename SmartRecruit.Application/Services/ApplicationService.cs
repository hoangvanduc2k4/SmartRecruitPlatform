using AutoMapper;
using Hangfire;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

namespace SmartRecruit.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGeminiService _geminiService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly INotificationService _notificationService;
        private readonly INotificationHubService _notificationHubService;
        private readonly IEmailService _emailService;
        private readonly IJobRepository _jobRepository;
        private readonly IExcelService _excelService;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeminiService geminiService,
            IBackgroundJobClient backgroundJobClient,
            INotificationService notificationService,
            INotificationHubService notificationHubService,
            IEmailService emailService,
            IJobRepository jobRepository,
            IExcelService excelService,
            ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _geminiService = geminiService;
            _backgroundJobClient = backgroundJobClient;
            _notificationService = notificationService;
            _notificationHubService = notificationHubService;
            _emailService = emailService;
            _jobRepository = jobRepository;
            _excelService = excelService;
            _logger = logger;
        }

        public async Task<PagedList<ApplicationResponse>> GetApplicationsAsync(ApplicationSearchRequest request)
        {
            _logger.LogInformation("Executing GetApplications use-case with search request: {@Request}", request);
            var applications = await _applicationRepository.GetApplicationsAsync(request);
            var dtos = _mapper.Map<List<ApplicationResponse>>(applications);
            return new PagedList<ApplicationResponse>(dtos, applications.TotalCount, applications.CurrentPage, applications.PageSize);
        }

        public async Task<PagedList<ApplicationResponse>> GetApplicationsByCandidateAsync(long candidateId, int page = 1, int pageSize = 10)
        {
            var request = new ApplicationSearchRequest(
                CandidateId: candidateId, 
                JobId: null, 
                RecruiterId: null, 
                Status: null, 
                Page: page, 
                PageSize: pageSize);
            return await GetApplicationsAsync(request);
        }

        public async Task<PagedList<ApplicationResponse>> GetApplicationsByJobAsync(long jobId, int page = 1, int pageSize = 10, bool sortByScore = false)
        {
            var request = new ApplicationSearchRequest(
                CandidateId: null, 
                JobId: jobId, 
                RecruiterId: null, 
                Status: null, 
                Page: page, 
                PageSize: pageSize, 
                SortByScore: sortByScore);
            return await GetApplicationsAsync(request);
        }

        public async Task<ApplicationResponse> GetApplicationByIdAsync(long id)
        {
            // ĐỔI THÀNH: Gọi hàm có Details để lấy đủ dữ liệu từ các bảng liên quan
            var application = await _applicationRepository.GetApplicationWithDetailsAsync(id);

            if (application == null) throw new KeyNotFoundException("Application not found");

            return _mapper.Map<ApplicationResponse>(application);
        }

        public async Task<bool> ApplyJobAsync(ApplyJobRequest request)
        {
            _logger.LogInformation("Executing ApplyJob use-case for JobId: {JobId} by CandidateId: {CandidateId}", request.JobId, request.CandidateId);
            
            // 1. Kiểm tra xem đã apply chưa
            bool alreadyApplied = await _applicationRepository.IsAlreadyAppliedAsync(request.JobId, request.CandidateId);
            if (alreadyApplied)
            {
                _logger.LogWarning("ApplyJob use-case failed: Candidate {CandidateId} has already applied for Job {JobId}", request.CandidateId, request.JobId);
                throw new InvalidOperationException("You have already applied for this job.");
            }

            // 2. Kiểm tra xem candidate đã có CVText chưa
            var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == request.CandidateId);
            if (candidateProfile == null || string.IsNullOrWhiteSpace(candidateProfile.CVText))
            {
                _logger.LogWarning("ApplyJob use-case failed: Candidate {CandidateId} has not uploaded a CV", request.CandidateId);
                throw new InvalidOperationException("Please upload your CV in your profile before applying.");
            }

            // 3. Tạo bản ghi đơn giản
            var application = new Applications
            {
                JobId = request.JobId,
                CandidateId = request.CandidateId,
                Status = ApplicationStatus.REVIEWING,
                CreatedAt = DateTime.UtcNow
            };

            await _applicationRepository.AddAsync(application);
            await _unitOfWork.CompleteAsync();

            // 3. Đẩy vào Hangfire để AI xử lý ngầm (Bất đồng bộ)
            _backgroundJobClient.Enqueue<IApplicationService>(x => x.ScoreApplicationAsync(application.Id));
            _logger.LogInformation("ApplyJob use-case success: Application {ApplicationId} created and enqueued for AI scoring", application.Id);

            // 4. Real-time Notification for Recruiter
            try
            {
                var appWithDetails = await _applicationRepository.GetApplicationWithDetailsAsync(application.Id);
                if (appWithDetails != null && appWithDetails.Job != null)
                {
                    string candidateName = appWithDetails.Candidate?.FullName ?? "A candidate";
                    await _notificationService.SendNotificationAsync(
                        appWithDetails.Job.RecruiterId,
                        "New Application",
                        $"{candidateName} has applied for your job: {appWithDetails.Job.Title}",
                        NotificationType.APPLICATION,
                        $"/JobDetail?Id={appWithDetails.Job.Id}");

                    // 4b. Real-time Notification for Candidate (Confirmation)
                    await _notificationService.SendNotificationAsync(
                        request.CandidateId,
                        "Application Submitted",
                        $"You have successfully applied for: {appWithDetails.Job.Title}. Good luck!",
                        NotificationType.APPLICATION,
                        $"/JobDetail?Id={appWithDetails.Job.Id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send 'New Application' notification for ApplicationId {ApplicationId}", application.Id);
            }

            return true; // Chỉ cần trả về thành công
        }

        public async Task ScoreApplicationAsync(long applicationId)
        {
            var application = await _applicationRepository.GetApplicationWithDetailsAsync(applicationId);
            if (application == null) return;

            try
            {
                var cvContent = application.Candidate?.CandidateProfile?.CVText ?? string.Empty;
                var jobDescription = $"{application.Job?.Description}\nRequirements: {application.Job?.Requirement}\nSkills: {application.Job?.SkillsRequired}";

                var result = await _geminiService.ScoreCvAsync(cvContent, jobDescription);

                application.MatchScore = result.MatchScore;
                application.SkillMatch = result.SkillMatch;
                application.ExperienceMatch = result.ExperienceMatch;
                application.AI_Summary = result.AISummary;
            }
            catch (Exception ex)
            {
                // Allow Hangfire to retry on transient errors
                if (ex.Message.Contains("503") || ex.Message.Contains("429") || ex.Message.Contains("overloaded"))
                {
                    _logger.LogWarning(ex, "Transient error during ScoreApplication use-case for ApplicationId {ApplicationId}, retrying...", applicationId);
                    throw;
                }

                _logger.LogError(ex, "ScoreApplication use-case failed for ApplicationId {ApplicationId}", applicationId);
                application.AI_Summary = $"AI Scoring Failed: {ex.Message}";
            }

            _applicationRepository.Update(application);
            await _unitOfWork.CompleteAsync();

            try
            {
                var updateDto = new SmartRecruit.Application.DTO.Application.ApplicationScoreUpdateDto
                {
                    ApplicationId = applicationId,
                    JobId = application.JobId,
                    MatchScore = application.MatchScore,
                    SkillMatch = application.SkillMatch,
                    ExperienceMatch = application.ExperienceMatch,
                    AISummary = application.AI_Summary
                };
                
                // Notify Candidate
                await _notificationHubService.SendApplicationScoreUpdateAsync(application.CandidateId, updateDto);
                
                // Notify Recruiter
                if (application.Job != null)
                {
                    await _notificationHubService.SendApplicationScoreUpdateAsync(application.Job.RecruiterId, updateDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send real-time score update for ApplicationId {ApplicationId}", applicationId);
            }
        }

        public async Task<bool> UpdateStatusAsync(long id, UpdateApplicationStatusRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) throw new KeyNotFoundException("Application not found.");

            var currentStatus = application.Status;
            var newStatus = request.Status;

            // 1. Quy tắc chuyển đổi (Pipeline)
            if (newStatus != ApplicationStatus.REJECTED)
            {
                // Chỉ được tiến tới bước kế tiếp (Reviewing(0) -> Interviewing(1) -> Offered(2))
                if ((int)newStatus != (int)currentStatus + 1)
                {
                    throw new InvalidOperationException($"Invalid status transition from {currentStatus} to {newStatus}. You can only move to the next logical step.");
                }
            }
            // Rejected có thể chuyển từ bất kỳ đâu, trừ khi đã là Rejected
            else if (currentStatus == ApplicationStatus.REJECTED)
            {
                throw new InvalidOperationException("Application is already rejected.");
            }

            // 2. Ràng buộc dữ liệu & Tận dụng cột Notes
            if (newStatus == ApplicationStatus.INTERVIEWING)
            {
                if (!request.InterviewDate.HasValue)
                {
                    throw new InvalidOperationException("Interview date is required when moving to Interviewing status.");
                }
                if (!string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("Rejection reason should not be provided when moving to Interviewing status.");
                }
                
            }
            else if (newStatus == ApplicationStatus.REJECTED)
            {
                if (string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("Rejection reason is required when rejecting an application.");
                }
                if (request.InterviewDate.HasValue)
                {
                    throw new InvalidOperationException("Interview date should not be provided when rejecting an application.");
                }
                
            }
            else
            {
                // Đối với các trạng thái khác (Reviewing, Offered), nếu người dùng cố tình truyền data thì báo lỗi để họ xóa đi cho sạch
                if (request.InterviewDate.HasValue || !string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("InterviewDate or RejectionReason are not required for this status. Please clear them.");
                }
            }


            // Append History to Notes
            string newNote = "";
            if (newStatus == ApplicationStatus.INTERVIEWING)
            {
                newNote = $"Interview: {request.InterviewDate!.Value.ToString("yyyy-MM-dd HH:mm")}";
            }
            else if (newStatus == ApplicationStatus.OFFERED)
            {
                newNote = $"Offered: {DateTime.Now:yyyy-MM-dd HH:mm}";
            }
            else if (newStatus == ApplicationStatus.REJECTED)
            {
                newNote = $"Rejected: {request.RejectionReason}";
            }

            // ONLY append if something actually changed (new status or new interview date)
            bool dataChanged = application.Status != newStatus || 
                              (newStatus == ApplicationStatus.INTERVIEWING && application.Notes?.Contains(newNote) == false);

            if (!string.IsNullOrEmpty(newNote) && dataChanged)
            {
                var cleanNote = newNote.Replace(",", ";");
                application.Notes = string.IsNullOrEmpty(application.Notes) ? cleanNote : $"{application.Notes}, {cleanNote}";
            }

            application.Status = newStatus;
            application.UpdatedAt = DateTime.UtcNow;

            _applicationRepository.Update(application);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result)
            {
                _logger.LogInformation("UpdateStatus use-case successful for ApplicationId {ApplicationId} to {Status}", id, newStatus);
                
                // Real-time Notification
                try
                {
                    var appWithDetails = await _applicationRepository.GetApplicationWithDetailsAsync(id);
                    if (appWithDetails != null)
                    {
                        string jobTitle = appWithDetails.Job?.Title ?? "your application";
                        string statusText = newStatus.ToString().Replace("_", " ").ToLower();
                        string message = $"Your application for '{jobTitle}' has been updated to: {statusText}.";
                        
                        if (newStatus == ApplicationStatus.INTERVIEWING)
                            message = $"Congratulations! You've been invited for an interview for '{jobTitle}'. Check your email for details.";
                        else if (newStatus == ApplicationStatus.OFFERED)
                            message = $"Great news! You received a job offer for '{jobTitle}'. Congratulations!";

                        await _notificationService.SendNotificationAsync(
                            appWithDetails.CandidateId,
                            "Application Update",
                            message,
                            NotificationType.APPLICATION,
                            "/JobApplications"); // Candidate views their apps here
                            
                        // Real-time UI Update (SignalR)
                        try 
                        {
                            await _notificationHubService.SendApplicationStatusUpdateAsync(application.CandidateId, new SmartRecruit.Application.DTO.Application.ApplicationStatusUpdateDto
                            {
                                ApplicationId = id,
                                Status = newStatus.ToString(),
                                JobTitle = jobTitle,
                                UpdatedAt = application.UpdatedAt.GetValueOrDefault(DateTime.UtcNow)
                            });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning(ex, "Failed to send SignalR status update for ApplicationId {ApplicationId}", id);
                        }

                        // Send Email Notification
                        if (appWithDetails.Candidate != null && !string.IsNullOrEmpty(appWithDetails.Candidate.Email))
                        {
                            string emailSubject = $"Update regarding your application for {jobTitle}";
                            string emailBody = "";

                            if (newStatus == ApplicationStatus.INTERVIEWING)
                            {
                                emailSubject = $"Interview Invitation: {jobTitle}";
                                emailBody = $@"
                                    <h2>Chúc mừng!</h2>
                                    <p>Chào {appWithDetails.Candidate.FullName},</p>
                                    <p>Chúng tôi rất ấn tượng với hồ sơ của bạn và muốn mời bạn tham gia buổi phỏng vấn cho vị trí <strong>{jobTitle}</strong>.</p>
                                    <p><strong>Thời gian:</strong> {request.InterviewDate?.ToString("f")}</p>
                                    <p>Vui lòng xác nhận sự tham gia của bạn bằng cách phản hồi email này.</p>
                                    <p>Trân trọng,<br/>Bộ phận Nhân sự & Ban điều hành Công ty</p>";
                            }
                            else if (newStatus == ApplicationStatus.OFFERED)
                            {
                                emailSubject = $"Job Offer: {jobTitle}";
                                emailBody = $@"
                                    <h2>Chúc mừng!</h2>
                                    <p>Chào {appWithDetails.Candidate.FullName},</p>
                                    <p>Chúng tôi rất vui mừng được gửi đến bạn lời mời làm việc (Job Offer) cho vị trí <strong>{jobTitle}</strong>.</p>
                                    <p>Kinh nghiệm và kỹ năng của bạn rất phù hợp với đội ngũ của chúng tôi. Chúng tôi rất mong chờ bạn gia nhập công ty!</p>
                                    <p>Vui lòng kiểm tra hồ sơ ứng tuyển của bạn trên hệ thống SmartRecruit để xem chi tiết lời mời.</p>
                                    <p>Trân trọng,<br/>Bộ phận Nhân sự & Ban điều hành Công ty</p>";
                            }
                            else if (newStatus == ApplicationStatus.REJECTED)
                            {
                                emailSubject = $"Application Update: {jobTitle}";
                                emailBody = $@"
                                    <p>Chào {appWithDetails.Candidate.FullName},</p>
                                    <p>Cảm ơn bạn đã quan tâm và dành thời gian ứng tuyển vào vị trí <strong>{jobTitle}</strong>.</p>
                                    <p>Chúng tôi rất tiếc phải thông báo rằng bạn chưa phù hợp trong đợt tuyển dụng này.</p>
                                    <p><strong>Lời nhắn từ nhà tuyển dụng:</strong> {request.RejectionReason}</p>
                                    <p>Chúng tôi sẽ lưu hồ sơ của bạn và hy vọng có cơ hội hợp tác trong tương lai.</p>
                                    <p>Chúc bạn nhiều may mắn trên con đường sự nghiệp!</p>
                                    <p>Trân trọng,<br/>Bộ phận Nhân sự & Ban điều hành Công ty</p>";
                            }

                            if (!string.IsNullOrEmpty(emailBody))
                            {
                                await _emailService.SendHtmlEmailAsync(appWithDetails.Candidate.Email, emailSubject, emailBody);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send notification for application {ApplicationId}", id);
                }
            }
            return result;
        }

        public async Task<ApplicationResponse?> GetApplicationByJobAndCandidateAsync(long jobId, long candidateId)
        {
            var application = await _applicationRepository.GetApplicationByJobAndCandidateAsync(jobId, candidateId);
            return _mapper.Map<ApplicationResponse>(application);
        }

        public async Task<bool> AddNoteAsync(long id, string note)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) throw new KeyNotFoundException($"Application with ID {id} not found.");

            if (!string.IsNullOrWhiteSpace(note))
            {
                var cleanNote = note.Replace(",", ";");
                application.Notes = string.IsNullOrEmpty(application.Notes) ? cleanNote : $"{application.Notes}, {cleanNote}";
                _applicationRepository.Update(application);
                return await _unitOfWork.CompleteAsync() > 0;
            }
            return false;
        }

        public async Task<bool> ClearNotesAsync(long id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) throw new KeyNotFoundException($"Application with ID {id} not found.");

            application.Notes = null;
            _applicationRepository.Update(application);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> RestoreStatusAsync(long id)
        {
            try
            {
                _logger.LogInformation("Restoring application status for Id: {Id}", id);
                var application = await _applicationRepository.GetByIdAsync(id);
                if (application == null) throw new KeyNotFoundException("Application not found.");
                if (application.Status != ApplicationStatus.REJECTED) throw new InvalidOperationException("Only rejected applications can be restored.");

                var notesHistory = application.Notes?.Split(',', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
                
                // Default to Reviewing
                var restoredStatus = ApplicationStatus.REVIEWING;
                string apologyMessage = "Chúng tôi xin lỗi vì sự bất tiện này. Hồ sơ của bạn đã được xem xét kỹ lại và chúng tôi nhận thấy tiềm năng của bạn.";
                string specificReason = "HR có thể đã lỡ tay loại hoặc sau khi xem kỹ lại thấy tiềm năng.";

                // Find the last status note before current Rejected status
                for (int i = notesHistory.Length - 1; i >= 0; i--)
                {
                    var note = notesHistory[i].Trim();
                    if (note.StartsWith("Offered:"))
                    {
                        restoredStatus = ApplicationStatus.OFFERED;
                        specificReason = "Ứng viên từ chối lương, nhưng sau đó 2 bên thương lượng lại thành công.";
                        apologyMessage = "Sau khi thương lượng lại, chúng tôi rất vui mừng được khôi phục đề nghị nhận việc cho bạn.";
                        break;
                    }
                    if (note.StartsWith("Interview:"))
                    {
                        restoredStatus = ApplicationStatus.INTERVIEWING;
                        specificReason = "Có thể ứng viên chưa đạt ở vòng 1 nhưng công ty muốn cho họ cơ hội phỏng vấn ở một Team khác/vòng khác.";
                        apologyMessage = "Chúng tôi muốn mời bạn tham gia phỏng vấn tại một vòng khác hoặc một nhóm chuyên môn khác phù hợp hơn.";
                        break;
                    }
                }

                application.Status = restoredStatus;
                string restoreNote = $"Restored to {restoredStatus} (Reason: {specificReason})".Replace(",", ";");
                application.Notes = string.IsNullOrEmpty(application.Notes) ? restoreNote : $"{application.Notes}, {restoreNote}";
                
                _applicationRepository.Update(application);
                var saveResult = await _unitOfWork.CompleteAsync();
                var success = saveResult > 0 || restoredStatus == ApplicationStatus.REVIEWING; // Success if saved or at least state updated

                if (success)
                {
                    try 
                    {
                        var appWithDetails = await _applicationRepository.GetApplicationWithDetailsAsync(id);
                        if (appWithDetails != null)
                        {
                            string jobTitle = appWithDetails.Job?.Title ?? "vị trí ứng tuyển";
                            long candidateId = appWithDetails.CandidateId;
                            
                            // Real-time Update
                            try 
                            {
                                await _notificationHubService.SendApplicationStatusUpdateAsync(candidateId, new SmartRecruit.Application.DTO.Application.ApplicationStatusUpdateDto
                                {
                                    ApplicationId = id,
                                    Status = restoredStatus.ToString(),
                                    JobTitle = jobTitle,
                                    UpdatedAt = application.UpdatedAt.GetValueOrDefault(DateTime.UtcNow)
                                });
                            }
                            catch (Exception ex)
                            {
                                _logger.LogWarning(ex, "Failed to send SignalR status update during restore for ApplicationId {ApplicationId}", id);
                            }

                            // Persistent Notification
                            try
                            {
                                string statusText = restoredStatus.ToString().Replace("_", " ").ToLower();
                                string message = $"Hồ sơ của bạn cho vị trí '{jobTitle}' đã được khôi phục về trạng thái: {statusText}.";
                                if (restoredStatus == ApplicationStatus.OFFERED)
                                    message = $"Tin vui! Đề nghị nhận việc của bạn cho vị trí '{jobTitle}' đã được khôi phục. Vui lòng kiểm tra lại.";

                                await _notificationService.SendNotificationAsync(
                                    candidateId,
                                    "Khôi phục hồ sơ",
                                    message,
                                    NotificationType.APPLICATION,
                                    "/JobApplications");
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Failed to send persistent notification for restoration of app {Id}", id);
                            }

                            // Send Email
                            if (appWithDetails.Candidate != null && !string.IsNullOrEmpty(appWithDetails.Candidate.Email))
                            {
                                try
                                {
                                    string candidateName = appWithDetails.Candidate.FullName ?? "Ứng viên";
                                    string emailSubject = $"[SmartRecruit] Thông báo khôi phục hồ sơ: {jobTitle}";
                                    string emailBody = $@"
                                        <div style='font-family: Arial, sans-serif;'>
                                            <h2>Lời xin lỗi từ Bộ phận Nhân sự & Công ty</h2>
                                            <p>Chào {candidateName},</p>
                                            <p>Chúng tôi gửi email này để thông báo rằng hồ sơ của bạn cho vị trí <strong>{jobTitle}</strong> đã được khôi phục về trạng thái <strong>{restoredStatus}</strong>.</p>
                                            <p style='background-color: #f8f9fa; padding: 15px; border-left: 5px solid #28a745;'>
                                                <strong>Lý do khôi phục:</strong> {specificReason}
                                            </p>
                                            <p>{apologyMessage}</p>
                                            <p>Bạn vui lòng truy cập hệ thống để cập nhật tiến độ mới nhất.</p>
                                            <p>Trân trọng,<br/>Đội ngũ Nhân sự & Ban điều hành Công ty</p>
                                        </div>";
                                    
                                    await _emailService.SendHtmlEmailAsync(appWithDetails.Candidate.Email, emailSubject, emailBody);
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, "Failed to send apology email for restoration of app {Id}", id);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Critical error after successful restoration of app {Id}", id);
                    }
                }
                return true; // Return true as long as we updated the status
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in RestoreStatusAsync for Id: {Id}", id);
                throw;
            }
        }

        public async Task<int> BulkUpdateStatusAsync(BulkUpdateApplicationStatusRequest request)
        {
            int updatedCount = 0;
            // Thực hiện tuần tự để đảm bảo validation cho từng bản ghi
            foreach (var id in request.ApplicationIds)
            {
                var singleRequest = new UpdateApplicationStatusRequest
                {
                    Status = request.Status,
                    InterviewDate = request.InterviewDate,
                    RejectionReason = request.RejectionReason
                };

                var success = await UpdateStatusAsync(id, singleRequest);
                if (success) updatedCount++;
            }
            return updatedCount;
        }

        public async Task<byte[]> ExportApplicantsToExcelAsync(long jobId)
        {
            var applications = await _applicationRepository.GetApplicationsByJobWithDetailsAsync(jobId);
            
            var exportData = applications.Select(app => new ApplicantExportDto
            {
                HoTen = app.Candidate?.FullName ?? "N/A",
                Email = app.Candidate?.Email ?? "N/A",
                LinkCV = app.Candidate?.CandidateProfile?.CVUrl ?? "Chưa có",
                DiemAI = app.MatchScore.ToString() + "%",
                DanhGiaAI = app.AI_Summary ?? "",
                TrangThai = app.Status switch
                {
                    ApplicationStatus.REVIEWING => "Đang xem xét",
                    ApplicationStatus.INTERVIEWING => "Đang phỏng vấn",
                    ApplicationStatus.OFFERED => "Đã mời làm việc",
                    ApplicationStatus.REJECTED => "Đã từ chối",
                    _ => app.Status.ToString()
                },
                NgayUngTuyen = app.CreatedAt.ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            return _excelService.ExportToExcel(exportData, "Danh sách ứng viên");
        }

        public async Task<bool> ReAnalyzeAsync(long applicationId)
        {
            var application = await _applicationRepository.GetApplicationWithDetailsAsync(applicationId);
            if (application == null) return false;

            _logger.LogInformation("Re-analyzing application {ApplicationId} for Job {JobId}", applicationId, application.JobId);

            // Reset scores
            application.MatchScore = 0;
            application.SkillMatch = 0;
            application.ExperienceMatch = 0;
            application.AI_Summary = "Hệ thống đang thực hiện phân tích lại CV của bạn. Vui lòng đợi trong giây lát...";
            application.UpdatedAt = DateTime.UtcNow;

            _applicationRepository.Update(application);
            await _unitOfWork.CompleteAsync();

            // Notify initial state
            try
            {
                var updateDto = new SmartRecruit.Application.DTO.Application.ApplicationScoreUpdateDto
                {
                    ApplicationId = applicationId,
                    JobId = application.JobId,
                    MatchScore = 0,
                    SkillMatch = 0,
                    ExperienceMatch = 0,
                    AISummary = application.AI_Summary
                };
                
                await _notificationHubService.SendApplicationScoreUpdateAsync(application.CandidateId, updateDto);
                if (application.Job != null)
                {
                    await _notificationHubService.SendApplicationScoreUpdateAsync(application.Job.RecruiterId, updateDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send initial SignalR update during re-analysis for AppId {Id}", applicationId);
            }

            // Enqueue new scoring job
            _backgroundJobClient.Enqueue<IApplicationService>(x => x.ScoreApplicationAsync(applicationId));

            return true;
        }
    }
}

