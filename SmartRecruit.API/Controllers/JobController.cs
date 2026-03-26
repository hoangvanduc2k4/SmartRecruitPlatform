
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.API.Controllers;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        private readonly ISavedJobService _savedJobService;
        private readonly ILogger<JobController> _logger;

        public JobController(IJobService jobService, ISavedJobService savedJobService, ILogger<JobController> logger)
        {
            _jobService = jobService;
            _savedJobService = savedJobService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs([FromQuery] JobSearchRequest request)
        {
            _logger.LogInformation("API GetJobs called with search parameters: {@Request}", request);
            var jobs = await _jobService.GetJobsAsync(request);
            var response = jobs.WrapPaged();
            return Ok(response);
        }

        [HttpGet("recruiter/{recruiterId}")]
        [Authorize]
        public async Task<IActionResult> GetJobsByRecruiter(long recruiterId, [FromQuery] JobSearchRequest request)
        {
            // ✅ C2 FIX: Verify user is authorized to view this recruiter's jobs
            var currentUserId = CurrentUserId;
            var userRole = CurrentUserRole;
            
            if (recruiterId != currentUserId && userRole != SmartRecruit.Domain.Enums.UserRole.ADMIN)
            {
                return Unauthorized(new { message = "Bạn không có quyền xem danh sách công việc của người tuyển dụng khác" });
            }
            
            // Ensure recruiterId from route takes precedence
            var finalRequest = request with { recruiterId = recruiterId, showHidden = true, showBlocked = true };
            
            _logger.LogInformation("API GetJobsByRecruiter called for Recruiter {RecruiterId} with parameters: {@Request}", recruiterId, finalRequest);
            var jobs = await _jobService.GetJobsAsync(finalRequest);
            return Ok(jobs.WrapPaged());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(long id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            return Ok(job.Wrap());
        }

        [HttpPost]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateRequest request)
        {
            var jobRequest = request;
            if (CurrentUserRole == SmartRecruit.Domain.Enums.UserRole.RECRUITER || request.RecruiterId == 0)
            {
                jobRequest = request with { RecruiterId = CurrentUserId };
            }

            var job = await _jobService.CreateJobAsync(jobRequest);
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job.Wrap("Công việc đã được tạo dưới dạng nháp. Vui lòng kiểm tra và Đăng bài để mở ứng tuyển."));
        }

        [HttpGet("my-jobs")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> GetMyJobs([FromQuery] JobSearchRequest request)
        {
            var finalRequest = request with { recruiterId = CurrentUserId, showHidden = true, showBlocked = true };
            var jobs = await _jobService.GetJobsAsync(finalRequest);
            return Ok(jobs.WrapPaged());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> UpdateJob(long id, [FromBody] JobUpdateRequest request)
        {
            var job = await _jobService.UpdateJobAsync(id, request, CurrentUserId, CurrentUserRole);
            return Ok(job.Wrap("Đã lưu thay đổi. Nếu công việc đang hiển thị, các thay đổi sẽ được cập nhật sau khi đăng lại."));
        }

        [HttpGet("{id}/edit")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> GetJobForEdit(long id)
        {
            var job = await _jobService.GetJobForEditAsync(id, CurrentUserId);
            return Ok(job.Wrap());
        }

        [HttpPut("{id}/draft")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> SaveDraft(long id, [FromBody] JobDraftRequest request)
        {
            var job = await _jobService.SaveDraftAsync(id, request, CurrentUserId);
            return Ok(job.Wrap("Đã lưu bản nháp thành công"));
        }

        [HttpPost("{id}/publish")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> PublishJob(long id)
        {
            var job = await _jobService.PublishJobAsync(id, CurrentUserId);
            string message;
            if (job.Status == SmartRecruit.Domain.Enums.JobStatus.CHECKING)
            {
                message = "Công việc đang được kiểm duyệt bởi AI. Bạn sẽ nhận được thông báo khi bài đăng được duyệt.";
            }
            else if (job.Status == SmartRecruit.Domain.Enums.JobStatus.APPROVED)
            {
                message = "Đăng bài tuyển dụng thành công!";
            }
            else
            {
                message = "Công việc đã bị chặn hoặc cần xem xét thêm.";
            }
            return Ok(job.Wrap(message));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            await _jobService.DeleteJobAsync(id);
            return Ok(new { }.Wrap("Xóa công việc thành công"));
        }

        [HttpPatch("{id}/visibility")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> ToggleVisibility(long id)
        {
            var isVisible = await _jobService.ToggleVisibilityAsync(id);
            string status = isVisible ? "Hiển thị" : "Ẩn";
            return Ok(new { IsVisible = isVisible }.Wrap($"Công việc hiện đang {status}"));
        }

        [HttpPost("{id}/clone")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> CloneJob(long id)
        {
            var job = await _jobService.CloneJobAsync(id, CurrentUserId);
            return Ok(job.Wrap("Phát hiện clone job thành công. Hệ thống đang chuyển hướng..."));
        }

        [HttpPost("{id}/boost")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> BoostJob(long id)
        {
            await _jobService.BoostJobAsync(id, CurrentUserId);
            return Ok(new { }.Wrap("Đẩy tin thành công! Tin tuyển dụng của bạn sẽ xuất hiện ở đầu danh sách."));
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _jobService.GetLocationsAsync();
            return Ok(locations.Wrap());
        }

        [HttpGet("top-locations")]
        public async Task<IActionResult> GetTopLocations([FromQuery] int count = 5)
        {
            var locations = await _jobService.GetTopLocationsAsync(count);
            return Ok(locations.Wrap());
        }

        [HttpPost("{id}/save")]
        [Authorize]
        public async Task<IActionResult> ToggleSaveJob(long id)
        {
            var isSaved = await _savedJobService.ToggleSaveJobAsync(id, CurrentUserId);
            var message = isSaved ? "Đã lưu công việc thành công" : "Đã bỏ lưu công việc thành công";
            return Ok(new { IsSaved = isSaved }.Wrap(message));
        }

        [HttpGet("{id}/is-saved")]
        [Authorize]
        public async Task<IActionResult> IsJobSaved(long id)
        {
            var isSaved = await _savedJobService.IsJobSavedAsync(id, CurrentUserId);
            return Ok(new { IsSaved = isSaved }.Wrap());
        }

        [HttpGet("saved")]
        [Authorize]
        public async Task<IActionResult> GetSavedJobs([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var jobs = await _savedJobService.GetSavedJobsAsync(CurrentUserId, page, pageSize);
            return Ok(jobs.WrapPaged());
        }

        [HttpPost("{id}/appeal")]
        public async Task<IActionResult> AppealJob(long id, [FromBody] string message)
        {
            var success = await _jobService.AppealJobAsync(id, message);
            return Ok(new { Success = success }.Wrap("Gửi khiếu nại thành công"));
        }

        [HttpGet("stats/recruiter")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> GetRecruiterStats()
        {
            var stats = await _jobService.GetRecruiterStatsAsync(CurrentUserId);
            return Ok(stats.Wrap());
        }

        [HttpGet("recommendations")]
        [Authorize]
        public async Task<IActionResult> GetRecommendations()
        {
            var recommendations = await _jobService.GetRecommendedJobsAsync(CurrentUserId);
            return Ok(recommendations.Wrap("Gợi ý công việc phù hợp dựa trên hồ sơ và lịch sử của bạn."));
        }
    }
}

