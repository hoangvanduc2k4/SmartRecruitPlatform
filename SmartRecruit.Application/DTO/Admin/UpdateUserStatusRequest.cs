namespace SmartRecruit.Application.DTO.Admin
{
    public class UpdateUserStatusRequest
    {
        public bool IsActive { get; set; }
        public string? LockReason { get; set; }
    }
}
