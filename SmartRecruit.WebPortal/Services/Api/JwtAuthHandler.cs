using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebPortal.Services.Api
{
    public class JwtAuthHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public JwtAuthHandler(ITokenService tokenService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Attach Access Token
            var accessToken = _tokenService.GetAccessToken();
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            // 2. Send Request
            var response = await base.SendAsync(request, cancellationToken);

            // 3. Handle 401 Unauthorized (Refresh Token logic)
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshToken = _tokenService.GetRefreshToken();
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    // Attempt to refresh token
                    var authResponse = await RefreshTokensAsync(accessToken, refreshToken, cancellationToken);
                    if (authResponse != null)
                    {
                        // Retry original request with NEWLY RECEIVED token (not from cookie yet!)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.Token);

                        // Need to clone the request since it has already been sent
                        response.Dispose();
                        var clonedRequest = await CloneRequestAsync(request);
                        response = await base.SendAsync(clonedRequest, cancellationToken);
                    }
                    else
                    {
                        // Refresh failed, clear tokens and let the UI redirect to login
                        _tokenService.ClearTokens();
                    }
                }
            }
            // 4. Handle 429 Too Many Requests (Rate Limiting)
            else if (response.StatusCode == (HttpStatusCode)429)
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Items["RateLimitExceeded"] = true;
                }
            }

            return response;
        }

        private async Task<AuthResponse?> RefreshTokensAsync(string? accessToken, string refreshToken, CancellationToken cancellationToken)
        {
            try
            {
                var baseUrl = _configuration["ApiBaseUrl"];
                if (string.IsNullOrEmpty(baseUrl)) return null;

                // Create a separate HttpClient to avoid circular dependency / infinite loops
                using var client = new HttpClient { BaseAddress = new Uri(baseUrl) };

                var refreshRequest = new { RefreshToken = refreshToken };
                var content = new StringContent(JsonSerializer.Serialize(refreshRequest), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("auth/refresh-token", content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<AuthResponse>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                    {
                        var newTokens = apiResponse.Data;
                        // Default expiration is 15 mins for access token, matches AuthService.cs
                        _tokenService.SetTokens(newTokens.Token, newTokens.RefreshToken, 15);
                        return newTokens;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Version = request.Version
            };

            if (request.Content != null)
            {
                var ms = new MemoryStream();
                await request.Content.CopyToAsync(ms);
                ms.Position = 0;
                clone.Content = new StreamContent(ms);

                foreach (var header in request.Content.Headers)
                {
                    clone.Content.Headers.Add(header.Key, header.Value);
                }
            }

            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            foreach (var prop in request.Options)
            {
                clone.Options.Set(new HttpRequestOptionsKey<object?>(prop.Key), prop.Value);
            }

            return clone;
        }

        // --- Helper Classes for Deserialization (Internal to avoid namespace clutter) ---
        private class ApiResponse<T>
        {
            public bool Success { get; set; }
            public T? Data { get; set; }
            public string Message { get; set; } = string.Empty;
        }

        private class AuthResponse
        {
            public string Token { get; set; } = string.Empty;
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
