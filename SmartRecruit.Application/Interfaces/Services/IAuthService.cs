using SmartRecruit.Application.DTO.Auth;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(string token);
        Task<AuthResponse> GoogleLoginAsync(GoogleLoginRequest request);
    }
}
