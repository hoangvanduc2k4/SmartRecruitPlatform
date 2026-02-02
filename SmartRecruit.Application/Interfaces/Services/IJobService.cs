using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Wrappers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IJobService
    {
        Task<PagedList<JobResponse>> GetJobsAsync(JobSearchRequest request);
        Task<PagedList<JobResponse>> GetJobsByRecruiterAsync(long recruiterId);
        Task<JobResponse> GetJobByIdAsync(long id);
        Task<JobResponse> CreateJobAsync(JobCreateRequest request);
        Task<JobResponse> UpdateJobAsync(long id, JobUpdateRequest request);
        Task<bool> DeleteJobAsync(long id);
        Task<bool> ToggleVisibilityAsync(long id);
    }
}
