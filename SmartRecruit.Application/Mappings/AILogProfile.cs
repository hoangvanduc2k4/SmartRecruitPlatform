using AutoMapper;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class AILogProfile : Profile
    {
        public AILogProfile()
        {
            CreateMap<AILog, AILogResponse>();
        }
    }
}
