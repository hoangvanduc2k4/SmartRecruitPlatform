using System;

namespace SmartRecruit.Application.DTO.Admin
{
    public class AppealResponse
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public long RecruiterId { get; set; }
        public string RecruiterName { get; set; } = string.Empty;
        public string AppealMessage { get; set; } = string.Empty;
        public string? AILogReason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
