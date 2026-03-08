using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
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
                throw new ArgumentException("Invalid email or password.");
            }

            if (!PasswordUtil.VerifyPassword(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login failed for {Email}: Invalid email or password.", request.Email);
                throw new ArgumentException("Invalid email or password.");
            }

            if (!user.IsActive)
            {
                _logger.LogWarning("Login failed for {Email}: User is inactive.", request.Email);
                throw new ArgumentException("User is inactive.");
            }

            if (!user.EmailVerified)
            {
                _logger.LogWarning("Login failed for {Email}: Email not verified.", request.Email);
                throw new ArgumentException("Please verify your email address before logging in.");
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
                throw new ArgumentException("Email already exists.");
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
                throw new ArgumentException("Invalid Token");
            }

            if (storedToken.IsExpired || storedToken.IsRevoked)
            {
                _logger.LogWarning("Refresh token failed: Token is expired or revoked. (TokenId: {TokenId})", storedToken.Id);
                throw new ArgumentException("Token is expired or revoked");
            }

            var user = await _unitOfWork.Users.GetByIdAsync(storedToken.UserId);
            if (user == null)
            {
                _logger.LogWarning("Refresh token failed: User not found for UserId {UserId}.", storedToken.UserId);
                throw new KeyNotFoundException("User not found");
            }

            if (!user.IsActive)
            {
                 _logger.LogWarning("Refresh token failed: User {UserId} is inactive.", user.Id);
                 throw new ArgumentException("User is inactive.");
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
                throw new ArgumentException("Google ClientId is not configured.");

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
                throw new ArgumentException($"Invalid Google token: {ex.Message}");
            }

            if (payload == null || string.IsNullOrEmpty(payload.Email))
                throw new ArgumentException("Cannot extract email from Google token.");

            var email = payload.Email.ToLowerInvariant();
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == email);

            if (user == null)
            {
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
            }
            else
            {
                if (!user.IsActive)
                    throw new ArgumentException("User is inactive.");

                if (!string.IsNullOrEmpty(payload.Picture) && user.AvatarUrl != payload.Picture)
                {
                    user.AvatarUrl = payload.Picture;
                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.CompleteAsync();
                }
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
                throw new ArgumentException("Invalid Token.");
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
                throw new KeyNotFoundException("User not found.");

            if (user.EmailVerified)
                throw new ArgumentException("Email is already verified.");

            if (!await _otpService.CanCreateNewOtpAsync(email, "VerifyEmail"))
                throw new ArgumentException("Please wait 2 minutes before requesting a new verification code.");

            var otpToken = await _otpService.CreateOtpAsync(email, "VerifyEmail");

            string subject = "Verify your email - SmartRecruit";
            string body = $"<h1>SmartRecruit</h1><p>Your email verification code is: <strong>{otpToken.Code}</strong></p><p>This code will expire in 15 minutes.</p>";
            
            await _emailService.SendHtmlEmailAsync(email, subject, body);
        }

        public async Task VerifyEmailAsync(VerifyEmailRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new KeyNotFoundException("User not found.");
            if (user.EmailVerified)
                throw new ArgumentException("Email is already verified.");

            var isValid = await _otpService.VerifyOtpAsync(request.Email, request.Code, "VerifyEmail");
            if (!isValid)
            {
                await _otpService.IncrementAttemptCountAsync(request.Email, request.Code, "VerifyEmail");
                throw new ArgumentException("Invalid or expired verification code.");
            }

            user.EmailVerified = true;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            if (!await _otpService.CanCreateNewOtpAsync(request.Email, "ForgotPassword"))
                throw new ArgumentException("Please wait 2 minutes before requesting a new reset code.");

            var otpToken = await _otpService.CreateOtpAsync(request.Email, "ForgotPassword");

            string subject = "Reset your password - SmartRecruit";
            string body = $"<h1>SmartRecruit</h1><p>Your password reset code is: <strong>{otpToken.Code}</strong></p><p>This code will expire in 15 minutes.</p>";
            
            await _emailService.SendHtmlEmailAsync(request.Email, subject, body);
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            var isValid = await _otpService.VerifyOtpAsync(request.Email, request.Code, "ForgotPassword");
            if (!isValid)
            {
                await _otpService.IncrementAttemptCountAsync(request.Email, request.Code, "ForgotPassword");
                throw new ArgumentException("Invalid or expired reset code.");
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
