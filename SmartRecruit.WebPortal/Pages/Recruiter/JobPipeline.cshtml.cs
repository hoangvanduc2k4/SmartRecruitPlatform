using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class JobPipelineModel : PageModel
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
            Job = await _jobApiService.GetJobByIdAsync(id.ToString());
            if (Job != null)
            {
                var response = await _applicationApiService.GetApplicationsByJobAsync(id, 1, 100);
                if (response.Success && response.Data != null)
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

        public async Task<IActionResult> OnPostUpdateStatusAsync(long id, string status)
        {
            if (System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
            {
                var request = new UpdateApplicationStatusRequest { Status = nextStatus };
                if (nextStatus == ApplicationStatus.INTERVIEWING)
                {
                    request.InterviewDate = DateTime.Now.AddDays(3);
                }
                
                await _applicationApiService.UpdateStatusAsync(id, request);
                
                // We need the JobId to redirect back to the pipeline
                // Since we don't have the Application object easily, we'll try to get it if needed, 
                // but usually the UI passes the jobId too. 
                // For now, let's assume we redirect back to RecruiterJobs or the user can refresh.
                // Better: find the app to get jobId.
            }
            return RedirectToPage("/Recruiter/RecruiterJobs");
        }
    }
}
