using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IApplicationRepository : IGenericRepository<Applications>
    {
        Task<PagedList<Applications>> GetApplicationsAsync(ApplicationSearchRequest request);
        Task<bool> IsAlreadyAppliedAsync(long jobId, long candidateId);
        Task<Applications?> GetApplicationWithDetailsAsync(long id);
        Task<Applications?> GetApplicationByJobAndCandidateAsync(long jobId, long candidateId);
    }
}
