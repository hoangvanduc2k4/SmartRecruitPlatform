using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class CandidatePreviewModel : PageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public CandidatePreviewModel(IJobApiService jobApiService, IApplicationApiService applicationApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
        }

        public Application? Application { get; set; }
        public Job? Job { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            Application = await _applicationApiService.GetApplicationByIdAsync(id);
            if (Application != null)
            {
                Job = await _jobApiService.GetJobByIdAsync(Application.JobId.ToString());
            }

            if (Application == null || Job == null)
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
            }
            return RedirectToPage(new { id });
        }
    }
}
