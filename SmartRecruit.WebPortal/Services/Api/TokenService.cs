using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebPortal.Services.Api
{
    public interface ITokenService
    {
        string? GetAccessToken();
        string? GetRefreshToken();
        void SetTokens(string accessToken, string refreshToken, int expiresInMinutes);
        void ClearTokens();
        ClaimsPrincipal? GetUserPrincipal();
    }

    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string AccessTokenKey = "AccessToken";
        private const string RefreshTokenKey = "RefreshToken";

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetAccessToken()
        {
            return _httpContextAccessor?.HttpContext?.Request.Cookies[AccessTokenKey];
        }

        public string? GetRefreshToken()
        {
            return _httpContextAccessor?.HttpContext?.Request.Cookies[RefreshTokenKey];
        }

        public void SetTokens(string accessToken, string refreshToken, int expiresInMinutes)
        {
            if (_httpContextAccessor?.HttpContext == null) return;

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Should be true in production (HTTPS)
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddMinutes(expiresInMinutes),
                Path = "/"
            };

            // Refresh token usually lives longer than access token
            var refreshCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddDays(7), // Assuming refresh token valid for 7 days
                Path = "/"
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(AccessTokenKey, accessToken, cookieOptions);

            if (!string.IsNullOrEmpty(refreshToken))
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append(RefreshTokenKey, refreshToken, refreshCookieOptions);
            }
        }

        public void ClearTokens()
        {
            if (_httpContextAccessor?.HttpContext == null) return;

            _httpContextAccessor.HttpContext.Response.Cookies.Delete(AccessTokenKey);
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(RefreshTokenKey);
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("MockUserRole"); // Delete mock as well for safety
        }

        public ClaimsPrincipal? GetUserPrincipal()
        {
            var token = GetAccessToken();
            if (string.IsNullOrEmpty(token)) return null;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
                return new ClaimsPrincipal(identity);
            }
            catch
            {
                return null;
            }
        }
    }
}
