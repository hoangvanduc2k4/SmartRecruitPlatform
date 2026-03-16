namespace WebPortal.Models.Api
{
    public class UserProfileResponse
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public CandidateProfileInfo? CandidateProfile { get; set; }
        public CompanyProfileInfo? CompanyProfile { get; set; }
        public string? NewToken { get; set; }
    }

    public class CandidateProfileInfo
    {
        public string? Skills { get; set; }
        public int ExperienceYears { get; set; }
        public string? CVUrl { get; set; }
        public string? CVText { get; set; }
        public decimal? ExpectedSalary { get; set; }
    }

    public class CompanyProfileInfo
    {
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Address { get; set; }
        public string? LogoUrl { get; set; }
    }
}
