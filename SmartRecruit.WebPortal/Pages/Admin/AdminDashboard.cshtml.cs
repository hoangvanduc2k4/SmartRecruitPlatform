using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public AdminDashboardModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public int TotalJobs { get; set; }
        public int TotalUsers { get; set; }
        public List<int> WeeklyRevenue { get; set; } = new List<int> { 1200000, 2100000, 1800000, 2900000, 3200000, 1500000, 900000 };
        public int MaxRevenue { get; set; }

        public void OnGet()
        {
            TotalJobs = _mockDataService.Jobs.Count;
            TotalUsers = _mockDataService.Users.Count;
            MaxRevenue = 3200000;
        }
    }
}
