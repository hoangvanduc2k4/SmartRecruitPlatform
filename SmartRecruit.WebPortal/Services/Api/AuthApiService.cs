using WebPortal.Models.Api;

namespace WebPortal.Services.Api
{
    public interface IAuthApiService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<LoginResponse?> GoogleLoginAsync(string idToken);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<bool> LogoutAsync();
        Task<UserProfileResponse?> GetProfileAsync();
        Task<bool> UpdateProfileAsync(UpdateProfileRequest request);
        Task<bool> VerifyEmailAsync(VerifyEmailRequest request);
        Task<bool> ResendVerificationEmailAsync(string email);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
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
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>();
                if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                {
                    var result = apiResponse.Data;
                    if (!string.IsNullOrEmpty(result.Token))
                    {
                        // Default expiration is 15 minutes, matches backend token expiration
                        _tokenService.SetTokens(result.Token, result.RefreshToken, 15);
                        return result;
                    }
                }
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse>(content, options);
                    if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.Message))
                    {
                        throw new Exception(apiResponse.Message);
                    }
                }
                catch 
                {
                    // Fallback to exactly what the API sent so we can see the format
                    throw new Exception("API Error Response: " + content);
                }
                throw new Exception("API Error Response: " + content);
            }
            return null;
        }

        public async Task<LoginResponse?> GoogleLoginAsync(string idToken)
        {
            var request = new GoogleLoginRequest { IdToken = idToken };
            var response = await _httpClient.PostAsJsonAsync("auth/google-login", request);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponse>>();
                if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                {
                    var result = apiResponse.Data;
                    if (!string.IsNullOrEmpty(result.Token))
                    {
                        _tokenService.SetTokens(result.Token, result.RefreshToken, 15);
                        return result;
                    }
                }
            }
            return null;
        }

        public async Task<bool> LogoutAsync()
        {
            var refreshToken = _tokenService.GetRefreshToken();
            if (!string.IsNullOrEmpty(refreshToken))
            {
                var request = new LogoutRequest { RefreshToken = refreshToken };
                await _httpClient.PostAsJsonAsync("auth/logout", request);
            }
            _tokenService.ClearTokens();
            return true;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", request);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return apiResponse != null && apiResponse.Success;
            }
            else
            {
                try
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.Message))
                    {
                        throw new Exception(apiResponse.Message);
                    }
                }
                catch { /* Ignore parsing errors */ }
            }
            return false;
        }

        public async Task<UserProfileResponse?> GetProfileAsync()
        {
            var response = await _httpClient.GetAsync("users/profile");
            if (response.IsSuccessStatusCode)
            {
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                };
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<UserProfileResponse>>(options);
                if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                    return apiResponse.Data;
            }
            return null;
        }

        public async Task<bool> UpdateProfileAsync(UpdateProfileRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("users/profile", request);
            await EnsureSuccessOrThrowAsync(response);
            return true;
        }

        public async Task<bool> VerifyEmailAsync(VerifyEmailRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/verify-email", request);
            await EnsureSuccessOrThrowAsync(response);
            return true;
        }

        public async Task<bool> ResendVerificationEmailAsync(string email)
        {
            var request = new ResendVerificationEmailRequest { Email = email };
            var response = await _httpClient.PostAsJsonAsync("auth/resend-verification-email", request);
            await EnsureSuccessOrThrowAsync(response);
            return true;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var request = new ForgotPasswordRequest { Email = email };
            var response = await _httpClient.PostAsJsonAsync("auth/forgot-password", request);
            await EnsureSuccessOrThrowAsync(response);
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/reset-password", request);
            await EnsureSuccessOrThrowAsync(response);
            return true;
        }

        private async Task EnsureSuccessOrThrowAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;

            var content = await response.Content.ReadAsStringAsync();
            try
            {
                using var document = System.Text.Json.JsonDocument.Parse(content);
                var root = document.RootElement;

                // 1. Check for standard ASP.NET Core ValidationProblemDetails (Dictionary of arrays)
                if (root.TryGetProperty("errors", out var errorsElement) && errorsElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    foreach (var property in errorsElement.EnumerateObject())
                    {
                        if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Array && property.Value.GetArrayLength() > 0)
                        {
                            throw new Exception(property.Value[0].GetString() ?? "Validation error occurred.");
                        }
                    }
                }

                // 2. Check for our custom ApiResponse Wrapper (List of strings)
                if (root.TryGetProperty("errors", out var customErrorsElement) && customErrorsElement.ValueKind == System.Text.Json.JsonValueKind.Array && customErrorsElement.GetArrayLength() > 0)
                {
                    throw new Exception(customErrorsElement[0].GetString() ?? "An error occurred.");
                }

                // 3. Check for the standard "Message" property in our wrapper
                if (root.TryGetProperty("message", out var messageElement) && messageElement.ValueKind == System.Text.Json.JsonValueKind.String)
                {
                    var msg = messageElement.GetString();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        throw new Exception(msg);
                    }
                }
            }
            catch (Exception ex) when (ex.Message != null && !ex.Message.StartsWith("API Error") && !ex.Message.StartsWith("The JSON value"))
            {
                throw; // Rethrow parsed exceptions securely extracted from JSON
            }
            catch 
            {
                throw new Exception("API Error Response: " + content);
            }
            throw new Exception("API Error Response: " + content);
        }
    }
}
