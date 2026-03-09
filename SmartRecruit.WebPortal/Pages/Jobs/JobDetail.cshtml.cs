using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class JobDetailModel : PageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;
        private readonly IAuthApiService _authApiService;

        public JobDetailModel(
            IJobApiService jobApiService,
            IApplicationApiService applicationApiService,
            IAuthApiService authApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
            _authApiService = authApiService;
        }

        public Job? Job { get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "DETAILS"; // DETAILS, APPLICANTS, PIPELINE

        public UserDto? CurrentUser { get; set; }
        public bool IsSaved { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalApplicationCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch Current User Profile
            CurrentUser = await _authApiService.GetProfileAsync();

            if (long.TryParse(Id, out var longId))
            {
                Job = await _jobApiService.GetJobByIdAsync(longId.ToString());
                if (Job != null)
                {
                    // Check if job is saved
                    if (CurrentUser != null && long.TryParse(CurrentUser.Id, out var userId))
                    {
                        IsSaved = await _jobApiService.IsJobSavedAsync(longId, userId);
                    }

                    // Fetch applications for this job
                    var pagedApps = await _applicationApiService.GetApplicationsByJobAsync(longId, CurrentPage, PageSize, true);
                    Applications = (List<Application>)pagedApps.Data;
                    TotalApplicationCount = pagedApps.TotalCount;
                    TotalPages = pagedApps.TotalPages;
                }
                else
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostToggleSaveAsync()
        {
            CurrentUser = await _authApiService.GetProfileAsync();
            if (CurrentUser == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (long.TryParse(Id, out var longId) && long.TryParse(CurrentUser.Id, out var userId))
            {
                await _jobApiService.ToggleSaveJobAsync(longId, userId);
            }
            return RedirectToPage(new { Id = Id, Tab = Tab });
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long applicationId, ApplicationStatus status, string returnTab = "APPLICANTS")
        {
            var request = new UpdateApplicationStatusRequest { Status = status };

            // Special handling for mandatory fields in backend
            if (status == ApplicationStatus.INTERVIEWING)
            {
                request.InterviewDate = DateTime.Now.AddDays(1); // Default for demo
            }
            else if (status == ApplicationStatus.REJECTED)
            {
                request.RejectionReason = "Not matching requirements."; // Default for demo
            }

            await _applicationApiService.UpdateStatusAsync(applicationId, request);
            return RedirectToPage(new { Id = Id, Tab = returnTab });
        }

        public async Task<IActionResult> OnPostBulkRejectAsync(List<long> selectedApplications)
        {
            if (selectedApplications != null && selectedApplications.Any())
            {
                var request = new BulkUpdateApplicationStatusRequest
                {
                    ApplicationIds = selectedApplications,
                    Status = ApplicationStatus.REJECTED,
                    RejectionReason = "Bulk Rejection"
                };
                await _applicationApiService.BulkUpdateStatusAsync(request);
            }
            return RedirectToPage(new { Id = Id, Tab = "APPLICANTS" });
        }

        public async Task<IActionResult> OnPostBoostAsync()
        {
            CurrentUser = await _authApiService.GetProfileAsync();
            if (long.TryParse(Id, out var longId) && CurrentUser != null && long.TryParse(CurrentUser.Id, out var userId))
            {
                await _jobApiService.BoostJobAsync(longId, userId);
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }

        public async Task<IActionResult> OnPostApplyAsync()
        {
            CurrentUser = await _authApiService.GetProfileAsync();
            if (long.TryParse(Id, out var longId) && CurrentUser != null && long.TryParse(CurrentUser.Id, out var userId))
            {
                await _applicationApiService.ApplyAsync(longId, userId);
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }
    }
}
