using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<PagedList<Job>> GetJobsAsync(JobSearchRequest request);
        Task UpdateVisibilityAsync(long id, bool isVisible);
        Task<IEnumerable<string>> GetLocationsAsync();
        Task<IEnumerable<string>> GetTopLocationsAsync(int count);
        Task<PagedList<Job>> GetAppealedJobsAsync(int page, int pageSize);
        Task<RecruiterStatsResponse> GetRecruiterStatsAsync(long recruiterId);
        Task<IEnumerable<Job>> GetRecommendedJobsAsync(long userId, int limit = 10);
    }
}
