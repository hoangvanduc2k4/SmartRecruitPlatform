using AutoMapper;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Applications, ApplicationResponse>()
                .ConstructUsing(src => new ApplicationResponse(
                    src.Id,
                    src.JobId,
                    src.Job != null ? src.Job.Title : "Unknown",
                    src.Job != null ? src.Job.Company : "Unknown",
                    src.CandidateId,
                    src.Candidate != null ? src.Candidate.FullName : "Unknown",
                    src.Candidate != null ? src.Candidate.Email : "Unknown",
                    src.MatchScore,
                    src.SkillMatch,
                    src.ExperienceMatch,
                    src.AI_Summary,
                    src.Status.ToString(),
                    src.Notes,
                    src.CreatedAt
                ));

            CreateMap<ApplyJobRequest, Applications>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => ApplicationStatus.REVIEWING))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
