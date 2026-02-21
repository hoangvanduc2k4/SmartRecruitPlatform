using AutoMapper;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<ApplicationResponse>> GetApplicationsAsync(ApplicationSearchRequest request)
        {
            var applications = await _applicationRepository.GetApplicationsAsync(request);
            var dtos = _mapper.Map<List<ApplicationResponse>>(applications);
            return new PagedList<ApplicationResponse>(dtos, applications.TotalCount, applications.CurrentPage, applications.PageSize);
        }

        public async Task<ApplicationResponse> GetApplicationByIdAsync(long id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) throw new KeyNotFoundException("Application not found");
            return _mapper.Map<ApplicationResponse>(application);
        }
    }
}
