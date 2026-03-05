using SmartRecruit.Application.DTO.Auth;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(string token);
        Task<AuthResponse> GoogleLoginAsync(GoogleLoginRequest request);
        Task LogoutAsync(LogoutRequest request);
        Task SendVerificationEmailAsync(string email);
        Task VerifyEmailAsync(VerifyEmailRequest request);
        Task ForgotPasswordAsync(ForgotPasswordRequest request);
        Task ResetPasswordAsync(ResetPasswordRequest request);
    }
}
