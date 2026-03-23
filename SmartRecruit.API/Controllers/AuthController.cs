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
            return Ok(result.Wrap("Đăng nhập thành công"));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            _logger.LogInformation("API Register called for email: {Email}", request.Email);
            await _authService.RegisterAsync(request);
            return Ok(new { }.Wrap("Đăng ký thành công. Vui lòng kiểm tra email để lấy mã xác nhận."));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            _logger.LogInformation("API RefreshToken called");
            var result = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(result.Wrap("Làm mới token thành công"));
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            _logger.LogInformation("API GoogleLogin called");
            var result = await _authService.GoogleLoginAsync(request);
            return Ok(result.Wrap("Đăng nhập Google thành công"));
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            _logger.LogInformation("API Logout called");
            await _authService.LogoutAsync(request);
            return Ok(new { }.Wrap("Đăng xuất thành công"));
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            _logger.LogInformation("API VerifyEmail called for email: {Email}", request.Email);
            await _authService.VerifyEmailAsync(request);
            return Ok(new { }.Wrap("Xác nhận email thành công"));
        }

        [HttpPost("resend-verification-email")]
        public async Task<IActionResult> ResendVerificationEmail([FromBody] ResendVerificationEmailRequest request)
        {
            _logger.LogInformation("API ResendVerificationEmail called for email: {Email}", request.Email);
            await _authService.SendVerificationEmailAsync(request.Email);
            return Ok(new { }.Wrap("Gửi email xác nhận thành công"));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            _logger.LogInformation("API ForgotPassword called for email: {Email}", request.Email);
            await _authService.ForgotPasswordAsync(request);
            return Ok(new { }.Wrap("Mã đặt lại mật khẩu đã được gửi đến email"));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            _logger.LogInformation("API ResetPassword called for email: {Email}", request.Email);
            await _authService.ResetPasswordAsync(request);
            return Ok(new { }.Wrap("Đặt lại mật khẩu thành công"));
        }
    }
}
