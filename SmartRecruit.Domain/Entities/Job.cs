using SmartRecruit.Domain.Commons;
using SmartRecruit.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace SmartRecruit.Domain.Entities
{
    public class Job : BaseEntity
    {
        public long RecruiterId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public string SkillsRequired { get; set; } = string.Empty;
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public JobType JobType { get; set; }
        public JobStatus Status { get; set; } = JobStatus.PENDING;
        public int ViewCount { get; set; } = 0;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public virtual User Recruiter { get; set; } = null!;
        public virtual ICollection<Applications> Applications { get; set; } = new List<Applications>();
    }
}