namespace SmartRecruit.Application.DTO.AILog
{
    public class AILogRequest
    {
        public long? JobId { get; set; } = null;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
