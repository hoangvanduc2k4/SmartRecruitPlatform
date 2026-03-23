using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using SmartRecruit.API.Controllers;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(IApplicationService applicationService, ILogger<ApplicationController> logger)
        {
            _applicationService = applicationService;
            _logger = logger;
        }

        /// <summary>
        /// Lấy danh sách Applied Jobs (có thể lọc theo candidateId, jobId, status)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetApplications([FromQuery] ApplicationSearchRequest request)
        {
            _logger.LogInformation("API GetApplications called with parameters: {@Request}", request);
            var applications = await _applicationService.GetApplicationsAsync(request);
            return Ok(applications.WrapPaged());
        }

        /// <summary>
        /// Lấy danh sách các công việc ứng viên đã nộp
        /// </summary>
        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetByCandidate(long candidateId, [FromQuery] GetApplicationsByCandidateRequest request)
        {
            _logger.LogInformation("API GetByCandidate called for CandidateId: {CandidateId}, Page: {Page}, PageSize: {PageSize}", candidateId, request.Page, request.PageSize);
            var applications = await _applicationService.GetApplicationsByCandidateAsync(candidateId, request.Page, request.PageSize);
            return Ok(applications.WrapPaged());
        }

        /// <summary>
        /// HR xem danh sách ứng viên của một Job (Kèm AI Ranking)
        /// </summary>
        [HttpGet("job/{jobId}")]
        public async Task<IActionResult> GetByJob(long jobId, [FromQuery] GetApplicationsByJobRequest request)
        {
            _logger.LogInformation("API GetByJob called for JobId: {JobId}, Page: {Page}, PageSize: {PageSize}, SortByScore: {SortByScore}", jobId, request.Page, request.PageSize, request.SortByScore);
            var applications = await _applicationService.GetApplicationsByJobAsync(jobId, request.Page, request.PageSize, request.SortByScore);
            return Ok(applications.WrapPaged());
        }

        /// <summary>
        /// Lấy chi tiết đơn ứng tuyển của một ứng viên cho một Job cụ thể
        /// </summary>
        [HttpGet("job/{jobId}/candidate/{candidateId}")]
        public async Task<IActionResult> GetByJobAndCandidate(long jobId, long candidateId)
        {
            _logger.LogInformation("API GetByJobAndCandidate called for JobId: {JobId}, CandidateId: {CandidateId}", jobId, candidateId);
            var application = await _applicationService.GetApplicationByJobAndCandidateAsync(jobId, candidateId);
            if (application == null) return NotFound(new { }.Wrap("Không tìm thấy hồ sơ ứng tuyển"));
            return Ok(application.Wrap());
        }

        /// <summary>
        /// Lấy chi tiết một Applied Job theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(long id)
        {
            _logger.LogInformation("API GetApplicationById called for Id: {Id}", id);
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
            _logger.LogInformation("API ApplyJob called by CandidateId: {CandidateId} for JobId: {JobId}", request.CandidateId, request.JobId);
            try 
            {
                var success = await _applicationService.ApplyJobAsync(request);
                return Ok(success.Wrap("Nộp hồ sơ ứng tuyển thành công"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying for job");
                return StatusCode(500, new { success = false }.Wrap(ex.Message));
            }
        }

        /// <summary>
        /// Cập nhật trạng thái ứng viên (Kanban)
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] UpdateApplicationStatusRequest request)
        {
            _logger.LogInformation("API UpdateStatus called for ApplicationId: {Id} with Status: {Status}", id, request.Status);
            try
            {
                var success = await _applicationService.UpdateStatusAsync(id, request);
                if (success)
                {
                    return Ok(new { }.Wrap("Cập nhật trạng thái ứng tuyển thành công"));
                }
                return BadRequest(new { }.Wrap("Cập nhật trạng thái ứng tuyển thất bại"));
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
                _logger.LogError(ex, "An error occurred during UpdateStatus for ApplicationId: {Id}", id);
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Thêm ghi chú mới vào hồ sơ ứng tuyển (nối thêm vào Notes hiện có)
        /// </summary>
        [HttpPost("{id}/notes")]
        public async Task<IActionResult> AddNote(long id, [FromBody] string note)
        {
            _logger.LogInformation("API AddNote called for ApplicationId: {Id}", id);
            try
            {
                var success = await _applicationService.AddNoteAsync(id, note);
                if (success)
                {
                    return Ok(new { }.Wrap("Note added successfully"));
                }
                return BadRequest(new { }.Wrap("Failed to add note"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during AddNote for ApplicationId: {Id}", id);
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Xóa tất cả ghi chú của hồ sơ ứng tuyển
        /// </summary>
        [HttpDelete("{id}/notes")]
        public async Task<IActionResult> DeleteNotes(long id)
        {
            _logger.LogInformation("API DeleteNotes called for ApplicationId: {Id}", id);
            try
            {
                var success = await _applicationService.ClearNotesAsync(id);
                if (success)
                {
                    return Ok(new { }.Wrap("Notes cleared successfully"));
                }
                return BadRequest(new { }.Wrap("Failed to clear notes"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during DeleteNotes for ApplicationId: {Id}", id);
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Khôi phục trạng thái hồ sơ ứng tuyển (từ Rejected về trạng thái trước đó)
        /// </summary>
        [HttpPost("{id}/restore")]
        public async Task<IActionResult> RestoreApplication(long id)
        {
            _logger.LogInformation("API RestoreApplication called for ApplicationId: {Id}", id);
            try
            {
                var success = await _applicationService.RestoreStatusAsync(id);
                if (success)
                {
                    return Ok(new { }.Wrap("Application restored successfully"));
                }
                return BadRequest(new { }.Wrap("Failed to restore application"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during RestoreApplication for ApplicationId: {Id}", id);
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }

        /// <summary>
        /// Cập nhật trạng thái hàng loạt (Kanban)
        /// </summary>
        [HttpPut("bulk-status")]
        public async Task<IActionResult> BulkUpdateStatus([FromBody] BulkUpdateApplicationStatusRequest request)
        {
            _logger.LogInformation("API BulkUpdateStatus called for {Count} applications to Status: {Status}", request.ApplicationIds.Count, request.Status);
            try
            {
                var count = await _applicationService.BulkUpdateStatusAsync(request);
                return Ok(new { UpdatedCount = count }.Wrap($"Cập nhật trạng thái thành công cho {count} hồ sơ"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { }.Wrap(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during BulkUpdateStatus");
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
        }
    }
}

