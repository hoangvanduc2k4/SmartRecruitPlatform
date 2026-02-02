using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs([FromQuery] JobSearchRequest request)
        {
            var jobs = await _jobService.GetJobsAsync(request);
            var response = jobs.WrapPaged(); 
            return Ok(response);
        }

        [HttpGet("recruiter/{recruiterId}")]
        public async Task<IActionResult> GetJobsByRecruiter(long recruiterId)
        {
            var jobs = await _jobService.GetJobsByRecruiterAsync(recruiterId);
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
            var job = await _jobService.CreateJobAsync(request);
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job.Wrap("Job created successfully"));
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
    }
}
