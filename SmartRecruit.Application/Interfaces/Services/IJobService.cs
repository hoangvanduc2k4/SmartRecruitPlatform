using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Application.DTO.Admin;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IJobService
    {
        Task<PagedList<JobResponse>> GetJobsAsync(JobSearchRequest request);
        Task<JobResponse> GetJobByIdAsync(long id);
        Task<JobResponse> CreateJobAsync(JobCreateRequest request);
        Task<JobResponse> UpdateJobAsync(long id, JobUpdateRequest request, long currentUserId, SmartRecruit.Domain.Enums.UserRole currentUserRole);
        Task<bool> DeleteJobAsync(long id);
        Task<bool> ToggleVisibilityAsync(long id);
        Task<bool> BoostJobAsync(long jobId, long userId);
        Task<JobResponse> GetJobForEditAsync(long id, long userId);
        Task<JobResponse> SaveDraftAsync(long id, JobDraftRequest request, long userId);
        Task<JobResponse> CloneJobAsync(long jobId, long userId);
        Task<JobResponse> PublishJobAsync(long id, long userId);
        Task ProcessJobPublishingAsync(long jobId, long userId);
        Task ModerateJobAsync(long jobId);
        Task<IEnumerable<string>> GetLocationsAsync();
        Task<IEnumerable<string>> GetTopLocationsAsync(int count);
        Task<bool> AppealJobAsync(long jobId, string message);
        Task<PagedList<AppealResponse>> GetAppealedJobsAsync(int page, int pageSize);
        Task<bool> OverrideAIAsync(long jobId);
        Task<bool> RejectAppealAsync(long jobId);
        Task<RecruiterStatsResponse> GetRecruiterStatsAsync(long recruiterId);
        Task<IEnumerable<JobResponse>> GetRecommendedJobsAsync(long userId);
        Task UpdateExpiredJobsAsync();
    }
}
