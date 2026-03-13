using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class JobDetailModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public JobDetailModel(
            IJobApiService jobApiService,
            IApplicationApiService applicationApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
        }

        public Job? Job { get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "DETAILS"; // DETAILS, APPLICANTS, PIPELINE

        [BindProperty]
        public Job EditJob { get; set; } = new Job();

        public UserDto? CurrentUserDto { get; set; }
        public bool IsSaved { get; set; }
        public bool IsOwner { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalApplicationCount { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _jobApiService.GetCategoriesAsync();
            // Populate basic user info from base properties for the view
            if (IsAuthenticated)
            {
                CurrentUserDto = new UserDto
                {
                    Id = CurrentUserId?.ToString() ?? "",
                    Role = CurrentUserRole ?? UserRole.CANDIDATE
                };
            }

            if (long.TryParse(Id, out var longId))
            {
                Job = await _jobApiService.GetJobByIdAsync(longId.ToString());
                if (Job != null)
                {
                    var currentUserId = CurrentUserId;
                    // Check if job is saved
                    if (currentUserId.HasValue)
                    {
                        IsSaved = await _jobApiService.IsJobSavedAsync(longId, currentUserId.Value);
                    }

                    // Only the recruiter who owns this job can edit it
                    if (currentUserId.HasValue)
                    {
                        IsOwner = (CurrentUserRole == UserRole.RECRUITER && Job.RecruiterId == currentUserId.Value);
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
            var currentUserId = CurrentUserId;

            if (!currentUserId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            if (long.TryParse(Id, out var longId))
            {
                try
                {
                    var result = await _jobApiService.ToggleSaveJobAsync(longId, currentUserId.Value);
                    System.Console.WriteLine($"[JobDetail] ToggleSaveAsync result: {result}");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"[JobDetail] Error in ToggleSaveAsync: {ex.Message}");
                }
            }
            return RedirectToPage(new { Id = Id, Tab = Tab });
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long applicationId, ApplicationStatus status, string returnTab = "APPLICANTS")
        {
            var request = new UpdateApplicationStatusRequest { Status = status };

            if (status == ApplicationStatus.INTERVIEWING)
            {
                request.InterviewDate = DateTime.Now.AddDays(1);
            }
            else if (status == ApplicationStatus.REJECTED)
            {
                request.RejectionReason = "Not matching requirements.";
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
            var currentUserId = CurrentUserId;

            if (long.TryParse(Id, out var longId) && currentUserId.HasValue)
            {
                await _jobApiService.BoostJobAsync(longId, currentUserId.Value);
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }

        public async Task<IActionResult> OnPostApplyAsync()
        {
            var currentUserId = CurrentUserId;

            if (long.TryParse(Id, out var longId) && currentUserId.HasValue)
            {
                await _applicationApiService.ApplyAsync(longId, currentUserId.Value);
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            var currentUserId = CurrentUserId;

            if (!currentUserId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            // Ensure Id is populated from the bound EditJob in case it's missing from the query string
            if (EditJob != null && EditJob.Id > 0)
            {
                Id = EditJob.Id.ToString();
            }

            if (long.TryParse(Id, out var longId))
            {
                try
                {
                    System.Console.WriteLine($"[JobDetail] Updating job {longId} with title: {EditJob.Title}");
                    var success = await _jobApiService.UpdateJobAsync(Id, EditJob);
                    System.Console.WriteLine($"[JobDetail] Update job result: {success}");
                    
                    if (success)
                    {
                        // Refresh job data after update
                        Job = await _jobApiService.GetJobByIdAsync(Id);
                        System.Console.WriteLine($"[JobDetail] Job refreshed after update");
                    }
                    else
                    {
                        System.Console.WriteLine($"[JobDetail] Failed to update job");
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"[JobDetail] Exception in OnPostUpdateAsync: {ex}");
                }
            }
            return RedirectToPage(new { Id = Id, Tab = Tab });
        }
    }
}
