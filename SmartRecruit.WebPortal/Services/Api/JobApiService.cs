using SmartRecruitWeb.Models;
using System.Net.Http.Json;

namespace SmartRecruitWeb.Services.Api
{
    public interface IJobApiService
    {
        Task<List<Job>> GetJobsAsync(string? search, string? location, string? category, JobType? type, decimal? minSalary);
        Task<Job?> GetJobByIdAsync(string id);
        Task<Job?> CreateJobAsync(Job job);
        Task<bool> UpdateJobAsync(string id, Job job);
        Task<bool> DeleteJobAsync(string id);
        Task<bool> ToggleVisibilityAsync(string id);
    }

    public class JobApiService : IJobApiService
    {
        private readonly HttpClient _httpClient;

        public JobApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Job>> GetJobsAsync(string? search, string? location, string? category, JobType? type, decimal? minSalary)
        {
            var query = new List<string>();
            if (!string.IsNullOrEmpty(search)) query.Add($"search={Uri.EscapeDataString(search)}");
            if (!string.IsNullOrEmpty(location)) query.Add($"location={Uri.EscapeDataString(location)}");
            if (!string.IsNullOrEmpty(category) && category != "All Categories") query.Add($"category={Uri.EscapeDataString(category)}");
            if (type.HasValue) query.Add($"type={type.Value}");
            if (minSalary.HasValue) query.Add($"minSalary={minSalary.Value}");

            var queryString = query.Any() ? "?" + string.Join("&", query) : "";
            var response = await _httpClient.GetAsync($"jobs{queryString}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Job>>() ?? new List<Job>();
            }
            return new List<Job>();
        }

        public async Task<Job?> GetJobByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"jobs/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Job>();
            }
            return null;
        }

        public async Task<Job?> CreateJobAsync(Job job)
        {
            var response = await _httpClient.PostAsJsonAsync("jobs", job);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Job>();
            }
            return null;
        }

        public async Task<bool> UpdateJobAsync(string id, Job job)
        {
            var response = await _httpClient.PutAsJsonAsync($"jobs/{id}", job);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteJobAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"jobs/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ToggleVisibilityAsync(string id)
        {
            var response = await _httpClient.PatchAsync($"jobs/{id}/visibility", null);
            return response.IsSuccessStatusCode;
        }
    }
}
