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
        /// Lấy danh sách các công việc ứng viên đã nộp
        /// </summary>
        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetByCandidate(long candidateId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var applications = await _applicationService.GetApplicationsByCandidateAsync(candidateId, page, pageSize);
            return Ok(applications.WrapPaged());
        }

        /// <summary>
        /// HR xem danh sách ứng viên của một Job (Kèm AI Ranking)
        /// </summary>
        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJob(long jobId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] bool sortByScore = false)
        {
            var applications = await _applicationService.GetApplicationsByJobAsync(jobId, page, pageSize, sortByScore);
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

        /// <summary>
        /// Nộp hồ sơ ứng tuyển (Apply Job)
        /// AI scoring sẽ được xử lý bất đồng bộ bởi Hangfire
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ApplyJob([FromBody] ApplyJobRequest request)
        {
            await _applicationService.ApplyJobAsync(request);

            // Trả về thông báo thành công, không kèm data Score bị null
            return Ok(new
            {
                message = "Application submitted successfully"
            });
        }

        /// <summary>
        /// Cập nhật trạng thái ứng viên (Kanban)
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] UpdateApplicationStatusRequest request)
        {
            try
            {
                var success = await _applicationService.UpdateStatusAsync(id, request);
                if (success)
                {
                    return Ok(new { }.Wrap("Application status updated successfully"));
                }
                return BadRequest(new { }.Wrap("Failed to update application status"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { }.Wrap(ex.Message));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Cập nhật trạng thái hàng loạt (Kanban)
        /// </summary>
        [HttpPut("bulk-status")]
        public async Task<IActionResult> BulkUpdateStatus([FromBody] BulkUpdateApplicationStatusRequest request)
        {
            try
            {
                var count = await _applicationService.BulkUpdateStatusAsync(request);
                return Ok(new { UpdatedCount = count }.Wrap($"Successfully updated status for {count} applications"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }
    }
}

