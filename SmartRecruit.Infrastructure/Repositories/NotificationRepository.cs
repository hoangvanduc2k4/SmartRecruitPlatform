using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using Microsoft.Extensions.Logging;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NotificationRepository> _logger;

        public NotificationRepository(ApplicationDbContext context, ILogger<NotificationRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<Notification>> GetUserNotificationsAsync(long userId, NotificationSearchRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch notifications for User {UserId} with parameters: {@Request}", userId, request);
            var query = _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .AsQueryable();

            if (request.IsRead.HasValue)
            {
                query = query.Where(n => n.IsRead == request.IsRead.Value);
            }

            return await PagedList<Notification>.CreateAsync(query, request.Page, request.PageSize);
        }

        public async Task<int> GetUnreadCountAsync(long userId)
        {
            _logger.LogTrace("Executing SQL query to get unread count for User {UserId}", userId);
            return await _context.Notifications
                .CountAsync(n => n.UserId == userId && !n.IsRead);
        }
    }
}
