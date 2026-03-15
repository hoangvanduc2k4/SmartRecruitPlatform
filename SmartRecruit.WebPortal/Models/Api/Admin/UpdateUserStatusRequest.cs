namespace WebPortal.Models.Api.Admin
{
    public class UpdateUserStatusRequest
    {
        public bool IsActive { get; set; }
        public string? LockReason { get; set; }
    }
}
