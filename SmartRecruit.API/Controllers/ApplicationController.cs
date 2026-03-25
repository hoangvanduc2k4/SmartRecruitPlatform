using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SmartRecruit.API.Controllers;
using Microsoft.AspNetCore.RateLimiting;
using SmartRecruit.Domain.Exceptions;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/applications")]
    [EnableRateLimiting("default")]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;
        private readonly IJobService _jobService;
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(IApplicationService applicationService, IJobService jobService, ILogger<ApplicationController> logger)
        {
            _applicationService = applicationService;
            _jobService = jobService;
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
            var application = await _applicationService.GetApplicationByJobAndCandidateAsync(jobId, candidateId);
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
        [EnableRateLimiting("heavy")]
        public async Task<IActionResult> ApplyJob([FromBody] ApplyJobRequest request)
        {
            var success = await _applicationService.ApplyJobAsync(request);
            return Ok(success.Wrap("Nộp hồ sơ ứng tuyển thành công"));
        }

        /// <summary>
        /// Cập nhật trạng thái ứng viên (Kanban)
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] UpdateApplicationStatusRequest request)
        {
            await _applicationService.UpdateStatusAsync(id, request);
            return Ok(new { }.Wrap("Cập nhật trạng thái ứng tuyển thành công"));
        }

        /// <summary>
        /// Thêm ghi chú mới vào hồ sơ ứng tuyển (nối thêm vào Notes hiện có)
        /// </summary>
        [HttpPost("{id}/notes")]
        public async Task<IActionResult> AddNote(long id, [FromBody] string note)
        {
            await _applicationService.AddNoteAsync(id, note);
            return Ok(new { }.Wrap("Thêm ghi chú thành công"));
        }

        /// <summary>
        /// Xóa tất cả ghi chú của hồ sơ ứng tuyển
        /// </summary>
        [HttpDelete("{id}/notes")]
        public async Task<IActionResult> DeleteNotes(long id)
        {
            await _applicationService.ClearNotesAsync(id);
            return Ok(new { }.Wrap("Xóa tất cả ghi chú thành công"));
        }

        /// <summary>
        /// Khôi phục trạng thái hồ sơ ứng tuyển (từ Rejected về trạng thái trước đó)
        /// </summary>
        [HttpPost("{id}/restore")]
        public async Task<IActionResult> RestoreApplication(long id)
        {
            await _applicationService.RestoreStatusAsync(id);
            return Ok(new { }.Wrap("Khôi phục hồ sơ ứng tuyển thành công"));
        }

        /// <summary>
        /// Cập nhật trạng thái hàng loạt (Kanban)
        /// </summary>
        [HttpPut("bulk-status")]
        public async Task<IActionResult> BulkUpdateStatus([FromBody] BulkUpdateApplicationStatusRequest request)
        {
            var count = await _applicationService.BulkUpdateStatusAsync(request);
            return Ok(new { UpdatedCount = count }.Wrap($"Cập nhật trạng thái thành công cho {count} hồ sơ"));
        }

        /// <summary>
        /// Xuất danh sách ứng viên của một Job ra file Excel
        /// </summary>
        [HttpGet("export-job/{jobId}")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        [EnableRateLimiting("heavy")]
        public async Task<IActionResult> ExportJobApplicants(long jobId)
        {
            var job = await _jobService.GetJobByIdAsync(jobId);

            if (CurrentUserRole != SmartRecruit.Domain.Enums.UserRole.ADMIN && job.RecruiterId != CurrentUserId)
            {
                return Forbid();
            }

            var content = await _applicationService.ExportApplicantsToExcelAsync(jobId);
            
            string safeTitle = string.Join("_", job.Title.Split(Path.GetInvalidFileNameChars()));
            var fileName = $"Applicants_{safeTitle}_{DateTime.Now:yyyyMMddHHmm}.xlsx";

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        /// <summary>
        /// Phân tích lại CV bằng AI (dùng khi ứng viên cập nhật CV mới)
        /// </summary>
        [HttpPost("{id}/re-analyze")]
        public async Task<IActionResult> ReAnalyzeApplication(long id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);

            // Kiểm tra quyền: Chỉ Candidate của chính Application đó hoặc Admin mới được trigger
            if (CurrentUserRole != SmartRecruit.Domain.Enums.UserRole.ADMIN && application.CandidateId != CurrentUserId)
            {
                return Forbid();
            }

            await _applicationService.ReAnalyzeAsync(id);
            return Ok(true.Wrap("Đã bắt đầu quá trình phân tích lại. Kết quả sẽ được cập nhật trong giây lát."));
        }

        /// <summary>
        /// Phân tích lại CV bằng AI (dùng khi ứng viên cập nhật CV mới)
        /// </summary>
        [HttpPost("{id}/re-analyze")]
        public async Task<IActionResult> ReAnalyzeApplication(long id)
        {
            _logger.LogInformation("API ReAnalyzeApplication called for Id: {Id}", id);
            try
            {
                var application = await _applicationService.GetApplicationByIdAsync(id);
                if (application == null) return NotFound(new { }.Wrap("Đơn ứng tuyển không tồn tại"));

                // Kiểm tra quyền: Chỉ Candidate của chính Application đó hoặc Admin mới được trigger
                if (CurrentUserRole != SmartRecruit.Domain.Enums.UserRole.ADMIN && application.CandidateId != CurrentUserId)
                {
                    return Forbid();
                }

                var success = await _applicationService.ReAnalyzeAsync(id);
                if (success)
                {
                    return Ok(true.Wrap("Đã bắt đầu quá trình phân tích lại. Kết quả sẽ được cập nhật trong giây lát."));
                }
                return BadRequest(false.Wrap("Không thể thực hiện phân tích lại lúc này."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi phân tích lại CV cho Application {Id}", id);
                return StatusCode(500, false.Wrap(ex.Message));
            }
        }
    }
}

