using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class JobPipelineModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public JobPipelineModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public Job Job { get; set; }
        public IList<Application> Applications { get; set; } = new List<Application>();

        public IActionResult OnGet(string id)
        {
            Job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == id);
            if (Job != null)
            {
                Applications = _mockDataService.Applications.Where(a => a.JobId == id).ToList();
            }
            else
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }
            return Page();
        }

        public IActionResult OnPostUpdateStatus(string id, string status)
        {
            var app = _mockDataService.Applications.FirstOrDefault(a => a.Id == id);
            if (app != null)
            {
                if (System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
                {
                    app.Status = nextStatus;
                }
                return RedirectToPage(new { id = app.JobId });
            }
            return RedirectToPage("/Recruiter/RecruiterJobs");
        }
    }
}
