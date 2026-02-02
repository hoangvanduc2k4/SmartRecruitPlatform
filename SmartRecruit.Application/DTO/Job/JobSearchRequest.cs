namespace SmartRecruit.Application.DTO.Job
{
    public record JobSearchRequest(
            string? Keyword,
            decimal? MinSalary,
            decimal? MaxSalary,
            string? Location,
            long? CategoryId,
            long? RecruiterId,
            int? JobType,
            string? Skills,
            int Page = 1,
            int PageSize = 10,
            bool ShowHidden = false,
            bool ShowBlocked = false,
            string? SortBy = null,
            string? SortOrder = null
        );
}
