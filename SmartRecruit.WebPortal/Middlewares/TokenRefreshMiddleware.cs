using System.Text;
using System.Text.Json;
using WebPortal.Services.Api;

namespace SmartRecruitWeb.Middlewares
{
    public class TokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenRefreshMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TokenRefreshMiddleware(RequestDelegate next, ILogger<TokenRefreshMiddleware> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only process GET requests to HTML pages, skip API calls, static files, etc.
            var path = context.Request.Path.Value?.ToLower() ?? "";
            if (context.Request.Method != "GET" || path.StartsWith("/api") || path.Contains('.'))
            {
                await _next(context);
                return;
            }

            var accessToken = context.Request.Cookies["AccessToken"];
            var refreshToken = context.Request.Cookies["RefreshToken"];

            // Condition: Access Token is missing/expired, BUT Refresh Token is still present
            if (string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                _logger.LogInformation("Middleware detected missing AccessToken but valid RefreshToken. Attempting silent refresh...");
                
                // We must create a new scope to resolve scoped services like ITokenService
                using var scope = _serviceProvider.CreateScope();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

                var baseUrl = configuration["ApiBaseUrl"];
                if (!string.IsNullOrEmpty(baseUrl))
                {
                    try
                    {
                        using var client = new HttpClient { BaseAddress = new Uri(baseUrl) };
                        var refreshRequest = new { RefreshToken = refreshToken };
                        var requestContent = new StringContent(JsonSerializer.Serialize(refreshRequest), Encoding.UTF8, "application/json");

                        var response = await client.PostAsync("auth/refresh-token", requestContent);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = await response.Content.ReadAsStringAsync();
                            var apiResponse = JsonSerializer.Deserialize<ApiResponseWrapper>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                            if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
                            {
                                var newTokens = apiResponse.Data;
                                
                                // 1. Update the Cookie via TokenService (This affects Response Cookies for next requests)
                                tokenService.SetTokens(newTokens.Token, newTokens.RefreshToken, 15);

                                // 2. CRITICAL: Inject the new token into the CURRENT Request's immutable cookie collection 
                                // so that the upcoming Razor Page logic and _Layout.cshtml see it immediately!
                                var cookies = context.Request.Cookies.ToDictionary(k => k.Key, v => v.Value);
                                cookies["AccessToken"] = newTokens.Token;
                                cookies["RefreshToken"] = newTokens.RefreshToken;
                                
                                // Replace the read-only collection with a custom wrapper containing our fresh tokens
                                context.Request.Cookies = new CustomCookieCollection(cookies);
                                
                                _logger.LogInformation("Middleware silent refresh successful.");
                            }
                            else
                            {
                                // Refresh logic failed (e.g. invalid token), clear cookies so they have to login
                                _logger.LogWarning("Middleware silent refresh returned unsuccessful payload.");
                                tokenService.ClearTokens();
                                ClearCurrentRequestCookies(context);
                            }
                        }
                        else
                        {
                            // Server rejected refresh token (e.g., revoked, expired in DB)
                            _logger.LogWarning("Middleware silent refresh rejected by API (Status: {StatusCode}).", response.StatusCode);
                            tokenService.ClearTokens();
                            ClearCurrentRequestCookies(context);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Middleware silent refresh failed due to exception.");
                    }
                }
            }

            // Continue the request pipeline
            await _next(context);
        }

        private void ClearCurrentRequestCookies(HttpContext context)
        {
            var cookies = context.Request.Cookies.ToDictionary(k => k.Key, v => v.Value);
            cookies.Remove("AccessToken");
            cookies.Remove("RefreshToken");
            context.Request.Cookies = new CustomCookieCollection(cookies);
        }

        // Custom wrapper to replace Request.Cookies, since RequestCookieCollection is internal
        private class CustomCookieCollection : IRequestCookieCollection
        {
            private readonly Dictionary<string, string> _cookies;
            public CustomCookieCollection(Dictionary<string, string> cookies) => _cookies = cookies;
            public string? this[string key] => _cookies.TryGetValue(key, out var val) ? val : null;
            public int Count => _cookies.Count;
            public ICollection<string> Keys => _cookies.Keys;
            public bool ContainsKey(string key) => _cookies.ContainsKey(key);
            public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _cookies.GetEnumerator();
            public bool TryGetValue(string key, out string value) => _cookies.TryGetValue(key, out value!);
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _cookies.GetEnumerator();
        }

        // Internal classes strictly for deserializing the middleware's API call
        private class ApiResponseWrapper
        {
            public bool Success { get; set; }
            public AuthResponseData? Data { get; set; }
        }

        private class AuthResponseData
        {
            public string Token { get; set; } = string.Empty;
            public string RefreshToken { get; set; } = string.Empty;
        }
    }
}
