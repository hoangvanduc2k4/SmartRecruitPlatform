namespace WebPortal.Models.Api
{
    public class UpdateProfileRequest
    {
        public string FullName { get; set; } = string.Empty;

        // Candidate specific
        public string? Skills { get; set; }
        public int? ExperienceYears { get; set; }
        public decimal? ExpectedSalary { get; set; }

        // Company specific
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Address { get; set; }
    }
}
