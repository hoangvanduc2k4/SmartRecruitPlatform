namespace WebPortal.Models
{
    public class Job
    {
        public string Id { get; set; } = string.Empty;
        public string RecruiterId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public List<string> SkillsRequired { get; set; } = new List<string>();
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public JobType JobType { get; set; }
        public JobStatus Status { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsBoosted { get; set; }
        public DateTime? BoostExpiresAt { get; set; }
        public string? BlockReason { get; set; }
    }
}
