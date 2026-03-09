using WebPortal.Models;
using WebPortal.Models.Api;
using System.Text.Json;

namespace WebPortal.Services.Api
{
    public interface IJobApiService
    {
        Task<PagedResponse<Job>> GetJobsAsync(string? search, string? location, long? categoryId, JobType? type, decimal? minSalary, decimal? maxSalary, int page = 1, int pageSize = 10);
        Task<PagedResponse<Job>> GetJobsByRecruiterAsync(long recruiterId, int page = 1, int pageSize = 10);
        Task<Job?> GetJobByIdAsync(string id);
        Task<Job?> CreateJobAsync(Job job);
        Task<bool> UpdateJobAsync(string id, Job job);
        Task<bool> DeleteJobAsync(string id);
        Task<bool> ToggleVisibilityAsync(string id);
        Task<bool> BoostJobAsync(long jobId, long userId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<string>> GetLocationsAsync();
        Task<bool> IsJobSavedAsync(long jobId, long userId);
        Task<bool> ToggleSaveJobAsync(long jobId, long userId);
        Task<PagedResponse<Job>> GetSavedJobsAsync(long userId, int page = 1, int pageSize = 10);
        Task<bool> AppealJobAsync(long jobId, string message);
    }

    public class JobApiService : IJobApiService
    {
        private readonly HttpClient _httpClient;

        public JobApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResponse<Job>> GetJobsAsync(string? search, string? location, long? categoryId, JobType? type, decimal? minSalary, decimal? maxSalary, int page = 1, int pageSize = 10)
        {
            var query = new List<string>();
            if (!string.IsNullOrEmpty(search)) query.Add($"keyword={Uri.EscapeDataString(search)}");
            if (!string.IsNullOrEmpty(location) && location != "ALL") query.Add($"location={Uri.EscapeDataString(location)}");
            if (categoryId.HasValue && categoryId.Value > 0) query.Add($"categoryId={categoryId.Value}");
            if (type.HasValue) query.Add($"jobType={(int)type.Value}");
            if (minSalary.HasValue) query.Add($"minSalary={minSalary.Value}");
            if (maxSalary.HasValue) query.Add($"maxSalary={maxSalary.Value}");
            query.Add($"page={page}");
            query.Add($"pageSize={pageSize}");

            var queryString = query.Any() ? "?" + string.Join("&", query) : "";
            System.Console.WriteLine($"[JobApiService] Fetching: jobs{queryString}");
            var response = await _httpClient.GetAsync($"jobs{queryString}");
            System.Console.WriteLine($"[JobApiService] Response: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine($"[JobApiService] Content Length: {content.Length}");
                // System.Console.WriteLine($"[JobApiService] Content: {content.Substring(0, Math.Min(content.Length, 500))}");
                var options = new System.Text.Json.JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true 
                };
                options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                return await response.Content.ReadFromJsonAsync<PagedResponse<Job>>(options) ?? new PagedResponse<Job>();
            }
            return new PagedResponse<Job> { Success = false, Message = "Failed to fetch jobs" };
        }

        public async Task<PagedResponse<Job>> GetJobsByRecruiterAsync(long recruiterId, int page = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"jobs/recruiter/{recruiterId}?page={page}&pageSize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                return await response.Content.ReadFromJsonAsync<PagedResponse<Job>>(options) ?? new PagedResponse<Job>();
            }
            return new PagedResponse<Job> { Success = false, Message = "Failed to fetch recruiter jobs" };
        }

        public async Task<Job?> GetJobByIdAsync(string id)
        {
            if (!long.TryParse(id, out var longId)) return null;
            var response = await _httpClient.GetAsync($"jobs/{longId}");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Job>>(options);
                return apiResponse?.Data;
            }
            return null;
        }

        public async Task<Job?> CreateJobAsync(Job job)
        {
            var response = await _httpClient.PostAsJsonAsync("jobs", job);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Job>>();
                return apiResponse?.Data;
            }
            return null;
        }

        public async Task<bool> UpdateJobAsync(string id, Job job)
        {
            if (!long.TryParse(id, out var longId)) return false;
            var response = await _httpClient.PutAsJsonAsync($"jobs/{longId}", job);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteJobAsync(string id)
        {
            if (!long.TryParse(id, out var longId)) return false;
            var response = await _httpClient.DeleteAsync($"jobs/{longId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ToggleVisibilityAsync(string id)
        {
            if (!long.TryParse(id, out var longId)) return false;
            var response = await _httpClient.PatchAsync($"jobs/{longId}/visibility", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> BoostJobAsync(long jobId, long userId)
        {
            var response = await _httpClient.PostAsJsonAsync($"jobs/{jobId}/boost", new { UserId = userId });
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("categories");
                if (response.IsSuccessStatusCode)
                {
                    var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<Category>>>(options);
                    return apiResponse?.Data ?? new List<Category>();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error fetching categories: {ex.Message}");
            }
            return new List<Category>();
        }

        public async Task<IEnumerable<string>> GetLocationsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("jobs/locations");
                if (response.IsSuccessStatusCode)
                {
                    var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<string>>>(options);
                    return apiResponse?.Data ?? new List<string>();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error fetching locations: {ex.Message}");
            }
            return new List<string>();
        }
        public async Task<bool> IsJobSavedAsync(long jobId, long userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"jobs/{jobId}/is-saved?userId={userId}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<JsonElement>>();
                    if (result != null && result.Data.TryGetProperty("isSaved", out var isSavedProp))
                    {
                        return isSavedProp.GetBoolean();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error checking if job {jobId} is saved: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> ToggleSaveJobAsync(long jobId, long userId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"jobs/{jobId}/save?userId={userId}", null);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<JsonElement>>();
                    if (result != null && result.Data.TryGetProperty("isSaved", out var isSavedProp))
                    {
                        return isSavedProp.GetBoolean();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error toggling save for job {jobId}: {ex.Message}");
            }
            return false;
        }

        public async Task<PagedResponse<Job>> GetSavedJobsAsync(long userId, int page = 1, int pageSize = 10)
        {
            try
            {
                var response = await _httpClient.GetAsync($"jobs/saved?userId={userId}&page={page}&pageSize={pageSize}");
                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                    return await response.Content.ReadFromJsonAsync<PagedResponse<Job>>(options) ?? new PagedResponse<Job>();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error fetching saved jobs for user {userId}: {ex.Message}");
            }
            return new PagedResponse<Job> { Success = false, Message = "Failed to fetch saved jobs" };
        }

        public async Task<bool> AppealJobAsync(long jobId, string message)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"jobs/{jobId}/appeal", message);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[JobApiService] Error appealing job {jobId}: {ex.Message}");
            }
            return false;
        }
    }
}
