namespace WebPortal.Models
{
    public class Notification
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = "INFO"; // INFO, SUCCESS, ALERT
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
