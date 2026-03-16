using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Recruiter
{
    public class AppliedJobsModel : BasePageModel
    {
        private readonly IApplicationApiService _applicationApiService;

        public AppliedJobsModel(IApplicationApiService applicationApiService)
        {
            _applicationApiService = applicationApiService;
        }

        public List<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int? StatusFilter { get; set; }

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!IsRecruiter) return RedirectToPage("/Index");

            if (CurrentUserId.HasValue)
            {
                var response = await _applicationApiService.GetApplicationsAsync(
                    recruiterId: CurrentUserId.Value,
                    status: StatusFilter,
                    page: CurrentPage,
                    pageSize: PageSize
                );
                
                Applications = response.Data?.ToList() ?? new List<Application>();
                TotalPages = response.TotalPages;
            }

            return Page();
        }
    }
}
