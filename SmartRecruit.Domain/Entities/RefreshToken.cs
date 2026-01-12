using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; } = false;
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
        public bool IsActive => !IsRevoked && !IsExpired;
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}