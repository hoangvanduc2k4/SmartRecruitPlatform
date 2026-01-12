using SmartRecruit.Domain.Commons;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Domain.Entities
{
    public class Applications : BaseEntity
    {
        public long JobId { get; set; }
        public long CandidateId { get; set; }
        public decimal MatchScore { get; set; } = 0;
        public decimal SkillMatch { get; set; } = 0;
        public decimal ExperienceMatch { get; set; } = 0;
        public string? AI_Summary { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.APPLIED;
        public string? Notes { get; set; }

        public virtual Job Job { get; set; } = null!;
        public virtual User Candidate { get; set; } = null!;
    }
}