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
            if (response.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(accessToken))
            {
                var refreshToken = _tokenService.GetRefreshToken();
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    // Attempt to refresh token
                    var tokensRefreshed = await RefreshTokensAsync(accessToken, refreshToken, cancellationToken);
                    if (tokensRefreshed)
                    {
                        var newAccessToken = _tokenService.GetAccessToken();
                        // Retry original request with new token
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newAccessToken);

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

            return response;
        }

        private async Task<bool> RefreshTokensAsync(string accessToken, string refreshToken, CancellationToken cancellationToken)
        {
            try
            {
                var baseUrl = _configuration["ApiBaseUrl"];
                if (string.IsNullOrEmpty(baseUrl)) return false;

                // Create a separate HttpClient to avoid circular dependency / infinite loops
                using var client = new HttpClient { BaseAddress = new Uri(baseUrl) };

                var payload = new { Token = accessToken, RefreshToken = refreshToken };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("auth/refresh-token", content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var newTokens = JsonSerializer.Deserialize<RefreshTokenResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (newTokens != null && !string.IsNullOrEmpty(newTokens.Token))
                    {
                        // Assuming 60 mins expiry for new token as a fallback if not provided
                        _tokenService.SetTokens(newTokens.Token, newTokens.RefreshToken, 60);
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
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
                clone.Options.Set(new HttpRequestOptionsKey<object>(prop.Key), prop.Value);
            }

            return clone;
        }

        private class RefreshTokenResponse
        {
            public string Token { get; set; } = string.Empty;
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
