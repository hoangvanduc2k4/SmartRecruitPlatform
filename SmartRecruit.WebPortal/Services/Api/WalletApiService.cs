using WebPortal.Models;

namespace WebPortal.Services.Api
{
    public interface IWalletApiService
    {
        Task<WalletResponse?> GetWalletInfoAsync();
        Task<string?> CreateDepositLinkAsync(decimal amount);
        Task<bool> BoostJobAsync(string jobId);
    }

    public class WalletResponse
    {
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    public class ApplicationApiServiceResponse
    {
        public string CheckoutUrl { get; set; } = string.Empty;
    }

    public class WalletApiService : IWalletApiService
    {
        private readonly HttpClient _httpClient;

        public WalletApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WalletResponse?> GetWalletInfoAsync()
        {
            var response = await _httpClient.GetAsync("wallet");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var apiResponse = await response.Content.ReadFromJsonAsync<WebPortal.Models.Api.ApiResponse<WalletResponse>>(options);
                return apiResponse?.Data;
            }
            return null;
        }

        public async Task<string?> CreateDepositLinkAsync(decimal amount)
        {
            var response = await _httpClient.PostAsJsonAsync("payment/create-link", new { Amount = amount });
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApplicationApiServiceResponse>();
                return result?.CheckoutUrl;
            }
            return null;
        }

        public async Task<bool> BoostJobAsync(string jobId)
        {
            var response = await _httpClient.PostAsync($"payment/boost-job/{jobId}", null);
            return response.IsSuccessStatusCode;
        }
    }
}
