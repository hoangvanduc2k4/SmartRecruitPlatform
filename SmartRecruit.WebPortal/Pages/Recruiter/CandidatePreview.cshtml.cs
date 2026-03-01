using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRecruitWeb.Models;
using SmartRecruitWeb.Services;

namespace SmartRecruitWeb.Pages
{
    public class CandidatePreviewModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public CandidatePreviewModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public Application Application { get; set; }
        public Job Job { get; set; }

        public IActionResult OnGet(string id)
        {
            Application = _mockDataService.Applications.FirstOrDefault(a => a.Id == id);
            if (Application != null)
            {
                Job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == Application.JobId);
            }
            if (Application == null || Job == null)
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }
            return Page();
        }

        public IActionResult OnPostUpdateStatus(string id, string status)
        {
            var app = _mockDataService.Applications.FirstOrDefault(a => a.Id == id);
            if (app != null && System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
            {
                app.Status = nextStatus;
            }
            return RedirectToPage(new { id });
        }
    }
}
