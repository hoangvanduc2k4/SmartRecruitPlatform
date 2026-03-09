using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ISavedJobService
    {
        Task<bool> ToggleSaveJobAsync(long jobId, long userId);
        Task<bool> IsJobSavedAsync(long jobId, long userId);
        Task<PagedList<JobResponse>> GetSavedJobsAsync(long userId, int page, int pageSize);
    }
}
