using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Candidate
{
    public class SavedJobsModel : PageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IAuthApiService _authApiService;

        public SavedJobsModel(IJobApiService jobApiService, IAuthApiService authApiService)
        {
            _jobApiService = jobApiService;
            _authApiService = authApiService;
        }

        public List<Job> SavedJobs { get; set; } = new List<Job>();
        public UserDto? CurrentUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            CurrentUser = await _authApiService.GetProfileAsync();
            
            // For now, we use the profile ID if available, otherwise a placeholder or empty list
            if (CurrentUser != null && long.TryParse(CurrentUser.Id, out var userId))
            {
                var response = await _jobApiService.GetSavedJobsAsync(userId, CurrentPage, PageSize);
                if (response.Success)
                {
                    SavedJobs = response.Data?.ToList() ?? new List<Job>();
                    TotalPages = response.TotalPages;
                }
            }
        }

        public async Task<IActionResult> OnPostUnsaveAsync(long jobId)
        {
            CurrentUser = await _authApiService.GetProfileAsync();
            if (CurrentUser != null && long.TryParse(CurrentUser.Id, out var userId))
            {
                await _jobApiService.ToggleSaveJobAsync(jobId, userId);
            }
            return RedirectToPage();
        }
    }
}
