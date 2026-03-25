using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Exceptions;
using SmartRecruit.Domain.Constants;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;
using Microsoft.Extensions.Logging;

namespace SmartRecruit.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUnitOfWork unitOfWork, 
            ITokenService tokenService, 
            IConfiguration configuration, 
            IEmailService emailService, 
            IOtpService otpService,
            ILogger<AuthService> logger)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailService = emailService;
            _otpService = otpService;
            _logger = logger;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);

            if (user == null)
            {
                _logger.LogWarning("Login failed for {Email}: Invalid email or password.", request.Email);
                throw new BadRequestException(Messages.AuthMsg.INVALID_CREDENTIALS);
            }

            if (!PasswordUtil.VerifyPassword(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login failed for {Email}: Invalid email or password.", request.Email);
                throw new BadRequestException(Messages.AuthMsg.INVALID_CREDENTIALS);
            }

            if (!user.IsActive)
            {
                _logger.LogWarning("Login failed for {Email}: User is inactive.", request.Email);
                throw new BadRequestException("Tài khoản của bạn đang bị khóa.");
            }

            if (!user.EmailVerified)
            {
                _logger.LogWarning("Login failed for {Email}: Email not verified.", request.Email);
                throw new BadRequestException("Vui lòng xác minh địa chỉ email trước khi đăng nhập.");
            }

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokens.AddAsync(refreshTokenEntity);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Login successful for user: {Email} (UserId: {UserId})", user.Email, user.Id);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed: Email {Email} already exists.", request.Email);
                throw new BadRequestException(Messages.AuthMsg.EMAIL_EXISTS);
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = PasswordUtil.HashPassword(request.Password),
                FullName = request.FullName,
                Role = request.Role,
                IsActive = true,
                AvatarUrl = "https://i.pravatar.cc/150"
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Registration successful: User {Email} created (UserId: {UserId}).", user.Email, user.Id);

            try
            {
                await SendVerificationEmailAsync(user.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send verification email to newly registered user: {Email}", user.Email);
                // Silently fail if email SMTP is not configured properly, but log in prod.
            }
        }

        public async Task<AuthResponse> RefreshTokenAsync(string token)
        {
            var storedToken = await _unitOfWork.RefreshTokens.FindAsync(t => t.Token == token);

            if (storedToken == null)
            {
                _logger.LogWarning("Refresh token failed: Token not found.");
                throw new UnauthorizedException(Messages.AuthMsg.INVALID_TOKEN);
            }

            if (storedToken.IsExpired || storedToken.IsRevoked)
            {
                _logger.LogWarning("Refresh token failed: Token is expired or revoked. (TokenId: {TokenId})", storedToken.Id);
                throw new UnauthorizedException(Messages.AuthMsg.REFRESH_TOKEN_EXPIRED);
            }

            var user = await _unitOfWork.Users.GetByIdAsync(storedToken.UserId);
            if (user == null)
            {
                _logger.LogWarning("Refresh token failed: User not found for UserId {UserId}.", storedToken.UserId);
                throw new NotFoundException("Không tìm thấy người dùng.");
            }

            if (!user.IsActive)
            {
                 _logger.LogWarning("Refresh token failed: User {UserId} is inactive.", user.Id);
                 throw new BadRequestException("Tài khoản đang bị khóa.");
            }

            // Revoke current token
            storedToken.IsRevoked = true;
            _unitOfWork.RefreshTokens.Update(storedToken);

            // Generate new pair
            var newAccessToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokens.AddAsync(refreshTokenEntity);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Refresh token successful for UserId: {UserId}.", user.Id);

            return new AuthResponse
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task<AuthResponse> GoogleLoginAsync(GoogleLoginRequest request)
        {
            var clientId = _configuration["Google:ClientId"];
            if (string.IsNullOrEmpty(clientId))
                throw new BadRequestException("Google ClientId chưa được cấu hình.");

            GoogleJsonWebSignature.Payload payload;
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { clientId }
                };
                payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Mã Google không hợp lệ: {ex.Message}");
            }

            if (payload == null || string.IsNullOrEmpty(payload.Email))
                throw new BadRequestException("Không thể lấy email từ mã Google.");

            var email = payload.Email.ToLowerInvariant();
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == email);

            if (user == null)
            {
                _logger.LogInformation("Google Login: Creating new user for email {Email}", email);
                var randomPassword = Guid.NewGuid().ToString("N").Substring(0, 10) + "Aa1!";
                var passwordHash = PasswordUtil.HashPassword(randomPassword);

                user = new User
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    FullName = string.IsNullOrWhiteSpace(payload.Name) ? email.Split('@')[0] : payload.Name,
                    AvatarUrl = payload.Picture ?? "https://i.pravatar.cc/150",
                    Role = SmartRecruit.Domain.Enums.UserRole.CANDIDATE,
                    IsActive = true,
                    EmailVerified = true
                };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation("Google Login successful: New user created for {Email} (UserId: {UserId})", email, user.Id);
            }
            else
            {
                if (!user.IsActive)
                {
                    _logger.LogWarning("Google Login failed for {Email}: User is inactive.", email);
                    throw new BadRequestException("Tài khoản đang bị khóa.");
                }

                if (!string.IsNullOrEmpty(payload.Picture) && user.AvatarUrl != payload.Picture)
                {
                    user.AvatarUrl = payload.Picture;
                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.CompleteAsync();
                }
                _logger.LogInformation("Google Login successful for existing user: {Email} (UserId: {UserId})", email, user.Id);
            }

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokens.AddAsync(refreshTokenEntity);
            await _unitOfWork.CompleteAsync();

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task LogoutAsync(LogoutRequest request)
        {
            var storedToken = await _unitOfWork.RefreshTokens.FindAsync(t => t.Token == request.RefreshToken);
            if (storedToken == null)
            {
                _logger.LogWarning("Logout failed: Provided refresh token not found.");
                throw new BadRequestException(Messages.AuthMsg.INVALID_TOKEN);
            }

            storedToken.IsRevoked = true;
            _unitOfWork.RefreshTokens.Update(storedToken);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Logout successful: Refresh token revoked for UserId: {UserId}.", storedToken.UserId);
        }

        public async Task SendVerificationEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == email);
            if (user == null)
                throw new NotFoundException("Không tìm thấy người dùng.");

            if (user.EmailVerified)
                throw new BadRequestException("Email đã được xác minh trước đó.");

            if (!await _otpService.CanCreateNewOtpAsync(email, "VerifyEmail"))
                throw new BadRequestException("Vui lòng đợi 2 phút trước khi yêu cầu mã mới.");

            var otpToken = await _otpService.CreateOtpAsync(email, "VerifyEmail");

            string subject = "Xác nhận email - SmartRecruit";
            string body = $"<h1>SmartRecruit</h1><p>Mã xác nhận của bạn là: <strong>{otpToken.Code}</strong></p><p>Mã này sẽ hết hạn sau 15 phút.</p>";
            
            await _emailService.SendHtmlEmailAsync(email, subject, body);
        }

        public async Task VerifyEmailAsync(VerifyEmailRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new NotFoundException("Không tìm thấy người dùng.");
            if (user.EmailVerified)
                throw new BadRequestException("Email đã được xác minh trước đó.");

            var isValid = await _otpService.VerifyOtpAsync(request.Email, request.Code, "VerifyEmail");
            if (!isValid)
            {
                await _otpService.IncrementAttemptCountAsync(request.Email, request.Code, "VerifyEmail");
                throw new BadRequestException("Mã xác nhận không hợp lệ hoặc đã hết hạn.");
            }

            user.EmailVerified = true;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new NotFoundException("Không tìm thấy người dùng.");

            if (!await _otpService.CanCreateNewOtpAsync(request.Email, "ForgotPassword"))
                throw new BadRequestException("Vui lòng đợi 2 phút trước khi yêu cầu mã khôi phục mới.");

            var otpToken = await _otpService.CreateOtpAsync(request.Email, "ForgotPassword");

            string subject = "Đặt lại mật khẩu - SmartRecruit";
            string body = $"<h1>SmartRecruit</h1><p>Mã đặt lại mật khẩu của bạn là: <strong>{otpToken.Code}</strong></p><p>Mã này sẽ hết hạn sau 15 phút.</p>";
            
            await _emailService.SendHtmlEmailAsync(request.Email, subject, body);
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new NotFoundException("Không tìm thấy người dùng.");

            var isValid = await _otpService.VerifyOtpAsync(request.Email, request.Code, "ForgotPassword");
            if (!isValid)
            {
                await _otpService.IncrementAttemptCountAsync(request.Email, request.Code, "ForgotPassword");
                throw new BadRequestException("Mã đặt lại mật khẩu không hợp lệ hoặc đã hết hạn.");
            }

            user.PasswordHash = PasswordUtil.HashPassword(request.NewPassword);

            var activeTokens = await _unitOfWork.RefreshTokens.FindAllAsync(t => t.UserId == user.Id && !t.IsRevoked);
            foreach (var t in activeTokens)
            {
                t.IsRevoked = true;
                _unitOfWork.RefreshTokens.Update(t);
            }

            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
