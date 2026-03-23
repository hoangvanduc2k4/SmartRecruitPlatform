using Microsoft.AspNetCore.SignalR;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Hubs;

namespace SmartRecruit.Infrastructure.Services
{
    public class NotificationHubService : INotificationHubService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHubService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationToUserAsync(long userId, NotificationResponse notification)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveNotification", notification);
        }

        public async Task SendApplicationScoreUpdateAsync(long userId, SmartRecruit.Application.DTO.Application.ApplicationScoreUpdateDto update)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveApplicationScoreUpdate", update);
        }

        public async Task SendApplicationStatusUpdateAsync(long userId, SmartRecruit.Application.DTO.Application.ApplicationStatusUpdateDto update)
        {
            await _hubContext.Clients.Group($"User_{userId}").SendAsync("ReceiveApplicationStatusUpdate", update);
        }
    }
}
