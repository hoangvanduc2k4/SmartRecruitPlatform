using Microsoft.AspNetCore.Mvc;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Candidate
{
    public class AppliedJobsModel : BasePageModel
    {
        private readonly IApplicationApiService _applicationApiService;

        public AppliedJobsModel(IApplicationApiService applicationApiService)
        {
            _applicationApiService = applicationApiService;
        }

        public List<Application> AppliedJobs { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            if (IsAuthenticated && CurrentUserId.HasValue)
            {
                var response = await _applicationApiService.GetApplicationsByCandidateAsync(CurrentUserId.Value, CurrentPage, PageSize);
                AppliedJobs = response.Data?.ToList() ?? new List<Application>();
                TotalPages = response.TotalPages;
            }
        }
    }
}
