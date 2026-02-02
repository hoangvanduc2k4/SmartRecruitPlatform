using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Task<PagedList<Job>> GetJobsAsync(JobSearchRequest request);
        Task UpdateVisibilityAsync(long id, bool isVisible);
    }
}
