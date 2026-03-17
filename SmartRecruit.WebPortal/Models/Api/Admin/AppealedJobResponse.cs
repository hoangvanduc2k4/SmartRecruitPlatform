namespace WebPortal.Models.Api.Admin
{
    public class AppealedJobResponse
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public long RecruiterId { get; set; }
        public string RecruiterName { get; set; } = string.Empty;
        public string AppealMessage { get; set; } = string.Empty;
        public string AILogReason { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
