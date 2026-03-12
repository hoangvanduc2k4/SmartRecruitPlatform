using AutoMapper;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace SmartRecruit.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<NotificationService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedList<NotificationResponse>> GetNotificationsAsync(long userId, NotificationSearchRequest request)
        {
            _logger.LogInformation("GetNotifications use-case: Fetching notifications for User {UserId} with Filter: {@Request}", userId, request);
            var notifications = await _unitOfWork.Notifications.GetUserNotificationsAsync(userId, request);
            return notifications.MapToPagedList<Notification, NotificationResponse>(_mapper);
        }

        public async Task<bool> MarkAsReadAsync(long userId, long notificationId)
        {
            _logger.LogInformation("MarkAsRead use-case: Marking notification {NotificationId} as read for User {UserId}", notificationId, userId);
            var notification = await _unitOfWork.Notifications.GetByIdAsync(notificationId);
            if (notification == null || notification.UserId != userId)
            {
                _logger.LogWarning("MarkAsRead failed: Notification {NotificationId} not found or doesn't belong to User {UserId}", notificationId, userId);
                return false;
            }

            notification.IsRead = true;
            _unitOfWork.Notifications.Update(notification);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) _logger.LogInformation("MarkAsRead success: Notification {NotificationId} marked as read", notificationId);
            return result;
        }

        public async Task<int> GetUnreadCountAsync(long userId)
        {
            _logger.LogInformation("GetUnreadCount use-case: Fetching unread count for User {UserId}", userId);
            return await _unitOfWork.Notifications.GetUnreadCountAsync(userId);
        }
    }
}
