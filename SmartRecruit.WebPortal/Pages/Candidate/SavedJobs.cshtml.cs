using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Candidate
{
    public class SavedJobsModel : PageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly ITokenService _tokenService;

        public SavedJobsModel(IJobApiService jobApiService, ITokenService tokenService)
        {
            _jobApiService = jobApiService;
            _tokenService = tokenService;
        }

        public List<Job> SavedJobs { get; set; } = new List<Job>();
        public UserDto? CurrentUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        private long? GetCurrentUserId()
        {
            var principal = _tokenService.GetUserPrincipal();
            if (principal == null) return null;

            var idClaim = principal.FindFirst("id")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(idClaim) && long.TryParse(idClaim, out var userId))
            {
                return userId;
            }
            return null;
        }

        private UserRole? GetCurrentUserRole()
        {
            var principal = _tokenService.GetUserPrincipal();
            if (principal == null) return null;

            var roleClaim = principal.FindFirst("role")?.Value ?? principal.FindFirst(ClaimTypes.Role)?.Value;
            if (Enum.TryParse<UserRole>(roleClaim, out var role))
            {
                return role;
            }
            return null;
        }

        public async Task OnGetAsync()
        {
            var userId = GetCurrentUserId();
            var role = GetCurrentUserRole();

            if (userId.HasValue && role.HasValue)
            {
                CurrentUser = new UserDto
                {
                    Id = userId.Value.ToString(),
                    Role = role.Value
                };

                var response = await _jobApiService.GetSavedJobsAsync(userId.Value, CurrentPage, PageSize);
                if (response.Success)
                {
                    SavedJobs = response.Data?.ToList() ?? new List<Job>();
                    TotalPages = response.TotalPages;
                }
            }
        }

        public async Task<IActionResult> OnPostUnsaveAsync(long jobId)
        {
            var userId = GetCurrentUserId();
            if (userId.HasValue)
            {
                await _jobApiService.ToggleSaveJobAsync(jobId, userId.Value);
            }
            return RedirectToPage();
        }
    }
}
