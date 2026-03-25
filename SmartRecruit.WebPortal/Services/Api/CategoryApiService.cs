
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using WebPortal.Models.Api;
using WebPortal.Models.Api.Category;

namespace WebPortal.Services.Api
{
    public interface ICategoryApiService
    {
        Task<PagedResponse<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter);
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<ApiResponse<CategoryResponse>> CreateCategoryAsync(CreateCategoryDTO request);
        Task<ApiResponse<CategoryResponse>> UpdateCategoryAsync(long id, UpdateCategoryDTO request);
        Task<bool> DeleteCategoryAsync(long id);
    }

    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CategoryApiService> _logger;

        public CategoryApiService(HttpClient httpClient, ILogger<CategoryApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("categories/all");
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<CategoryResponse>>>();
                return apiResponse?.Data ?? new List<CategoryResponse>();
            }
            return new List<CategoryResponse>();
        }

        public async Task<PagedResponse<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter)
        {
            var queryParams = new List<string>
            {
                $"pageNumber={filter.PageNumber}",
                $"pageSize={filter.PageSize}"
            };

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                queryParams.Add($"searchTerm={Uri.EscapeDataString(filter.SearchTerm)}");
            }

            var queryString = string.Join("&", queryParams);
            var response = await _httpClient.GetAsync($"categories?{queryString}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error fetching categories: {StatusCode}", response.StatusCode);
                return new PagedResponse<CategoryResponse> { Success = false, Message = "Failed to fetch categories" };
            }

            var pagedResponse = await response.Content.ReadFromJsonAsync<PagedResponse<CategoryResponse>>();
            return pagedResponse ?? new PagedResponse<CategoryResponse> { Success = false, Message = "Invalid response format" };
        }

        public async Task<ApiResponse<CategoryResponse>> CreateCategoryAsync(CreateCategoryDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("categories", request);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<CategoryResponse>>();
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error creating category. Status: {StatusCode}, Message: {Message}", response.StatusCode, apiResponse?.Message);
            }
            
            return apiResponse ?? new ApiResponse<CategoryResponse> { Success = false, Message = "Failed to create category." };
        }

        public async Task<ApiResponse<CategoryResponse>> UpdateCategoryAsync(long id, UpdateCategoryDTO request)
        {
            var response = await _httpClient.PutAsJsonAsync($"categories/{id}", request);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<CategoryResponse>>();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error updating category {Id}. Status: {StatusCode}, Message: {Message}", id, response.StatusCode, apiResponse?.Message);
            }

            return apiResponse ?? new ApiResponse<CategoryResponse> { Success = false, Message = "Failed to update category." };
        }

        public async Task<bool> DeleteCategoryAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error deleting category {Id}. Status: {StatusCode}", id, response.StatusCode);
            }
            return response.IsSuccessStatusCode;
        }
    }
}