using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Job
{
    public record JobUpdateRequest(
          string Title,
         string Company,
         string Benefits,
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
