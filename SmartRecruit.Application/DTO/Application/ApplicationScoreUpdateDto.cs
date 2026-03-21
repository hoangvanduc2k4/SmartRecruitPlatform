using System;

namespace SmartRecruit.Application.DTO.Application
{
    public class ApplicationScoreUpdateDto
    {
        public long JobId { get; set; }
        public decimal MatchScore { get; set; }
        public decimal SkillMatch { get; set; }
        public decimal ExperienceMatch { get; set; }
        public string? AI_Summary { get; set; }
    }
}
