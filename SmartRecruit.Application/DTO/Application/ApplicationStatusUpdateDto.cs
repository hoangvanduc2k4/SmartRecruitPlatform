namespace SmartRecruit.Application.DTO.Application
{
    public class ApplicationStatusUpdateDto
    {
        public long ApplicationId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
