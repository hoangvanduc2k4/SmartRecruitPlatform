namespace SmartRecruit.Application.DTO.Profile
{
    public class CandidateProfileDto
    {
        public string? Skills { get; set; }
        public int ExperienceYears { get; set; } = 0;
        public string? CVUrl { get; set; }
        public decimal? ExpectedSalary { get; set; }
    }
}
