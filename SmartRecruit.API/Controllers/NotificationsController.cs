
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Notification;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using System.Security.Claims;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : BaseController
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<NotificationsController> _logger;

        public NotificationsController(INotificationService notificationService, ILogger<NotificationsController> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetNotifications([FromQuery] NotificationSearchRequest request)
        {
            var userId = CurrentUserId;
            _logger.LogInformation("Fetching notifications for User: {UserId}", userId);
            var result = await _notificationService.GetNotificationsAsync(userId, request);
            return Ok(result.WrapPaged("Notifications retrieved successfully"));
        }

        [HttpGet("unread-count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API GetUnreadCount called for User: {UserId}", userId);
            var count = await _notificationService.GetUnreadCountAsync(userId);
            return Ok(count.Wrap("Unread count retrieved successfully"));
        }

        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkAsRead(long id)
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API MarkAsRead called for User: {UserId}, NotificationId: {NotificationId}", userId, id);
            var success = await _notificationService.MarkAsReadAsync(userId, id);
            if (!success)
            {
                return BadRequest(new { Success = false }.Wrap("Failed to mark notification as read. It may not exist or doesn't belong to you."));
            }
            return Ok(new { Success = true }.Wrap("Notification marked as read successfully"));
        }
    }
}