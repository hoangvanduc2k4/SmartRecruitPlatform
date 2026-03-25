using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Job
{
    public record JobResponse(
        long Id,
        long RecruiterId,
        string Title,
        string Company,
        string Benefits,
        string Description,
        decimal SalaryMin,
        decimal SalaryMax,
        string Location,
        long? CategoryId,
        string JobType,
        DateTime CreatedTime,
        string Category,
        bool IsDeleted,
        string Requirement,
        string SkillsRequired,
        JobStatus Status,
        int ViewCount,
        bool IsAppealed,
        string? ModerationNote,
        string? AppealMessage,
        bool IsBoosted,
        string? DraftChanges,
        DateTime? ExpireDate,
        string? CompanyName,
        string? CompanyDescription,
        string? WebsiteUrl,
        string? Address,
        string? LogoUrl
    );
}