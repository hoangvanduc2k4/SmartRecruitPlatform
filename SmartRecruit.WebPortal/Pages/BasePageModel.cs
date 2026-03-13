using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public abstract class BasePageModel : PageModel
    {
        private ITokenService? _tokenService;
        protected ITokenService TokenService => _tokenService ??= HttpContext.RequestServices.GetRequiredService<ITokenService>();

        public UserProfileResponse? CurrentUser { get; set; }
        
        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public ClaimsPrincipal? UserPrincipal => TokenService.GetUserPrincipal();

        public long? CurrentUserId
        {
            get
            {
                var principal = UserPrincipal;
                if (principal == null) return null;

                var idClaim = principal.FindFirst("id")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return long.TryParse(idClaim, out var userId) ? userId : null;
            }
        }

        public UserRole? CurrentUserRole
        {
            get
            {
                var principal = UserPrincipal;
                if (principal == null) return null;

                var roleClaim = principal.FindFirst("role")?.Value ?? principal.FindFirst(ClaimTypes.Role)?.Value;
                return Enum.TryParse<UserRole>(roleClaim, true, out var role) ? role : null;
            }
        }

        public bool IsAuthenticated => UserPrincipal != null;
        public bool IsCandidate => CurrentUserRole == UserRole.CANDIDATE;
        public bool IsRecruiter => CurrentUserRole == UserRole.RECRUITER;
        public bool IsAdmin => CurrentUserRole == UserRole.ADMIN;

        protected IActionResult RedirectToAuth() => RedirectToPage("/Account/Auth");
    }
}
