using AutoMapper;
using Hangfire;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeminiService geminiService,
            IBackgroundJobClient backgroundJobClient,
            INotificationService notificationService,
            ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _geminiService = geminiService;
            _backgroundJobClient = backgroundJobClient;
            _notificationService = notificationService;
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
            var request = new ApplicationSearchRequest(candidateId, null, null, page, pageSize);
            return await GetApplicationsAsync(request);
        }

        public async Task<PagedList<ApplicationResponse>> GetApplicationsByJobAsync(long jobId, int page = 1, int pageSize = 10, bool sortByScore = false)
        {
            var request = new ApplicationSearchRequest(null, jobId, null, page, pageSize, sortByScore);
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

            // 2. Tạo bản ghi đơn giản
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
                application.AI_Summary = result.AI_Summary;
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
            application.Notes = null; // Clear old notes

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
                application.Notes = $"Interview Date: {request.InterviewDate.Value:yyyy-MM-dd HH:mm}";
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
                application.Notes = $"Rejection Reason: {request.RejectionReason}";
            }
            else
            {
                // Đối với các trạng thái khác (Reviewing, Offered), nếu người dùng cố tình truyền data thì báo lỗi để họ xóa đi cho sạch
                if (request.InterviewDate.HasValue || !string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("InterviewDate or RejectionReason are not required for this status. Please clear them.");
                }
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
                            $"/JobApplications"); // Candidate views their apps here
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send notification for application {ApplicationId}", id);
                }
            }
            return result;
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
    }
}

