using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Models.Api.Admin;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace WebPortal.Services.Api
{
    public interface IAdminApiService
    {
        Task<PagedResponse<AdminUserResponse>> GetUsersAsync(UserSearchRequest request);
        Task<bool> UpdateUserStatusAsync(long userId, UpdateUserStatusRequest request);
        Task<PagedResponse<AppealedJobResponse>> GetAppealsAsync(int page = 1, int pageSize = 10);
        Task<bool> OverrideAiDecisionAsync(long jobId);
        Task<FinanceStatsResponse?> GetFinanceStatsAsync();
        Task<bool> RejectAppealAsync(long jobId);
        Task<PagedResponse<TransactionResponse>> GetGlobalTransactionsAsync(int page = 1, int pageSize = 10);
        Task<List<Notification>> GetNotificationsAsync();
    }


    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AdminApiService> _logger;

        public AdminApiService(HttpClient httpClient, ILogger<AdminApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<PagedResponse<AdminUserResponse>> GetUsersAsync(UserSearchRequest request)
        {
            var query = new List<string>();
            if (!string.IsNullOrEmpty(request.SearchHeader)) query.Add($"SearchHeader={Uri.EscapeDataString(request.SearchHeader)}");
            if (!string.IsNullOrEmpty(request.Role)) query.Add($"Role={Uri.EscapeDataString(request.Role)}");
            if (request.IsActive.HasValue) query.Add($"IsActive={request.IsActive.Value.ToString().ToLower()}");
            query.Add($"Page={request.Page}");
            query.Add($"PageSize={request.PageSize}");

            var queryString = string.Join("&", query);
            var response = await _httpClient.GetAsync($"admin/users?{queryString}");
            return await HandlePagedResponseAsync<AdminUserResponse>(response);
        }

        public async Task<bool> UpdateUserStatusAsync(long userId, UpdateUserStatusRequest request)
        {
            var response = await _httpClient.PatchAsJsonAsync($"admin/users/{userId}/status", request);
            return response.IsSuccessStatusCode;
        }

        private async Task<T?> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("API Error: {StatusCode}", response.StatusCode);
                return default;
            }

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<T>>();
            return apiResponse != null && apiResponse.Success ? apiResponse.Data : default;
        }

        private async Task<PagedResponse<T>> HandlePagedResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("API Error: {StatusCode}", response.StatusCode);
                return new PagedResponse<T> { Success = false, Message = "Failed to fetch data" };
            }

            var pagedResponse = await response.Content.ReadFromJsonAsync<PagedResponse<T>>();
            return pagedResponse ?? new PagedResponse<T> { Success = false, Message = "Invalid response format" };
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

        public async Task<PagedResponse<AppealedJobResponse>> GetAppealsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"admin/content/appeals?page={page}&pageSize={pageSize}");
            return await HandlePagedResponseAsync<AppealedJobResponse>(response);
        }

        public async Task<bool> OverrideAiDecisionAsync(long jobId)
        {
            var response = await _httpClient.PostAsync($"admin/content/jobs/{jobId}/override-ai", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RejectAppealAsync(long jobId)
        {
            var response = await _httpClient.PostAsync($"admin/content/jobs/{jobId}/reject-appeal", null);
            return response.IsSuccessStatusCode;
        }


        public async Task<FinanceStatsResponse?> GetFinanceStatsAsync()
        {
            var response = await _httpClient.GetAsync("admin/finance/stats");
            return await HandleResponseAsync<FinanceStatsResponse>(response);
        }

        public async Task<PagedResponse<TransactionResponse>> GetGlobalTransactionsAsync(int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"admin/finance/logs?page={page}&pageSize={pageSize}");
            return await HandlePagedResponseAsync<TransactionResponse>(response) ?? new PagedResponse<TransactionResponse>();
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
