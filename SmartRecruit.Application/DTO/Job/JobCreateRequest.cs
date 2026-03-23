using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Job
{
    public record JobCreateRequest(
         string Title,
         string Company,
         string Benefits,
         long RecruiterId,
         string Description,
         string Requirement,
         string SkillsRequired,
         decimal SalaryMin,
         decimal SalaryMax,
         JobType JobType,
         string Location,
         long CategoryId
     );
}
