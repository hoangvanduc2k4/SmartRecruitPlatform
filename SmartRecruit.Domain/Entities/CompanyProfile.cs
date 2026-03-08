using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class CompanyProfile : BaseEntity
    {
        public long UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Address { get; set; }
        public string? LogoUrl { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
