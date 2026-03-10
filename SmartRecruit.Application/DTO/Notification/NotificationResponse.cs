using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Notification
{
    public class NotificationResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string? RedirectUrl { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
