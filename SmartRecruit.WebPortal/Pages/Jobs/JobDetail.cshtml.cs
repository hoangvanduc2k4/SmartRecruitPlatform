
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
        public bool HasCV { get; set; }
        public Application? MyApplication { get; set; }
        public CompanyProfileInfo? CompanyProfile { get; set; }

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

                // Fetch full profile for CV check
                var profile = await _authApiService.GetProfileAsync();
                if (profile?.CandidateProfile != null)
                {
                    HasCV = !string.IsNullOrWhiteSpace(profile.CandidateProfile.CVText);
                }
            }

            if (long.TryParse(Id, out var longId))
            {
                // First get the basic job to check ownership
                Job = await _jobApiService.GetJobByIdAsync(longId.ToString());
                if (Job != null)
                {
                    var currentUserId = CurrentUserId;

                    // Ownership check
                    IsOwner = (currentUserId.HasValue && CurrentUserRole == UserRole.RECRUITER && Job.RecruiterId == currentUserId.Value);

                    // If owner, reload with draft changes if they exist
                    if (IsOwner)
                    {
                        var editJob = await _jobApiService.GetJobForEditAsync(longId.ToString());
                        if (editJob != null)
                        {
                            Job = editJob;
                            EditJob = editJob; // Populate for Tag Helpers
                        }
                    }

                    if (currentUserId.HasValue)
                    {
                        IsSaved = await _jobApiService.IsJobSavedAsync(longId, currentUserId.Value);

                        if (CurrentUserRole == UserRole.CANDIDATE)
                        {
                            MyApplication = await _applicationApiService.GetApplicationByJobAndCandidateAsync(longId, currentUserId.Value);
                        }
                    }

                    // CompanyProfile fields are now included in Job response directly

                    // Only the recruiter who owns this job can edit it
                    if (currentUserId.HasValue)
                    {
                        IsOwner = (CurrentUserRole == UserRole.RECRUITER && Job.RecruiterId == currentUserId.Value);
                    }

                    // Fetch applications for this job
                    var pagedApps = await _applicationApiService.GetApplicationsByJobAsync(longId, CurrentPage, PageSize, true);
                    Applications = pagedApps.Data != null ? ((IEnumerable<Application>)pagedApps.Data).ToList() : new List<Application>();
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
                request.RejectionReason = "Không đáp ứng yêu cầu.";

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
                    RejectionReason = "Đã từ chối hàng loạt ứng viên."

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
            if (long.TryParse(Id, out var longId) && IsAuthenticated)
            {
                var result = await _applicationApiService.ApplyAsync(longId, CurrentUserId!.Value);
                if (result.Success) TempData["Message"] = result.Message;
                else TempData["Error"] = result.Message;
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }

        public async Task<IActionResult> OnPostReAnalyzeCVAsync(long applicationId)
        {
            if (IsAuthenticated)
            {
                var result = await _applicationApiService.ReAnalyzeAsync(applicationId);
                if (result.Success) TempData["Message"] = result.Message;
                else TempData["Error"] = result.Message;
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                Tab = "DETAILS";
                Categories = await _jobApiService.GetCategoriesAsync();
                
                // We must reload Model.Job for the view to render parts that depend on it
                // but we DON'T overwrite EditJob because it contains the user's input
                if (long.TryParse(Id, out var longId)) 
                {
                    Job = await _jobApiService.GetJobByIdAsync(Id);
                    if (Job != null)
                    {
                        var userId = CurrentUserId;
                        IsOwner = (userId.HasValue && CurrentUserRole == UserRole.RECRUITER && Job.RecruiterId == userId.Value);
                    }
                }
                
                return Page();
            }

            var currentUserId = CurrentUserId;

            if (!currentUserId.HasValue || (CurrentUserRole != UserRole.RECRUITER && CurrentUserRole != UserRole.ADMIN))
            {
                return RedirectToPage("/Account/Auth");
            }

            if (EditJob != null && EditJob.Id > 0)
            {
                Id = EditJob.Id.ToString();
            }

            if (long.TryParse(Id, out var jobId))
            {
                try
                {
                    // This will now handle draft logic in the backend
                    if (EditJob == null) throw new ArgumentException("Dữ liệu chỉnh sửa không hợp lệ.");
                    var response = await _jobApiService.SaveDraftAsync(Id, EditJob);
                    if (response.Success) 
                    {
                        TempData["Message"] = response.Message;
                        return RedirectToPage(new { Id = Id, Tab = Tab });
                    }
                    
                    TempData["Error"] = response.Errors.Any() 
                        ? "- " + string.Join("<br/>- ", response.Errors) 
                        : response.Message;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"[JobDetail] Exception in OnPostUpdateAsync: {ex}");
                    TempData["Error"] = "Đã xảy ra lỗi khi lưu bản nháp.";
                }
            }

            // If we reach here, it's either an error or non-redirect success path
            // Must reload basic Job state for UI but NOT overwrite EditJob
            if (long.TryParse(Id, out var longIdForReload)) 
            {
                Job = await _jobApiService.GetJobByIdAsync(Id);
                if (Job != null)
                {
                    var userIdReload = CurrentUserId;
                    IsOwner = (userIdReload.HasValue && CurrentUserRole == UserRole.RECRUITER && Job.RecruiterId == userIdReload.Value);
                    Categories = await _jobApiService.GetCategoriesAsync(); // Important for selects
                }
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostPublishAsync()
        {
            if (long.TryParse(Id, out var longId))
            {
                try
                {
                    var response = await _jobApiService.PublishJobAsync(Id);
                    if (response.Success) TempData["Message"] = response.Message;
                    else TempData["Error"] = response.Message;
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Xuất bản thất bại: {ex.Message}";

                }
            }
            return RedirectToPage(new { Id = Id, Tab = "DETAILS" });
        }
    }
}
