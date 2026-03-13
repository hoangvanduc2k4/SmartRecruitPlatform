using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<UserService>> _loggerMock;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _userRepoMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<UserService>>();

            _uowMock.Setup(u => u.Users).Returns(_userRepoMock.Object);

            _service = new UserService(_uowMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task UpdateUserStatusAsync_ShouldSucceed()
        {
            // Arrange
            var userId = 1L;
            var user = new User { Id = userId, IsActive = true };
            var request = new UpdateUserStatusRequest { IsActive = false, LockReason = "Bad behavior" };

            _userRepoMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.UpdateUserStatusAsync(userId, request);

            // Assert
            result.Should().BeTrue();
            user.IsActive.Should().BeFalse();
            user.LockReason.Should().Be("Bad behavior");
            _userRepoMock.Verify(r => r.Update(user), Times.Once);
        }

        [Fact]
        public async Task UpdateUserStatusAsync_ShouldThrow_WhenUserNotFound()
        {
            // Arrange
            _userRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<long>())).ReturnsAsync((User)null);

            // Act
            Func<Task> act = async () => await _service.UpdateUserStatusAsync(1L, new UpdateUserStatusRequest());

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
