namespace WebPortal.Models
{
    public class Job
    {
        public long Id { get; set; }
        public long RecruiterId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public string SkillsRequired { get; set; } = string.Empty;
        public IEnumerable<string> SkillsRequiredList =>
            string.IsNullOrWhiteSpace(SkillsRequired)
                ? Enumerable.Empty<string>()
                : SkillsRequired.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public JobType JobType { get; set; }
        public JobStatus Status { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ExpireDate { get; set; } // Added to fix Index.cshtml build error
        public string Location { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsBoosted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAppealed { get; set; }
        public string? ModerationNote { get; set; }
        public string? DraftChanges { get; set; }
    }
}
