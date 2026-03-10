using AutoMapper;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<User, AdminUserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
