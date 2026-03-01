namespace WebPortal.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public decimal WalletBalance { get; set; }
        public string AvatarUrl { get; set; } = string.Empty;
        public bool IsVip { get; set; }
        public bool IsLocked { get; set; }
    }
}
