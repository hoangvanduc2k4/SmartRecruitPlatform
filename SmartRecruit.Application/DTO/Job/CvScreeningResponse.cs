using System.Collections.Generic;

namespace SmartRecruit.Application.DTO.Job
{
    public class CvScreeningResponse
    {
        public decimal MatchScore { get; set; }
        public decimal SkillMatch { get; set; }
        public decimal ExperienceMatch { get; set; }
        public string AISummary { get; set; } = string.Empty;
        public List<string> MissingSkills { get; set; } = new();
        public string Recommendation { get; set; } = string.Empty;
    }
}
