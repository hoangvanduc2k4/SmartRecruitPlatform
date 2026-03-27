namespace WebPortal.Models.Api.Admin
{
    public class AdminUserStatsResponse
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int UsersRegisteredToday { get; set; }
    }
}
