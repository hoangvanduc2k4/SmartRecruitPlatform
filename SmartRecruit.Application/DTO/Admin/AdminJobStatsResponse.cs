namespace SmartRecruit.Application.DTO.Admin
{
    public class AdminJobStatsResponse
    {
        public int TotalJobs { get; set; }
        public int ActiveJobs { get; set; } // Approved or Expiring Soon
        public int PendingJobs { get; set; } // Pending AI or Moderation
        public int BlockedJobs { get; set; }
    }
}
