using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class JobApplicationsModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public JobApplicationsModel(
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
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalApplicationCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!long.TryParse(Id, out var longId))
            {
                return RedirectToPage("/Jobs/JobDetail");
            }

            Job = await _jobApiService.GetJobByIdAsync(longId.ToString());
            if (Job == null)
            {
                return NotFound();
            }

            var pagedApps = await _applicationApiService.GetApplicationsByJobAsync(longId, CurrentPage, PageSize, true);
            Applications = pagedApps.Data != null ? pagedApps.Data.ToList() : new List<Application>();
            TotalApplicationCount = pagedApps.TotalCount;
            TotalPages = pagedApps.TotalPages;

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long applicationId, ApplicationStatus status, string? rejectionReason)
        {
            var request = new UpdateApplicationStatusRequest { Status = status };

            if (status == ApplicationStatus.INTERVIEWING)
            {
                request.InterviewDate = DateTime.Now.AddDays(1);
            }
            else if (status == ApplicationStatus.REJECTED)
            {
                request.RejectionReason = rejectionReason ?? "Not matching requirements.";
            }

            await _applicationApiService.UpdateStatusAsync(applicationId, request);
            return RedirectToPage(new { Id, CurrentPage });
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
            return RedirectToPage(new { Id, CurrentPage });
        }

        public async Task<IActionResult> OnPostRestoreAsync(long applicationId)
        {
            await _applicationApiService.RestoreStatusAsync(applicationId);
            return RedirectToPage(new { Id, CurrentPage });
        }
    }
}
