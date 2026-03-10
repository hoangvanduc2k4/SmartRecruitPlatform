using System;

namespace SmartRecruit.Application.DTO.Profile
{
    public class UserProfileResponse
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public CandidateProfileDto? CandidateProfile { get; set; }
        public CompanyProfileDto? CompanyProfile { get; set; }
        public string? NewToken { get; set; }
    }
}
