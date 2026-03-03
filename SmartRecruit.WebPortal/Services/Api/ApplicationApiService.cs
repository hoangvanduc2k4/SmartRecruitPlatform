using WebPortal.Models;

namespace WebPortal.Services.Api
{
    public interface IApplicationApiService
    {
        Task<List<Application>> GetMyApplicationsAsync();
        Task<List<Application>> GetApplicationsByJobAsync(string jobId);
        Task<bool> ApplyToJobAsync(string jobId);
        Task<bool> UpdateApplicationStatusAsync(string applicationId, ApplicationStatus status);
        Task<bool> BulkUpdateApplicationStatusAsync(List<string> applicationIds, ApplicationStatus status);
    }

    public class ApplicationApiService : IApplicationApiService
    {
        private readonly HttpClient _httpClient;

        public ApplicationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Application>> GetMyApplicationsAsync()
        {
            var response = await _httpClient.GetAsync("applications/my-applications");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Application>>() ?? new List<Application>();
            }
            return new List<Application>();
        }

        public async Task<List<Application>> GetApplicationsByJobAsync(string jobId)
        {
            var response = await _httpClient.GetAsync($"applications/job/{jobId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Application>>() ?? new List<Application>();
            }
            return new List<Application>();
        }

        public async Task<bool> ApplyToJobAsync(string jobId)
        {
            var response = await _httpClient.PostAsync($"jobs/{jobId}/apply", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateApplicationStatusAsync(string applicationId, ApplicationStatus status)
        {
            var response = await _httpClient.PatchAsJsonAsync($"applications/{applicationId}/status", new { Status = status });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> BulkUpdateApplicationStatusAsync(List<string> applicationIds, ApplicationStatus status)
        {
            var response = await _httpClient.PatchAsJsonAsync("applications/bulk-status", new { ApplicationIds = applicationIds, Status = status });
            return response.IsSuccessStatusCode;
        }
    }
}
