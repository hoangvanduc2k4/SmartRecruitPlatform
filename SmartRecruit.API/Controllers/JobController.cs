
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
        public async Task<IActionResult> GetJobsByRecruiter(long recruiterId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var jobs = await _jobService.GetJobsByRecruiterAsync(recruiterId, page, pageSize);
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
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job.Wrap("Job created as draft. Please review and Publish to make it live."));
        }

        [HttpGet("my-jobs")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> GetMyJobs([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var jobs = await _jobService.GetJobsByRecruiterAsync(CurrentUserId, page, pageSize);
            return Ok(jobs.WrapPaged());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> UpdateJob(long id, [FromBody] JobUpdateRequest request)
        {
            try
            {
                // Note: In new flow, this will update draft if live, or main if not live
                var job = await _jobService.UpdateJobAsync(id, request, CurrentUserId, CurrentUserRole);
                return Ok(job.Wrap("Changes saved. If job is live, changes are pending publish."));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
        }

        [HttpGet("{id}/edit")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> GetJobForEdit(long id)
        {
            try
            {
                var job = await _jobService.GetJobForEditAsync(id, CurrentUserId);
                return Ok(job.Wrap());
            }
            catch (UnauthorizedAccessException) { return Forbid(); }
            catch (KeyNotFoundException ex) { return NotFound(new { }.Wrap(ex.Message)); }
        }

        [HttpPut("{id}/draft")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> SaveDraft(long id, [FromBody] JobDraftRequest request)
        {
            try
            {
                var job = await _jobService.SaveDraftAsync(id, request, CurrentUserId);
                return Ok(job.Wrap("Draft saved successfully"));
            }
            catch (UnauthorizedAccessException) { return Forbid(); }
            catch (KeyNotFoundException ex) { return NotFound(new { }.Wrap(ex.Message)); }
        }

        [HttpPost("{id}/publish")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> PublishJob(long id)
        {
            try
            {
                var job = await _jobService.PublishJobAsync(id, CurrentUserId);
                string message;
                if (job.Status == SmartRecruit.Domain.Enums.JobStatus.CHECKING)
                {
                    message = "Job is being processed by AI screening. You will be notified once it's live.";
                }
                else if (job.Status == SmartRecruit.Domain.Enums.JobStatus.APPROVED)
                {
                    message = "Job published successfully and is now live!";
                }
                else
                {
                    message = "Job was blocked or requires further review.";
                }
                return Ok(job.Wrap(message));
            }
            catch (UnauthorizedAccessException) { return Forbid(); }
            catch (KeyNotFoundException ex) { return NotFound(new { }.Wrap(ex.Message)); }
            catch (InvalidOperationException ex) { return BadRequest(new { }.Wrap(ex.Message)); }
            catch (Exception ex) { return StatusCode(500, new { }.Wrap(ex.Message)); }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            await _jobService.DeleteJobAsync(id);
            return Ok(new { }.Wrap("Job deleted successfully"));
        }

        [HttpPatch("{id}/visibility")]
        [Authorize(Roles = "RECRUITER, ADMIN")]
        public async Task<IActionResult> ToggleVisibility(long id)
        {
            var isVisible = await _jobService.ToggleVisibilityAsync(id);
            string status = isVisible ? "Visible" : "Hidden";
            return Ok(new { IsVisible = isVisible }.Wrap($"Job is now {status}"));
        }

        [HttpPost("{id}/boost")]
        [Authorize(Roles = "RECRUITER")]
        public async Task<IActionResult> BoostJob(long id)
        {
            try
            {
                var success = await _jobService.BoostJobAsync(id, CurrentUserId);
                if (success)
                {
                    return Ok(new { }.Wrap("Job boosted successfully! It will now appear at the top of the listings."));
                }
                return BadRequest(new { }.Wrap("Failed to boost job."));
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new { }.Wrap(ex.Message));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { }.Wrap(ex.Message));
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { }.Wrap($"An error occurred: {ex.Message}"));
            }
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
            try
            {
                var isSaved = await _savedJobService.ToggleSaveJobAsync(id, CurrentUserId);
                var message = isSaved ? "Job saved successfully" : "Job unsaved successfully";
                return Ok(new { IsSaved = isSaved }.Wrap(message));
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
            return Ok(new { Success = success }.Wrap("Appeal submitted successfully"));
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
            return Ok(recommendations.Wrap("Your personalized job recommendations based on your profile and history."));
        }
    }
}

