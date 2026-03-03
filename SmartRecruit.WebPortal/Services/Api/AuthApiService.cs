using WebPortal.Models.Api;

namespace WebPortal.Services.Api
{
    public interface IAuthApiService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<UserDto?> GetProfileAsync();
        Task<bool> UpdateProfileAsync(UserDto request);
    }

    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public AuthApiService(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (result != null && !string.IsNullOrEmpty(result.AccessToken))
                {
                    _tokenService.SetTokens(result.AccessToken, result.RefreshToken, result.ExpiresInMinutes);
                    return result;
                }
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<UserDto?> GetProfileAsync()
        {
            var response = await _httpClient.GetAsync("users/profile");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }
            return null;
        }

        public async Task<bool> UpdateProfileAsync(UserDto request)
        {
            var response = await _httpClient.PutAsJsonAsync("users/profile", request);
            return response.IsSuccessStatusCode;
        }
    }
}
