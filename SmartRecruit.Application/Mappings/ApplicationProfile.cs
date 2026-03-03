using AutoMapper;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Domain.Entities;

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
        }
    }
}
