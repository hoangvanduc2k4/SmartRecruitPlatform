namespace SmartRecruit.Application.DTO.Application
{
    public record GetApplicationsByJobRequest(
        int Page = 1,
        int PageSize = 10,
        bool SortByScore = false
    );
}
