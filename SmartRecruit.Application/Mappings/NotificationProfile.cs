using AutoMapper;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationResponse>();
        }
    }
}
