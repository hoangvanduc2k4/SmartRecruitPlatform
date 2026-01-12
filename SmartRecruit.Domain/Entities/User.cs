using SmartRecruit.Domain.Commons;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = "https://i.pravatar.cc/150";
        public UserRole Role { get; set; } = UserRole.CANDIDATE;
        public bool IsVip { get; set; } = false;
        public DateTime? LastLoginAt { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public virtual CandidateProfile? CandidateProfile { get; set; }
        public virtual Wallet? Wallet { get; set; }
        public virtual ICollection<Job> JobsPosted { get; set; } = new List<Job>();
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}