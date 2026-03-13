using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Candidate
{
    public class SavedJobsModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;

        public SavedJobsModel(IJobApiService jobApiService)
        {
            _jobApiService = jobApiService;
        }

        public List<Job> SavedJobs { get; set; } = new List<Job>();
        public UserDto? CurrentUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;


        public async Task OnGetAsync()
        {
            if (IsAuthenticated)
            {
                CurrentUser = new UserDto
                {
                    Id = CurrentUserId.Value.ToString(),
                    Role = CurrentUserRole.Value
                };

                var response = await _jobApiService.GetSavedJobsAsync(CurrentUserId.Value, CurrentPage, PageSize);
                if (response.Success)
                {
                    SavedJobs = response.Data?.ToList() ?? new List<Job>();
                    TotalPages = response.TotalPages;
                }
            }
        }

        public async Task<IActionResult> OnPostUnsaveAsync(long jobId)
        {
            if (CurrentUserId.HasValue)
            {
                await _jobApiService.ToggleSaveJobAsync(jobId, CurrentUserId.Value);
            }
            return RedirectToPage();
        }
    }
}
