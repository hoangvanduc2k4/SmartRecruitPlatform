using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class RecruiterJobsModel : PageModel
    {
        private readonly IAuthApiService _authApiService;
        private readonly IJobApiService _jobApiService;
        private readonly IApplicationApiService _applicationApiService;

        public RecruiterJobsModel(IAuthApiService authApiService, IJobApiService jobApiService, IApplicationApiService applicationApiService)
        {
            _authApiService = authApiService;
            _jobApiService = jobApiService;
            _applicationApiService = applicationApiService;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();
        public IList<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public async Task OnGetAsync()
        {
            var user = await _authApiService.GetProfileAsync();
            if (user != null)
            {
                var response = await _jobApiService.GetJobsByRecruiterAsync(1, CurrentPage, PageSize);
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

        public IActionResult OnPostAppealBlock(long jobId, string message)
        {
            // Just simulate appeal
            return RedirectToPage();
        }
    }
}
