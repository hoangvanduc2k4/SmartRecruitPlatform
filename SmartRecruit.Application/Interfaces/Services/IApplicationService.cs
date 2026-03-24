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
        Task<bool> AddNoteAsync(long id, string note);
        Task<bool> ClearNotesAsync(long id);
        Task<bool> RestoreStatusAsync(long id);
        Task<ApplicationResponse?> GetApplicationByJobAndCandidateAsync(long jobId, long candidateId);
        Task<int> BulkUpdateStatusAsync(BulkUpdateApplicationStatusRequest request);
        Task<byte[]> ExportApplicantsToExcelAsync(long jobId);
        Task<bool> ReAnalyzeAsync(long applicationId);
    }
}
