using AutoMapper;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;

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
                    src.ExpireDate,
                    src.Recruiter != null && src.Recruiter.CompanyProfile != null ? src.Recruiter.CompanyProfile.CompanyName : null,
                    src.Recruiter != null && src.Recruiter.CompanyProfile != null ? src.Recruiter.CompanyProfile.CompanyDescription : null,
                    src.Recruiter != null && src.Recruiter.CompanyProfile != null ? src.Recruiter.CompanyProfile.WebsiteUrl : null,
                    src.Recruiter != null && src.Recruiter.CompanyProfile != null ? src.Recruiter.CompanyProfile.Address : null,
                    src.Recruiter != null && src.Recruiter.CompanyProfile != null ? src.Recruiter.CompanyProfile.LogoUrl : null
                ))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Unknown"));

            CreateMap<JobCreateRequest, Job>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => JobStatus.DRAFT))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(_ => 0))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId ?? 0));

            CreateMap<JobDraftRequest, Job>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId ?? 0))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
