using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using System.Linq.Expressions;
using Xunit;

namespace SmartRecruit.Application.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IOtpService> _otpServiceMock;
        private readonly Mock<ILogger<AuthService>> _loggerMock;
        private readonly AuthService _service;

        public AuthServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _tokenServiceMock = new Mock<ITokenService>();
            _configMock = new Mock<IConfiguration>();
            _emailServiceMock = new Mock<IEmailService>();
            _otpServiceMock = new Mock<IOtpService>();
            _loggerMock = new Mock<ILogger<AuthService>>();

            // Setup common UOW defaults
            _uowMock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);
            _uowMock.Setup(x => x.RefreshTokens).Returns(new Mock<IGenericRepository<RefreshToken>>().Object);
            _uowMock.Setup(x => x.Users).Returns(new Mock<IUserRepository>().Object);

            _service = new AuthService(
                _uowMock.Object,
                _tokenServiceMock.Object,
                _configMock.Object,
                _emailServiceMock.Object,
                _otpServiceMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task LoginAsync_WhenValidCredentials_ShouldReturnAuthResponse()
        {
            // Arrange
            var password = "Password123!";
            var user = new User
            {
                Id = 1,
                Email = "test@example.com",
                PasswordHash = PasswordUtil.HashPassword(password),
                IsActive = true,
                EmailVerified = true,
                FullName = "Test User",
                Role = UserRole.CANDIDATE
            };

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
            _uowMock.Setup(x => x.Users).Returns(userRepoMock.Object);

            _tokenServiceMock.Setup(x => x.GenerateJwtToken(user)).Returns("access-token");
            _tokenServiceMock.Setup(x => x.GenerateRefreshToken()).Returns("refresh-token");

            var request = new LoginRequest { Email = user.Email, Password = password };

            // Act
            var result = await _service.LoginAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Token.Should().Be("access-token");
            result.RefreshToken.Should().Be("refresh-token");
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task RegisterAsync_WhenNewEmail_ShouldCreateUser()
        {
            // Arrange
            var request = new RegisterRequest { Email = "new@example.com", Password = "Password123!", FullName = "New User", Role = UserRole.CANDIDATE };
            
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.SetupSequence(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null)
                .ReturnsAsync(new User { Email = request.Email, EmailVerified = false });
            _uowMock.Setup(x => x.Users).Returns(userRepoMock.Object);

            _otpServiceMock.Setup(x => x.CanCreateNewOtpAsync(request.Email, "VerifyEmail")).ReturnsAsync(true);
            _otpServiceMock.Setup(x => x.CreateOtpAsync(request.Email, "VerifyEmail")).ReturnsAsync(new OtpToken { Code = "123456" });

            // Act
            await _service.RegisterAsync(request);

            // Assert
            userRepoMock.Verify(x => x.AddAsync(It.Is<User>(u => u.Email == request.Email)), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
            _emailServiceMock.Verify(x => x.SendHtmlEmailAsync(request.Email, It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task RefreshTokenAsync_WhenValidToken_ShouldIssueNewTokens()
        {
            // Arrange
            var oldToken = "old-refresh-token";
            var refreshToken = new RefreshToken { Token = oldToken, UserId = 1, IsRevoked = false, ExpiryDate = DateTime.UtcNow.AddDays(1) };
            var user = new User { Id = 1, IsActive = true };

            var tokenRepoMock = new Mock<IGenericRepository<RefreshToken>>();
            tokenRepoMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<RefreshToken, bool>>>())).ReturnsAsync(refreshToken);
            _uowMock.Setup(x => x.RefreshTokens).Returns(tokenRepoMock.Object);

            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(user);
            _uowMock.Setup(x => x.Users).Returns(userRepoMock.Object);

            _tokenServiceMock.Setup(x => x.GenerateJwtToken(user)).Returns("new-access");
            _tokenServiceMock.Setup(x => x.GenerateRefreshToken()).Returns("new-refresh");

            // Act
            var result = await _service.RefreshTokenAsync(oldToken);

            // Assert
            result.Token.Should().Be("new-access");
            refreshToken.IsRevoked.Should().BeTrue();
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }
    }
}
