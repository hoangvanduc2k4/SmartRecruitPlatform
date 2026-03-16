using System.Text.Json;
using WebPortal.Models;
using WebPortal.Models.Api;

namespace WebPortal.Services.Api
{
    public interface IApplicationApiService
    {
        Task<PagedResponse<Application>> GetApplicationsByJobAsync(long jobId, int page = 1, int pageSize = 10, bool sortByScore = false);
        Task<PagedResponse<Application>> GetApplicationsByCandidateAsync(long candidateId, int page = 1, int pageSize = 10);
        Task<PagedResponse<Application>> GetApplicationsAsync(long? candidateId = null, long? jobId = null, int? status = null, int page = 1, int pageSize = 10, bool sortByScore = false, long? recruiterId = null);
        Task<Application?> GetApplicationByIdAsync(long id);
        Task<(bool Success, string? Message)> UpdateStatusAsync(long id, UpdateApplicationStatusRequest request);
        Task<bool> BulkUpdateStatusAsync(BulkUpdateApplicationStatusRequest request);
        Task<bool> ApplyAsync(long jobId, long candidateId);
    }

    public class ApplicationApiService : IApplicationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApplicationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            _jsonOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        }

        public async Task<PagedResponse<Application>> GetApplicationsByJobAsync(long jobId, int page = 1, int pageSize = 10, bool sortByScore = false)
        {
            try
            {
                var response = await _httpClient.GetAsync($"applications/job/{jobId}?page={page}&pageSize={pageSize}&sortByScore={sortByScore}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PagedResponse<Application>>(_jsonOptions) ?? new PagedResponse<Application>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApplicationApiService] Error fetching applications for job {jobId}: {ex.Message}");
            }
            return new PagedResponse<Application>();
        }

        public async Task<PagedResponse<Application>> GetApplicationsByCandidateAsync(long candidateId, int page = 1, int pageSize = 10)
        {
            try
            {
                var response = await _httpClient.GetAsync($"applications/candidate/{candidateId}?page={page}&pageSize={pageSize}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PagedResponse<Application>>(_jsonOptions) ?? new PagedResponse<Application>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApplicationApiService] Error fetching applications for candidate {candidateId}: {ex.Message}");
            }
            return new PagedResponse<Application>();
        }

        public async Task<PagedResponse<Application>> GetApplicationsAsync(long? candidateId = null, long? jobId = null, int? status = null, int page = 1, int pageSize = 10, bool sortByScore = false, long? recruiterId = null)
        {
            try
            {
                var url = $"applications?page={page}&pageSize={pageSize}&sortByScore={sortByScore}";
                if (candidateId.HasValue) url += $"&candidateId={candidateId}";
                if (jobId.HasValue) url += $"&jobId={jobId}";
                if (status.HasValue) url += $"&status={status}";
                if (recruiterId.HasValue) url += $"&recruiterId={recruiterId}";

                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PagedResponse<Application>>(_jsonOptions) ?? new PagedResponse<Application>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApplicationApiService] Error searching applications: {ex.Message}");
            }
            return new PagedResponse<Application>();
        }

        public async Task<Application?> GetApplicationByIdAsync(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"applications/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ApiResponse<Application>>(_jsonOptions);
                    return result?.Data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ApplicationApiService] Error fetching application {id}: {ex.Message}");
            }
            return null;
        }

        public async Task<(bool Success, string? Message)> UpdateStatusAsync(long id, UpdateApplicationStatusRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"applications/{id}/status", request, _jsonOptions);
            if (response.IsSuccessStatusCode)
            {
                return (true, null);
            }
            
            var errorContent = await response.Content.ReadAsStringAsync();
            try
            {
                // Try to parse the wrapped error response
                var errorObj = JsonSerializer.Deserialize<ApiResponse<object>>(errorContent, _jsonOptions);
                return (false, errorObj?.Message ?? "API Error");
            }
            catch
            {
                return (false, $"HTTP {response.StatusCode}: {errorContent}");
            }
        }

        public async Task<bool> BulkUpdateStatusAsync(BulkUpdateApplicationStatusRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("applications/bulk-status", request, _jsonOptions);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ApplyAsync(long jobId, long candidateId)
        {
            var response = await _httpClient.PostAsJsonAsync("applications", new { JobId = jobId, CandidateId = candidateId });
            return response.IsSuccessStatusCode;
        }
    }
}
