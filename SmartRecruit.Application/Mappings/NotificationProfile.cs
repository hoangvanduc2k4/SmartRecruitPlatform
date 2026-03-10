using AutoMapper;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        }
    }
}
