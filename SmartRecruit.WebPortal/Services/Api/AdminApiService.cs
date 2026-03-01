using SmartRecruitWeb.Models.Api;
using SmartRecruitWeb.Models;
using System.Net.Http.Json;

namespace SmartRecruitWeb.Services.Api
{
    public interface IAdminApiService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<bool> UpdateUserStatusAsync(string userId, bool isActive, string? lockReason = null);
        Task<List<object>> GetAiLogsAsync(); // Replace object with proper AI Log DTO if exists
        Task<bool> OverrideAiDecisionAsync(string jobId);
        Task<List<Report>> GetReportsAsync();
        Task<FinanceStatsResponse?> GetFinanceStatsAsync();
        Task<List<Transaction>> GetGlobalTransactionsAsync();
        Task<List<Notification>> GetNotificationsAsync();
    }

    public class FinanceStatsResponse
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class Report
    {
        public string Id { get; set; } = string.Empty;
        public string JobId { get; set; } = string.Empty;
        public string ReporterId { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public bool IsProcessed { get; set; }
    }

    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;

        public AdminApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("admin/users");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UserDto>>() ?? new List<UserDto>();
            }
            return new List<UserDto>();
        }

        public async Task<bool> UpdateUserStatusAsync(string userId, bool isActive, string? lockReason = null)
        {
            var response = await _httpClient.PatchAsJsonAsync($"admin/users/{userId}/status", new { IsActive = isActive, LockReason = lockReason });
            return response.IsSuccessStatusCode;
        }

        public async Task<List<object>> GetAiLogsAsync()
        {
            var response = await _httpClient.GetAsync("admin/content/ai-logs");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<object>>() ?? new List<object>();
            }
            return new List<object>();
        }

        public async Task<bool> OverrideAiDecisionAsync(string jobId)
        {
            var response = await _httpClient.PostAsync($"admin/content/jobs/{jobId}/override-ai", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            var response = await _httpClient.GetAsync("admin/content/reports");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Report>>() ?? new List<Report>();
            }
            return new List<Report>();
        }

        public async Task<FinanceStatsResponse?> GetFinanceStatsAsync()
        {
            var response = await _httpClient.GetAsync("admin/finance/stats");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FinanceStatsResponse>();
            }
            return null;
        }

        public async Task<List<Transaction>> GetGlobalTransactionsAsync()
        {
            var response = await _httpClient.GetAsync("admin/finance/logs");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Transaction>>() ?? new List<Transaction>();
            }
            return new List<Transaction>();
        }

        public async Task<List<Notification>> GetNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("notifications");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Notification>>() ?? new List<Notification>();
            }
            return new List<Notification>();
        }
    }
}
