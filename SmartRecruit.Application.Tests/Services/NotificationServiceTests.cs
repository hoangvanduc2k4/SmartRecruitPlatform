using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Xunit;

namespace SmartRecruit.Application.Tests.Services
{
    public class NotificationServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<INotificationHubService> _hubMock;
        private readonly Mock<ILogger<NotificationService>> _loggerMock;
        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _hubMock = new Mock<INotificationHubService>();
            _loggerMock = new Mock<ILogger<NotificationService>>();

            _uowMock.Setup(x => x.Notifications).Returns(new Mock<INotificationRepository>().Object);

            _service = new NotificationService(
                _uowMock.Object,
                _mapperMock.Object,
                _hubMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task SendNotificationAsync_ShouldSaveAndPush()
        {
            // Arrange
            var userId = 1L;
            var title = "Test Title";
            var message = "Test Message";
            var type = NotificationType.SYSTEM;
            
            var notificationRepoMock = new Mock<INotificationRepository>();
            _uowMock.Setup(x => x.Notifications).Returns(notificationRepoMock.Object);
            _uowMock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);

            _mapperMock.Setup(x => x.Map<NotificationResponse>(It.IsAny<Notification>()))
                .Returns(new NotificationResponse { Title = title });

            // Act
            await _service.SendNotificationAsync(userId, title, message, type);

            // Assert
            notificationRepoMock.Verify(x => x.AddAsync(It.Is<Notification>(n => n.UserId == userId && n.Title == title)), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
            _hubMock.Verify(x => x.SendNotificationToUserAsync(userId, It.IsAny<NotificationResponse>()), Times.Once);
        }

        [Fact]
        public async Task MarkAsReadAsync_WhenExists_ShouldUpdateStatus()
        {
            // Arrange
            var notificationId = 1L;
            var userId = 1L;
            var notification = new Notification { Id = notificationId, UserId = userId, IsRead = false };
            
            var notificationRepoMock = new Mock<INotificationRepository>();
            notificationRepoMock.Setup(x => x.GetByIdAsync(notificationId)).ReturnsAsync(notification);
            _uowMock.Setup(x => x.Notifications).Returns(notificationRepoMock.Object);
            _uowMock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.MarkAsReadAsync(userId, notificationId);

            // Assert
            result.Should().BeTrue();
            notification.IsRead.Should().BeTrue();
            notificationRepoMock.Verify(x => x.Update(notification), Times.Once);
        }
    }
}
