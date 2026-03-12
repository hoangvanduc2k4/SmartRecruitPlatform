using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartRecruit.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long CurrentUserId
        {
            get
            {
                var userIdClaim = User.FindFirst("id")?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out var userId))
                {
                    throw new UnauthorizedAccessException("Invalid token user ID.");
                }
                return userId;
            }
        }

        protected SmartRecruit.Domain.Enums.UserRole CurrentUserRole
        {
            get
            {
                var roleClaim = User.FindFirst(ClaimTypes.Role)?.Value;
                if (Enum.TryParse<SmartRecruit.Domain.Enums.UserRole>(roleClaim, true, out var role))
                {
                    return role;
                }
                throw new UnauthorizedAccessException("Role claim is missing or invalid.");
            }
        }

        protected string CurrentUserEmail
        {
            get
            {
                var emailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(emailClaim))
                {
                    throw new UnauthorizedAccessException("Email claim is missing.");
                }
                return emailClaim;
            }
        }
    }
}