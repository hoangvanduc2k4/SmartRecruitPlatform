using SmartRecruit.Domain.Commons;

namespace SmartRecruit.Domain.Entities
{
    public class CandidateProfile : BaseEntity
    {
        public long UserId { get; set; }
        public string? Skills { get; set; }
        public int ExperienceYears { get; set; } = 0;
        public string? CVUrl { get; set; }
        public string? CVText { get; set; }
        public decimal? ExpectedSalary { get; set; }

        public virtual User User { get; set; } = null!;
    }
}