namespace SmartRecruit.Application.DTO.AILog
{
    public record AILogRequest(
        long? JobId = null,
        int Page = 1,
        int PageSize = 10
    );
}
