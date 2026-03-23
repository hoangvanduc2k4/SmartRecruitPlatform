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
        private readonly INotificationHubService _notificationHubService;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGeminiService geminiService,
            IBackgroundJobClient backgroundJobClient,
            INotificationService notificationService,
            INotificationHubService notificationHubService,
            ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _geminiService = geminiService;
            _backgroundJobClient = backgroundJobClient;
            _notificationService = notificationService;
            _notificationHubService = notificationHubService;
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

            if (application == null) throw new KeyNotFoundException("Không tìm thấy đơn ứng tuyển");

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
                throw new InvalidOperationException("Bạn đã ứng tuyển công việc này rồi.");
            }

            // 2. Kiểm tra xem candidate đã có CVText chưa
            var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == request.CandidateId);
            if (candidateProfile == null || string.IsNullOrWhiteSpace(candidateProfile.CVText))
            {
                _logger.LogWarning("ApplyJob use-case failed: Candidate {CandidateId} has not uploaded a CV", request.CandidateId);
                throw new InvalidOperationException("Vui lòng tải lên CV trong hồ sơ của bạn trước khi ứng tuyển.");
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
                        "Đơn ứng tuyển mới",
                        $"{candidateName} đã ứng tuyển vào công việc: {appWithDetails.Job.Title}",
                        NotificationType.APPLICATION,
                        $"/JobDetail?Id={appWithDetails.Job.Id}");
 
                    // 4b. Real-time Notification for Candidate (Confirmation)
                    await _notificationService.SendNotificationAsync(
                        request.CandidateId,
                        "Đã nộp đơn ứng tuyển",
                        $"Bạn đã ứng tuyển thành công vào: {appWithDetails.Job.Title}. Chúc bạn may mắn!",
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
                application.AI_Summary = $"Chấm điểm AI thất bại: {ex.Message}";
            }

            _applicationRepository.Update(application);
            await _unitOfWork.CompleteAsync();

            try
            {
                var updateDto = new SmartRecruit.Application.DTO.Application.ApplicationScoreUpdateDto
                {
                    JobId = application.JobId,
                    MatchScore = application.MatchScore,
                    SkillMatch = application.SkillMatch,
                    ExperienceMatch = application.ExperienceMatch,
                    AI_Summary = application.AI_Summary
                };
                await _notificationHubService.SendApplicationScoreUpdateAsync(application.CandidateId, updateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send real-time score update for ApplicationId {ApplicationId}", applicationId);
            }
        }

        public async Task<bool> UpdateStatusAsync(long id, UpdateApplicationStatusRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) throw new KeyNotFoundException("Không tìm thấy đơn ứng tuyển.");

            var currentStatus = application.Status;
            var newStatus = request.Status;

            // 1. Quy tắc chuyển đổi (Pipeline)
            if (newStatus != ApplicationStatus.REJECTED)
            {
                // Chỉ được tiến tới bước kế tiếp (Reviewing(0) -> Interviewing(1) -> Offered(2))
                if ((int)newStatus != (int)currentStatus + 1)
                {
                    throw new InvalidOperationException($"Chuyển đổi trạng thái không hợp lệ từ {currentStatus} sang {newStatus}. Bạn chỉ có thể chuyển sang bước logic tiếp theo.");
                }
            }
            // Rejected có thể chuyển từ bất kỳ đâu, trừ khi đã là Rejected
            else if (currentStatus == ApplicationStatus.REJECTED)
            {
                throw new InvalidOperationException("Đơn ứng tuyển này đã bị từ chối.");
            }

            // 2. Ràng buộc dữ liệu & Tận dụng cột Notes
            application.Notes = null; // Clear old notes

            if (newStatus == ApplicationStatus.INTERVIEWING)
            {
                if (!request.InterviewDate.HasValue)
                {
                    throw new InvalidOperationException("Ngày phỏng vấn là bắt buộc khi chuyển sang trạng thái Phỏng vấn.");
                }
                if (!string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("Lý do từ chối không được cung cấp khi chuyển sang trạng thái Phỏng vấn.");
                }
                application.Notes = $"Ngày phỏng vấn: {request.InterviewDate.Value:yyyy-MM-dd HH:mm}";
            }
            else if (newStatus == ApplicationStatus.REJECTED)
            {
                if (string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("Lý do từ chối là bắt buộc khi từ chối đơn ứng tuyển.");
                }
                if (request.InterviewDate.HasValue)
                {
                    throw new InvalidOperationException("Ngày phỏng vấn không được cung cấp khi từ chối đơn ứng tuyển.");
                }
                application.Notes = $"Lý do từ chối: {request.RejectionReason}";
            }
            else
            {
                // Đối với các trạng thái khác (Reviewing, Offered), nếu người dùng cố tình truyền data thì báo lỗi để họ xóa đi cho sạch
                if (request.InterviewDate.HasValue || !string.IsNullOrWhiteSpace(request.RejectionReason))
                {
                    throw new InvalidOperationException("Ngày phỏng vấn hoặc Lý do từ chối không bắt buộc cho trạng thái này. Vui lòng xóa chúng.");
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
                        string jobTitle = appWithDetails.Job?.Title ?? "công việc của bạn";
                        string statusText = newStatus switch
                        {
                            ApplicationStatus.REVIEWING => "đang xem xét",
                            ApplicationStatus.INTERVIEWING => "phỏng vấn",
                            ApplicationStatus.OFFERED => "đã mời làm việc",
                            ApplicationStatus.REJECTED => "đã từ chối",
                            _ => newStatus.ToString().ToLower()
                        };
                        string message = $"Đơn ứng tuyển của bạn cho '{jobTitle}' đã được cập nhật thành: {statusText}.";
                        
                        if (newStatus == ApplicationStatus.INTERVIEWING)
                            message = $"Chúc mừng! Bạn đã được mời phỏng vấn cho công việc '{jobTitle}'. Vui lòng kiểm tra email để biết thêm chi tiết.";
                        else if (newStatus == ApplicationStatus.OFFERED)
                            message = $"Tin vui! Bạn đã nhận được lời mời làm việc cho '{jobTitle}'. Chúc mừng bạn!";

                        await _notificationService.SendNotificationAsync(
                            appWithDetails.CandidateId,
                            "Cập nhật đơn ứng tuyển",
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

        public async Task<ApplicationResponse?> GetApplicationByJobAndCandidateAsync(long jobId, long candidateId)
        {
            var application = await _applicationRepository.GetApplicationByJobAndCandidateAsync(jobId, candidateId);
            return _mapper.Map<ApplicationResponse>(application);
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

