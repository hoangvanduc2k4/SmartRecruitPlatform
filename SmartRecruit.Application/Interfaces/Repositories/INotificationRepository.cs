using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<PagedList<Notification>> GetUserNotificationsAsync(long userId, NotificationSearchRequest request);
        Task<int> GetUnreadCountAsync(long userId);
    }
}
