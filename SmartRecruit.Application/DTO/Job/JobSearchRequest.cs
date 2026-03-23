namespace SmartRecruit.Application.DTO.Job
{
    public record JobSearchRequest(
            string? keyword,
            decimal? minSalary,
            decimal? maxSalary,
            string? location,
            long? categoryId,
            long? recruiterId,
            int? jobType,
            string? skills,
            int page = 1,
            int pageSize = 10,
            bool showHidden = false,
            bool showBlocked = false,
            string? sortBy = null,
            string? sortOrder = null
        );
}
