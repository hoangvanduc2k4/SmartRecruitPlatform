using AutoMapper;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<NotificationResponse>> GetNotificationsAsync(long userId, NotificationSearchRequest request)
        {
            var notifications = await _unitOfWork.Notifications.GetUserNotificationsAsync(userId, request);
            return notifications.MapToPagedList<Notification, NotificationResponse>(_mapper);
        }

        public async Task<bool> MarkAsReadAsync(long userId, long notificationId)
        {
            var notification = await _unitOfWork.Notifications.GetByIdAsync(notificationId);
            if (notification == null || notification.UserId != userId)
            {
                return false;
            }

            notification.IsRead = true;
            _unitOfWork.Notifications.Update(notification);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<int> GetUnreadCountAsync(long userId)
        {
            return await _unitOfWork.Notifications.GetUnreadCountAsync(userId);
        }
    }
}
