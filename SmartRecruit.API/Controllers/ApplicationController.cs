using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Lấy danh sách Applied Jobs (có thể lọc theo candidateId, jobId, status)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetApplications([FromQuery] ApplicationSearchRequest request)
        {
            var applications = await _applicationService.GetApplicationsAsync(request);
            return Ok(applications.WrapPaged());
        }

        /// <summary>
        /// Lấy chi tiết một Applied Job theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(long id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            return Ok(application.Wrap());
        }
    }
}
