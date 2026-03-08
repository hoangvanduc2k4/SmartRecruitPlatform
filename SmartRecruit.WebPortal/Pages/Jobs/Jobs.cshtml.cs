using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class JobsModel : PageModel
    {
        private readonly IJobApiService _jobApiService;

        public JobsModel(IJobApiService jobApiService)
        {
            _jobApiService = jobApiService;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string LocationFilter { get; set; } = "ALL";

        [BindProperty(SupportsGet = true)]
        public long? CategoryFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TypeFilter { get; set; } = "ALL";

        [BindProperty(SupportsGet = true)]
        public int MinSalary { get; set; } = 0;

        [BindProperty(SupportsGet = true)]
        public int? MaxSalary { get; set; }

        public List<string> AvailableLocations { get; set; } = new List<string>();
        public List<Category> Categories { get; set; } = new List<Category>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 6;

        public async Task OnGetAsync()
        {
            Categories = (await _jobApiService.GetCategoriesAsync()).ToList();
            var locations = await _jobApiService.GetLocationsAsync();
            AvailableLocations = new List<string> { "ALL" };
            AvailableLocations.AddRange(locations);

            JobType? parsedType = null;
            if (!string.IsNullOrEmpty(TypeFilter) && TypeFilter != "ALL")
            {
                if (System.Enum.TryParse<JobType>(TypeFilter, out var t))
                {
                    parsedType = t;
                }
            }

            var response = await _jobApiService.GetJobsAsync(
                SearchTerm,
                LocationFilter,
                CategoryFilter,
                parsedType,
                MinSalary,
                MaxSalary,
                CurrentPage,
                PageSize
            );

            if (response.Success && response.Data != null)
            {
                Jobs = response.Data.ToList();
                TotalPages = response.TotalPages;
                CurrentPage = response.Page;
            }
            else
            {
                Jobs = new List<Job>();
                TotalPages = 0;
            }
        }
    }
}
