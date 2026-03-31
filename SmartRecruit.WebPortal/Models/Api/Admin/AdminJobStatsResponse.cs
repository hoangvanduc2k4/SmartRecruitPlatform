namespace WebPortal.Models.Api.Admin
{
    public class AdminJobStatsResponse
    {
        public int TotalJobs { get; set; }
        public int ActiveJobs { get; set; }
        public int PendingJobs { get; set; }
        public int BlockedJobs { get; set; }
    }
}
