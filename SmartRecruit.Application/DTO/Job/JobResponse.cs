using SmartRecruit.Domain.Enums;

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
        bool IsDeleted,
        string Requirement,
        string SkillsRequired,
        JobStatus Status,
        int ViewCount,
        bool IsAppealed,
        string? ModerationNote
    );
}
