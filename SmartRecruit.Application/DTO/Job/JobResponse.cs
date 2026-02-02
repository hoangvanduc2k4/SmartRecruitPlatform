namespace SmartRecruit.Application.DTO.Job
{
    public record JobResponse(
        long Id,
        string Title,
        string Company,
        string Benefits,
        string Description,
        decimal SalaryMin,
        decimal SalaryMax,
        string Location,
        string JobType,
        DateTime CreatedTime,
        string Category,
        bool IsDeleted
    );
}
