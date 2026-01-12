using SmartRecruit.Domain.Commons;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; } = NotificationType.SYSTEM;
        public string? RedirectUrl { get; set; }
        public bool IsRead { get; set; } = false;

        public virtual User User { get; set; } = null!;
    }
}