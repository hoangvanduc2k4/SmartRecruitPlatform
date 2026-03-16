using SmartRecruit.Application.DTO.Notification;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface INotificationHubService
    {
        Task SendNotificationToUserAsync(long userId, NotificationResponse notification);
    }
}
