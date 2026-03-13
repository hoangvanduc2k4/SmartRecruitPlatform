using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Tests.Unit.Services
{
    public class NotificationServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<INotificationRepository> _notifRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<NotificationService>> _loggerMock;
        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _notifRepoMock = new Mock<INotificationRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<NotificationService>>();

            _uowMock.Setup(u => u.Notifications).Returns(_notifRepoMock.Object);

            _service = new NotificationService(_uowMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task MarkAsReadAsync_ShouldReturnTrue_WhenSuccessful()
        {
            // Arrange
            var userId = 1L;
            var notifId = 10L;
            var notif = new Notification { Id = notifId, UserId = userId, IsRead = false };

            _notifRepoMock.Setup(r => r.GetByIdAsync(notifId)).ReturnsAsync(notif);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.MarkAsReadAsync(userId, notifId);

            // Assert
            result.Should().BeTrue();
            notif.IsRead.Should().BeTrue();
            _notifRepoMock.Verify(r => r.Update(notif), Times.Once);
        }

        [Fact]
        public async Task MarkAsReadAsync_ShouldReturnFalse_WhenNotifNotFound()
        {
            // Arrange
            _notifRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<long>())).ReturnsAsync((Notification)null);

            // Act
            var result = await _service.MarkAsReadAsync(1L, 10L);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task MarkAsReadAsync_ShouldReturnFalse_WhenNotOwner()
        {
            // Arrange
            var userId = 1L;
            var otherUserId = 2L;
            var notifId = 10L;
            var notif = new Notification { Id = notifId, UserId = otherUserId };

            _notifRepoMock.Setup(r => r.GetByIdAsync(notifId)).ReturnsAsync(notif);

            // Act
            var result = await _service.MarkAsReadAsync(userId, notifId);

            // Assert
            result.Should().BeFalse();
        }
    }
}
