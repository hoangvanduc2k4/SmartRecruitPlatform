using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;

namespace SmartRecruit.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }

            if (!PasswordUtil.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            if (!user.IsActive)
            {
                throw new Exception("User is inactive.");
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

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
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

        public async Task<AuthResponse> RefreshTokenAsync(string token)
        {
            var storedToken = await _unitOfWork.RefreshTokens.FindAsync(t => t.Token == token);

            if (storedToken == null)
            {
                throw new Exception("Invalid Token");
            }

            if (storedToken.IsExpired || storedToken.IsRevoked)
            {
                throw new Exception("Token is expired or revoked");
            }

            var user = await _unitOfWork.Users.GetByIdAsync(storedToken.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!user.IsActive)
            {
                 throw new Exception("User is inactive.");
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
                throw new Exception("Google ClientId is not configured.");

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
                throw new Exception($"Invalid Google token: {ex.Message}");
            }

            if (payload == null || string.IsNullOrEmpty(payload.Email))
                throw new Exception("Cannot extract email from Google token.");

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
                    IsActive = true
                };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                if (!user.IsActive)
                    throw new Exception("User is inactive.");

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
    }
}
