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
    }
}