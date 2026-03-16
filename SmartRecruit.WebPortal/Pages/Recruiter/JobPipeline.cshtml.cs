using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Recruiter
{
    public class JobPipelineModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public JobPipelineModel(IJobApiService jobApiService, IApplicationApiService applicationApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
        }

        public Job? Job { get; set; }
        public IList<Application> Applications { get; set; } = new List<Application>();

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            Job = await _jobApiService.GetJobByIdAsync(id.ToString());
            if (Job != null)
            {
                var response = await _applicationApiService.GetApplicationsByJobAsync(id, 1, 100);
                if (response.Data != null)
                {
                    Applications = response.Data.ToList();
                }
            }
            else
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long applicationId, string status, long jobId, DateTime? interviewDate, string? rejectionReason)
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            Console.WriteLine($"[JobPipeline] Updating Status - AppId: {applicationId}, Status: {status}, JobId: {jobId}, Date: {interviewDate}, Reason: {rejectionReason}");

            if (!ModelState.IsValid)
            {
                var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ErrorMessage = $"Binding error: {errors}";
                return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
            }

            if (System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
            {
                var request = new UpdateApplicationStatusRequest 
                { 
                    Status = nextStatus,
                    InterviewDate = interviewDate,
                    RejectionReason = rejectionReason
                };
                
                var result = await _applicationApiService.UpdateStatusAsync(applicationId, request);
                if (result.Success)
                {
                    SuccessMessage = "Status updated successfully.";
                }
                else
                {
                    ErrorMessage = $"Failed: {result.Message}";
                }
            }
            
            return RedirectToPage("/Recruiter/JobPipeline", new { id = jobId });
        }
    }
}
