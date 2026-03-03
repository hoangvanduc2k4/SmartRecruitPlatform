using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IApplicationService
    {
        Task<PagedList<ApplicationResponse>> GetApplicationsAsync(ApplicationSearchRequest request);
        Task<PagedList<ApplicationResponse>> GetApplicationsByCandidateAsync(long candidateId, int page = 1, int pageSize = 10);
        Task<PagedList<ApplicationResponse>> GetApplicationsByJobAsync(long jobId, int page = 1, int pageSize = 10, bool sortByScore = false);
        Task<ApplicationResponse> GetApplicationByIdAsync(long id);
        Task<bool> ApplyJobAsync(ApplyJobRequest request);
        Task ScoreApplicationAsync(long applicationId);
        Task<bool> UpdateStatusAsync(long id, UpdateApplicationStatusRequest request);
        Task<int> BulkUpdateStatusAsync(BulkUpdateApplicationStatusRequest request);

    }
}
