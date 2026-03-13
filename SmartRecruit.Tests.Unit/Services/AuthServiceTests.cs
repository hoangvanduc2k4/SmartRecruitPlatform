using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Enums;
using System.Linq.Expressions;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<ILogger<AuthService>> _loggerMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IOtpService> _otpServiceMock;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _tokenServiceMock = new Mock<ITokenService>();
            _loggerMock = new Mock<ILogger<AuthService>>();
            _configMock = new Mock<IConfiguration>();
            _emailServiceMock = new Mock<IEmailService>();
            _otpServiceMock = new Mock<IOtpService>();

            _authService = new AuthService(
                _unitOfWorkMock.Object,
                _tokenServiceMock.Object,
                _configMock.Object,
                _emailServiceMock.Object,
                _otpServiceMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowArgumentException_WhenPasswordIsIncorrect()
        {
            // Arrange
            var request = new LoginRequest { Email = "test@example.com", Password = "wrongpassword" };
            var user = new User 
            { 
                Email = "test@example.com", 
                PasswordHash = PasswordUtil.HashPassword("correctpassword"),
                IsActive = true,
                EmailVerified = true
            };

            _unitOfWorkMock.Setup(u => u.Users.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            Func<Task> act = async () => await _authService.LoginAsync(request);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Invalid email or password.");
        }

        [Fact]
        public async Task LoginAsync_ShouldThrowArgumentException_WhenUserIsInactive()
        {
            // Arrange
            var request = new LoginRequest { Email = "test@example.com", Password = "password" };
            var user = new User 
            { 
                Email = "test@example.com", 
                PasswordHash = PasswordUtil.HashPassword("password"),
                IsActive = false,
                EmailVerified = true
            };

            _unitOfWorkMock.Setup(u => u.Users.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            Func<Task> act = async () => await _authService.LoginAsync(request);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("User is inactive.");
        }

        [Fact]
        public async Task RegisterAsync_ShouldThrowArgumentException_WhenEmailExists()
        {
            // Arrange
            var request = new RegisterRequest { Email = "existing@example.com" };
            _unitOfWorkMock.Setup(u => u.Users.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(new User());

            // Act
            Func<Task> act = async () => await _authService.RegisterAsync(request);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Email already exists.");
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldThrowUnauthorized_WhenTokenNotFound()
        {
            // Arrange
            string invalidToken = "invalid-token";
            _unitOfWorkMock.Setup(u => u.RefreshTokens.FindAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync((RefreshToken)null);

            // Act
            Func<Task> act = async () => await _authService.RefreshTokenAsync(invalidToken);

            // Assert
            await act.Should().ThrowAsync<UnauthorizedAccessException>().WithMessage("Invalid Token");
        }

        [Fact]
        public async Task RefreshTokenAsync_ShouldThrowUnauthorized_WhenTokenIsExpired()
        {
            // Arrange
            string expiredToken = "expired-token";
            var refreshToken = new RefreshToken
            {
                Token = expiredToken,
                ExpiryDate = DateTime.UtcNow.AddMinutes(-5), // Expired
                IsRevoked = false
            };

            _unitOfWorkMock.Setup(u => u.RefreshTokens.FindAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>()))
                .ReturnsAsync(refreshToken);

            // Act
            Func<Task> act = async () => await _authService.RefreshTokenAsync(expiredToken);

            // Assert
            await act.Should().ThrowAsync<UnauthorizedAccessException>().WithMessage("Token is expired or revoked");
        }
    }
}
