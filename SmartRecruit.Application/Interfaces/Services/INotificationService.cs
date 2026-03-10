using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task<PagedList<NotificationResponse>> GetNotificationsAsync(long userId, NotificationSearchRequest request);
        Task<bool> MarkAsReadAsync(long userId, long notificationId);
        Task<int> GetUnreadCountAsync(long userId);
    }
}
