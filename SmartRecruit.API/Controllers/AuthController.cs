
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("API Login called for email: {Email}", request.Email);
            var result = await _authService.LoginAsync(request);
            return Ok(result.Wrap("Login successful"));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            _logger.LogInformation("API Register called for email: {Email}", request.Email);
            await _authService.RegisterAsync(request);
            return Ok(new { }.Wrap("Registration successful. Please check your email for the verification code."));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            _logger.LogInformation("API RefreshToken called");
            var result = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(result.Wrap("Token refreshed successfully"));
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            _logger.LogInformation("API GoogleLogin called");
            var result = await _authService.GoogleLoginAsync(request);
            return Ok(result.Wrap("Google login successful"));
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            _logger.LogInformation("API Logout called");
            await _authService.LogoutAsync(request);
            return Ok(new { }.Wrap("Logged out successfully"));
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            _logger.LogInformation("API VerifyEmail called for email: {Email}", request.Email);
            await _authService.VerifyEmailAsync(request);
            return Ok(new { }.Wrap("Email verified successfully"));
        }

        [HttpPost("resend-verification-email")]
        public async Task<IActionResult> ResendVerificationEmail([FromBody] ResendVerificationEmailRequest request)
        {
            _logger.LogInformation("API ResendVerificationEmail called for email: {Email}", request.Email);
            await _authService.SendVerificationEmailAsync(request.Email);
            return Ok(new { }.Wrap("Verification email sent successfully"));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            _logger.LogInformation("API ForgotPassword called for email: {Email}", request.Email);
            await _authService.ForgotPasswordAsync(request);
            return Ok(new { }.Wrap("Password reset code sent to email"));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            _logger.LogInformation("API ResetPassword called for email: {Email}", request.Email);
            await _authService.ResetPasswordAsync(request);
            return Ok(new { }.Wrap("Password has been reset successfully"));
        }
    }
}