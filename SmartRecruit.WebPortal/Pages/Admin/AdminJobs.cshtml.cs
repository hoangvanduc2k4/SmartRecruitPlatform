using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class AdminJobsModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public AdminJobsModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public IList<Job> PendingJobs { get; set; } = new List<Job>();
        public IList<Job> ActiveJobs { get; set; } = new List<Job>();

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "PENDING"; // PENDING, ACTIVE

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPendingCount { get; set; }
        public int TotalActiveCount { get; set; }

        public void OnGet()
        {
            var jobs = _mockDataService.Jobs.AsQueryable();

            TotalPendingCount = jobs.Count(j => j.Status == JobStatus.PENDING);
            TotalActiveCount = jobs.Count(j => j.Status == JobStatus.PUBLISHED);

            var count = Tab == "PENDING" ? TotalPendingCount : TotalActiveCount;
            TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);
            if (CurrentPage < 1) CurrentPage = 1;

            if (Tab == "PENDING")
            {
                PendingJobs = jobs.Where(j => j.Status == JobStatus.PENDING)
                                  .Skip((CurrentPage - 1) * PageSize)
                                  .Take(PageSize)
                                  .ToList();
            }
            else
            {
                ActiveJobs = jobs.Where(j => j.Status == JobStatus.PUBLISHED)
                                 .Skip((CurrentPage - 1) * PageSize)
                                 .Take(PageSize)
                                 .ToList();
            }
        }

        public IActionResult OnPostApprove(string id)
        {
            var job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == id);
            if (job != null)
            {
                job.Status = JobStatus.PUBLISHED;
            }
            return RedirectToPage(new { Tab = "PENDING" });
        }

        public IActionResult OnPostReject(string id)
        {
            var job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == id);
            if (job != null)
            {
                job.Status = JobStatus.CLOSED;
            }
            return RedirectToPage(new { Tab = "PENDING" });
        }
    }
}
