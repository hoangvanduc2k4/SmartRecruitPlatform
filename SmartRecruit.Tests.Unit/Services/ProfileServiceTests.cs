using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class ProfileServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<ILogger<ProfileService>> _loggerMock;
        private readonly Mock<ICloudinaryService> _cloudinaryMock;
        private readonly Mock<ICvService> _cvServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IGenericRepository<CandidateProfile>> _candidateProfileRepoMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly ProfileService _service;

        public ProfileServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<ProfileService>>();
            _cloudinaryMock = new Mock<ICloudinaryService>();
            _cvServiceMock = new Mock<ICvService>();
            _tokenServiceMock = new Mock<ITokenService>();
            _candidateProfileRepoMock = new Mock<IGenericRepository<CandidateProfile>>();
            _userRepoMock = new Mock<IUserRepository>();

            _uowMock.Setup(u => u.CandidateProfiles).Returns(_candidateProfileRepoMock.Object);
            _uowMock.Setup(u => u.Users).Returns(_userRepoMock.Object);

            _service = new ProfileService(
                _uowMock.Object,
                _loggerMock.Object,
                _cloudinaryMock.Object,
                _cvServiceMock.Object,
                _tokenServiceMock.Object
            );
        }

        [Fact]
        public async Task UploadCvAsync_ShouldThrowArgumentException_WhenExtensionIsInvalid()
        {
            // Arrange
            var userId = 1L;
            var user = new User { Id = userId, Role = UserRole.CANDIDATE };
            _userRepoMock.Setup(u => u.GetByIdAsync(userId)).ReturnsAsync(user);

            var stream = new MemoryStream(new byte[100]);
            var fileName = "myresume.docx"; // Invalid, only .pdf allowed

            // Act
            Func<Task> act = async () => await _service.UploadCvAsync(userId, stream, fileName);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Only PDF format is supported*");
        }

        [Fact]
        public async Task UploadAvatarAsync_ShouldThrowArgumentException_WhenFileSizeExceedsLimit()
        {
            // Arrange
            var userId = 1L;
            var user = new User { Id = userId };
            _userRepoMock.Setup(u => u.GetByIdAsync(userId)).ReturnsAsync(user);

            // Create a stream larger than 5MB
            var largeBuffer = new byte[6 * 1024 * 1024]; 
            var stream = new MemoryStream(largeBuffer);
            var fileName = "photo.jpg";

            // Act
            Func<Task> act = async () => await _service.UploadAvatarAsync(userId, stream, fileName);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Avatar file size must be <= 5MB.");
        }

        [Fact]
        public async Task UpdateUserProfileAsync_ShouldReturnSuccess_WithNewToken()
        {
            // Arrange
            var userId = 1L;
            var user = new User { Id = userId, FullName = "Old Name" };
            var request = new UpdateProfileRequest { FullName = "New Name" };

            _userRepoMock.Setup(u => u.GetByIdAsync(userId)).ReturnsAsync(user);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);
            _tokenServiceMock.Setup(t => t.GenerateJwtToken(user)).Returns("new-jwt-token");

            // Act
            var result = await _service.UpdateUserProfileAsync(userId, request);

            // Assert
            result.Should().NotBeNull();
            result.NewToken.Should().Be("new-jwt-token");
            user.FullName.Should().Be("New Name");
            _uowMock.Verify(u => u.CompleteAsync(), Times.AtLeastOnce);
        }

        [Fact]
        public async Task GetCurrentUserProfileAsync_ShouldThrowKeyNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _userRepoMock.Setup(u => u.GetByIdAsync(It.IsAny<long>())).ReturnsAsync((User)null);

            // Act
            Func<Task> act = async () => await _service.GetCurrentUserProfileAsync(999);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
