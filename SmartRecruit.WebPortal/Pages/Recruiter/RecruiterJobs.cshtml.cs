using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class RecruiterJobsModel : PageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;
        private readonly ITokenService _tokenService;

        public RecruiterJobsModel(IJobApiService jobApiService, IApplicationApiService applicationApiService, ITokenService tokenService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
            _tokenService = tokenService;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();
        public IList<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

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

        public async Task OnGetAsync()
        {
            var recruiterId = GetCurrentUserId();
            if (recruiterId.HasValue)
            {
                var response = await _jobApiService.GetJobsByRecruiterAsync(recruiterId.Value, CurrentPage, PageSize);
                if (response.Success && response.Data != null)
                {
                    Jobs = response.Data.ToList();
                    TotalPages = response.TotalPages;

                    foreach (var job in Jobs)
                    {
                        var appsResponse = await _applicationApiService.GetApplicationsByJobAsync(job.Id, 1, 100);
                        if (appsResponse.Success && appsResponse.Data != null)
                        {
                            foreach (var app in appsResponse.Data)
                            {
                                Applications.Add(app);
                            }
                        }
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostToggleStatusAsync(long jobId)
        {
            await _jobApiService.ToggleVisibilityAsync(jobId.ToString());
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(long jobId)
        {
            await _jobApiService.DeleteJobAsync(jobId.ToString());
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAppealBlockAsync(long jobId, string message)
        {
            await _jobApiService.AppealJobAsync(jobId, message);
            return RedirectToPage();
        }
    }
}
