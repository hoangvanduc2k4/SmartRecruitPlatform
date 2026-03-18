namespace SmartRecruit.Application.DTO.Application
{
    public record GetApplicationsByCandidateRequest(
        int Page = 1,
        int PageSize = 10
    );
}
