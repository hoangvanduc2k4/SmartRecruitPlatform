using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Admin
{
    public class AdminUserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool EmailVerified { get; set; }
        public string? LockReason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
