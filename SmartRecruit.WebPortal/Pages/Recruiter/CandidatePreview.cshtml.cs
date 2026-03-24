using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class CandidatePreviewModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;
        private readonly IAuthApiService _authApiService;

        public CandidatePreviewModel(IJobApiService jobApiService, IApplicationApiService applicationApiService, IAuthApiService authApiService)
        {
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
            _authApiService = authApiService;
        }

        public Application? Application { get; set; }
        public Job? Job { get; set; }
        public WebPortal.Models.Api.UserProfileResponse? CandidateProfile { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            Application = await _applicationApiService.GetApplicationByIdAsync(id);
            if (Application != null)
            {
                Job = await _jobApiService.GetJobByIdAsync(Application.JobId.ToString());
                CandidateProfile = await _authApiService.GetProfileAsync(Application.CandidateId);
            }

            if (Application == null || Job == null)
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }

            // Set default ReturnUrl if not provided
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                ReturnUrl = IsRecruiter ? $"/JobApplications?Id={Application.JobId}" : "/Candidate/AppliedJobs";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(long id, string status, DateTime? interviewDate, string? rejectionReason)
        {
            if (System.Enum.TryParse<ApplicationStatus>(status, out var nextStatus))
            {
                var request = new WebPortal.Models.UpdateApplicationStatusRequest 
                { 
                    Status = nextStatus,
                    InterviewDate = interviewDate,
                    RejectionReason = rejectionReason
                };
                
                await _applicationApiService.UpdateStatusAsync(id, request);
            }
            return RedirectToPage(new { id, ReturnUrl });
        }

        public async Task<IActionResult> OnPostAddNoteAsync(long id, string note)
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                await _applicationApiService.AddNoteAsync(id, note);
            }
            return RedirectToPage(new { id, ReturnUrl });
        }

        public async Task<IActionResult> OnPostClearNotesAsync(long id)
        {
            await _applicationApiService.ClearNotesAsync(id);
            return RedirectToPage(new { id, ReturnUrl });
        }

        public async Task<IActionResult> OnPostRestoreAsync(long id)
        {
            var success = await _applicationApiService.RestoreStatusAsync(id);
            if (!success)
            {
                // In a real app we might use TempData for error messages
                // TempData["Error"] = "Unable to restore application status.";
            }
            return RedirectToPage(new { id, ReturnUrl });
        }
    }
}
