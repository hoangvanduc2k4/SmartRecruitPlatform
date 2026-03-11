namespace SmartRecruit.Application.DTO.Notification
{
    public class NotificationSearchRequest
    {
        public bool? IsRead { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
