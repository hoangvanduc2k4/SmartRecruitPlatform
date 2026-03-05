using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class OtpToken : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // e.g. "VerifyEmail", "ForgotPassword"
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
