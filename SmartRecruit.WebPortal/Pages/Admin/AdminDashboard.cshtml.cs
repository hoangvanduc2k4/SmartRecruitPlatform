using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api.Admin;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly IAdminApiService _adminApiService;
        private readonly ILogger<AdminDashboardModel> _logger;

        public AdminDashboardModel(IAdminApiService adminApiService, ILogger<AdminDashboardModel> logger)
        {
            _adminApiService = adminApiService;
            _logger = logger;
        }

        public FinanceStatsResponse FinanceStats { get; set; } = new();
        public AdminUserStatsResponse UserStats { get; set; } = new();
        public AdminJobStatsResponse JobStats { get; set; } = new();
        public WeeklyRevenueResponse WeeklyRevenue { get; set; } = new();
        public decimal MaxRevenue { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var financeTask = _adminApiService.GetFinanceStatsAsync();
                var userTask = _adminApiService.GetAdminUserStatsAsync();
                var jobTask = _adminApiService.GetAdminJobStatsAsync();
                var weeklyTask = _adminApiService.GetWeeklyRevenueAsync();

                await Task.WhenAll(financeTask, userTask, jobTask, weeklyTask);

                FinanceStats = await financeTask ?? new();
                UserStats = await userTask ?? new();
                JobStats = await jobTask ?? new();
                WeeklyRevenue = await weeklyTask ?? new();

                MaxRevenue = WeeklyRevenue.Revenue.Any() ? WeeklyRevenue.Revenue.Max() : 1;
                if (MaxRevenue == 0) MaxRevenue = 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading admin dashboard stats");
            }
        }
    }
}
