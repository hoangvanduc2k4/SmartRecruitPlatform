using System.Collections.Generic;

namespace SmartRecruit.Application.DTO.Job
{
    public class CvScreeningResponse
    {
        public decimal MatchScore { get; set; }
        public decimal SkillMatch { get; set; }
        public decimal ExperienceMatch { get; set; }
        public string AI_Summary { get; set; }
        public List<string> MissingSkills { get; set; }
        public string Recommendation { get; set; }
    }
}
