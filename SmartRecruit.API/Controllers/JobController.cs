using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
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
        public async Task<IActionResult> CreateJob([FromBody] JobCreateRequest request)
        {
            // Background moderation will handle the check
            var job = await _jobService.CreateJobAsync(request);
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job.Wrap("Job created successfully. Moderation is pending."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(long id, [FromBody] JobUpdateRequest request)
        {
            var job = await _jobService.UpdateJobAsync(id, request);
            return Ok(job.Wrap("Job updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            await _jobService.DeleteJobAsync(id);
            return Ok(new { }.Wrap("Job deleted successfully"));
        }

        [HttpPatch("{id}/visibility")]
        public async Task<IActionResult> ToggleVisibility(long id)
        {
            var isVisible = await _jobService.ToggleVisibilityAsync(id);
            string status = isVisible ? "Visible" : "Hidden";
            return Ok(new { IsVisible = isVisible }.Wrap($"Job is now {status}"));
        }

        [HttpPost("{id}/boost")]
        public async Task<IActionResult> BoostJob(long id, [FromBody] BoostJobRequest request)
        {
            try
            {
                var success = await _jobService.BoostJobAsync(id, request.UserId);
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

        [HttpPost("{id}/save")]
        public async Task<IActionResult> ToggleSaveJob(long id, [FromQuery] long userId)
        {
            try
            {
                var isSaved = await _savedJobService.ToggleSaveJobAsync(id, userId);
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

        [HttpGet("saved")]
        public async Task<IActionResult> GetSavedJobs([FromQuery] long userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var jobs = await _savedJobService.GetSavedJobsAsync(userId, page, pageSize);
            return Ok(jobs.WrapPaged());
        }
    }
}

