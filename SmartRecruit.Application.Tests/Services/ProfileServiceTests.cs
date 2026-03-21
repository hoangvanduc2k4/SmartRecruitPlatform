using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;

namespace SmartRecruit.Application.Tests.Services
{
    public class ProfileServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<ILogger<ProfileService>> _loggerMock;
        private readonly Mock<ICloudinaryService> _cloudinaryMock;
        private readonly Mock<ICvService> _cvServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly ProfileService _service;

        public ProfileServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<ProfileService>>();
            _cloudinaryMock = new Mock<ICloudinaryService>();
            _cvServiceMock = new Mock<ICvService>();
            _tokenServiceMock = new Mock<ITokenService>();

            _uowMock.Setup(x => x.Users).Returns(new Mock<IUserRepository>().Object);
            _uowMock.Setup(x => x.CandidateProfiles).Returns(new Mock<IGenericRepository<CandidateProfile>>().Object);
            _uowMock.Setup(x => x.CompanyProfiles).Returns(new Mock<IGenericRepository<CompanyProfile>>().Object);

            _service = new ProfileService(
                _uowMock.Object,
                _loggerMock.Object,
                _cloudinaryMock.Object,
                _cvServiceMock.Object,
                _tokenServiceMock.Object);
        }

        [Fact]
        public async Task GetCurrentUserProfileAsync_WhenUserExists_ShouldReturnProfile()
        {
            // Arrange
            var user = new User { Id = 1, Email = "test@example.com", FullName = "Test", Role = SmartRecruit.Domain.Enums.UserRole.CANDIDATE };
            var userRepoMock = new Mock<IUserRepository>();
            userRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(user);
            _uowMock.Setup(x => x.Users).Returns(userRepoMock.Object);

            // Act
            var result = await _service.GetCurrentUserProfileAsync(1);

            // Assert
            result.FullName.Should().Be("Test");
            result.Email.Should().Be("test@example.com");
        }
    }
}
