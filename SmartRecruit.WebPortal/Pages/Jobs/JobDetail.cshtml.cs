using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class JobDetailModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public JobDetailModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public Job? Job { get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "DETAILS"; // DETAILS, APPLICANTS, PIPELINE

        // Mock User Data for context
        public User CurrentUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalApplicationCount { get; set; }

        public void OnGet()
        {
            // Simulating logged-in Recruiter for demo purposes
            CurrentUser = _mockDataService.Users.FirstOrDefault(u => u.Role == UserRole.RECRUITER) ?? new User { Role = UserRole.CANDIDATE };

            if (!string.IsNullOrEmpty(Id))
            {
                Job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == Id);
                if (Job != null)
                {
                    var query = _mockDataService.Applications
                        .Where(a => a.JobId == Id)
                        .OrderByDescending(a => a.MatchScore);

                    TotalApplicationCount = query.Count();

                    if (Tab == "APPLICANTS")
                    {
                        TotalPages = (int)System.Math.Ceiling(TotalApplicationCount / (double)PageSize);
                        if (CurrentPage < 1) CurrentPage = 1;

                        Applications = query.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                    }
                    else
                    {
                        Applications = query.ToList();
                    }
                }
            }
        }

        public IActionResult OnPostUpdateStatus(string applicationId, string status, string returnTab = "APPLICANTS")
        {
            var app = _mockDataService.Applications.FirstOrDefault(a => a.Id == applicationId);
            if (app != null && System.Enum.TryParse<ApplicationStatus>(status, out var parsedStatus))
            {
                app.Status = parsedStatus;
            }
            return RedirectToPage(new { Id = Id, Tab = returnTab });
        }

        public IActionResult OnPostBulkReject(List<string> selectedApplications)
        {
            if (selectedApplications != null && selectedApplications.Any())
            {
                foreach (var appId in selectedApplications)
                {
                    var app = _mockDataService.Applications.FirstOrDefault(a => a.Id == appId);
                    if (app != null && app.JobId == Id)
                    {
                        app.Status = ApplicationStatus.REJECTED;
                    }
                }
            }
            return RedirectToPage(new { Id = Id, Tab = "APPLICANTS" });
        }

        public IActionResult OnPostBoost()
        {
            var job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == Id);
            if (job != null)
            {
                job.IsBoosted = true;
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }
    }
}
