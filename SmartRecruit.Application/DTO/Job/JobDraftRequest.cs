using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Job
{
    public class JobDraftRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public string SkillsRequired { get; set; } = string.Empty;
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public JobType JobType { get; set; }
        public string Location { get; set; } = string.Empty;
        public long? CategoryId { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}