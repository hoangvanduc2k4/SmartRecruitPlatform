namespace SmartRecruit.Application.DTO.Application
{
    public class ApplicationStatusUpdateDto
    {
        public long ApplicationId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
