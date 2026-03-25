using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public DashboardModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public User? CurrentUser { get; set; }
        public List<Application> UserApplications { get; set; } = new List<Application>();
        public List<Job> RelatedJobs { get; set; } = new List<Job>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public void OnGet()
        {
            // Simulate logged in candidate
            CurrentUser = _mockDataService.Users.FirstOrDefault(u => u.Role == UserRole.CANDIDATE) ?? new User();

            var query = _mockDataService.Applications
                .Where(a => a.CandidateId == CurrentUser.Id)
                .OrderByDescending(a => a.CreatedAt);

            var count = query.Count();
            TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);
            if (CurrentPage < 1) CurrentPage = 1;

            UserApplications = query
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var jobIds = UserApplications.Select(a => a.JobId).Distinct().ToList();
            RelatedJobs = _mockDataService.Jobs.Where(j => jobIds.Contains(j.Id)).ToList();
        }
    }
}
