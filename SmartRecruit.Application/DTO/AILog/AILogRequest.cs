namespace SmartRecruit.Application.DTO.AILog
{
    public record AILogRequest(
        int Page = 1,
        int PageSize = 10
    );
}
