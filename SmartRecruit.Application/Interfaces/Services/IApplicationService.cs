using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IApplicationService
    {
        Task<PagedList<ApplicationResponse>> GetApplicationsAsync(ApplicationSearchRequest request);
        Task<ApplicationResponse> GetApplicationByIdAsync(long id);
    }
}
