using WebPortal.Models;
using WebPortal.Models.Api;
using System.Net.Http.Json;

namespace WebPortal.Services.Api
{
    public interface IWalletApiService
    {
        Task<WalletData?> GetWalletInfoAsync();
        Task<(string? CheckoutUrl, string? Error)> CreateDepositLinkAsync(decimal amount);
        Task<string?> GetPaymentLinkAsync(long orderCode);
        Task<PagedResponse<Transaction>?> GetTransactionsAsync(long? userId = null, int page = 1, int pageSize = 10, int? type = null, int? status = null);
    }

    public class WalletData
    {
        public long Id { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "VND";
    }

    public class PaymentLinkResponse
    {
        public string PaymentUrl { get; set; } = string.Empty;
    }

    public class WalletApiService : IWalletApiService
    {
        private readonly HttpClient _httpClient;

        public WalletApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WalletData?> GetWalletInfoAsync()
        {
            var response = await _httpClient.GetAsync("wallet");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<WalletData>>(options);
                return apiResponse?.Data;
            }
            return null;
        }

        public async Task<(string? CheckoutUrl, string? Error)> CreateDepositLinkAsync(decimal amount)
        {
            var requestBody = new 
            { 
                UserId = 0, // Server will overwrite
                Amount = (int)amount, 
                Description = string.Empty // Server will overwrite
            };

            var response = await _httpClient.PostAsJsonAsync("payment/create", requestBody);
            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<PaymentLinkResponse>>(options);
                return (apiResponse?.Data?.PaymentUrl, null);
            }
            
            try
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResponse>(options);
                return (null, errorResponse?.Message ?? "Unknown error from API");
            }
            catch (System.Text.Json.JsonException)
            {
                // API returned something other than ApiResponse (e.g. standard validation error)
                var rawError = await response.Content.ReadAsStringAsync();
                return (null, $"Error from API ({response.StatusCode}): {rawError}");
            }
        }

        public async Task<string?> GetPaymentLinkAsync(long orderCode)
        {
            var response = await _httpClient.GetAsync($"payment/{orderCode}/link");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<PaymentLinkResponse>>(options);
                return apiResponse?.Data?.PaymentUrl;
            }
            return null;
        }

        public async Task<PagedResponse<Transaction>?> GetTransactionsAsync(long? userId = null, int page = 1, int pageSize = 10, int? type = null, int? status = null)
        {
            var url = $"wallet/transactions?page={page}&pageSize={pageSize}";
            if (userId.HasValue)
            {
                url += $"&UserId={userId.Value}";
            }
            if (type.HasValue)
            {
                url += $"&Type={type.Value}";
            }
            if (status.HasValue)
            {
                url += $"&Status={status.Value}";
            }
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return await response.Content.ReadFromJsonAsync<PagedResponse<Transaction>>(options);
            }
            return null;
        }
    }
}
