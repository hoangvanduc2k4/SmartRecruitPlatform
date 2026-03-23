using AutoMapper;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobResponse>()
                .ConstructUsing(src => new JobResponse(
                    src.Id,
                    src.RecruiterId,
                    src.Title,
                    src.Company,
                    src.Benefits,
                    src.Description,
                    src.SalaryMin,
                    src.SalaryMax,
                    src.Location,
                    src.CategoryId,
                    src.JobType.ToString(),
                    src.CreatedAt,
                    src.Category != null ? src.Category.Name : "Unknown",
                    src.IsDeleted,
                    src.Requirement,
                    src.SkillsRequired,
                    src.Status,
                    src.ViewCount,
                    src.IsAppealed,
                    src.ModerationNote,
                    src.AppealMessage,
                    src.BoostExpiryTime != null && src.BoostExpiryTime > DateTime.UtcNow,
                    src.DraftChanges,
                    src.ExpireDate
                ))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Unknown"));
        }
    }
}
