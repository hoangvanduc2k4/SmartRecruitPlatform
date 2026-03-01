using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRecruitWeb.Models;
using SmartRecruitWeb.Services;

namespace SmartRecruitWeb.Pages
{
    public class JobsModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public JobsModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string LocationFilter { get; set; } = "ALL";

        [BindProperty(SupportsGet = true)]
        public string CategoryFilter { get; set; } = "ALL";

        [BindProperty(SupportsGet = true)]
        public string TypeFilter { get; set; } = "ALL";

        [BindProperty(SupportsGet = true)]
        public int MinSalary { get; set; } = 0;

        public List<string> AvailableLocations { get; set; } = new List<string>();
        public List<string> AvailableCategories { get; set; } = new List<string>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public void OnGet()
        {
            var allJobs = _mockDataService.Jobs;

            AvailableLocations = allJobs.Select(j => j.Location).Distinct().ToList();
            AvailableLocations.Insert(0, "ALL");

            AvailableCategories = allJobs.Select(j => j.Category).Distinct().ToList();
            AvailableCategories.Insert(0, "ALL");

            var query = allJobs.Where(j => j.Status == JobStatus.PUBLISHED).AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(j => j.Title.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase) || 
                                         j.SkillsRequired.Any(s => s.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)));
            }

            if (LocationFilter != "ALL")
            {
                query = query.Where(j => j.Location == LocationFilter);
            }

            if (CategoryFilter != "ALL")
            {
                query = query.Where(j => j.Category == CategoryFilter);
            }

            if (TypeFilter != "ALL" && System.Enum.TryParse<JobType>(TypeFilter, out var parsedType))
            {
                query = query.Where(j => j.JobType == parsedType);
            }

            query = query.Where(j => j.SalaryMax >= MinSalary);

            var count = query.Count();
            TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);
            if (CurrentPage < 1) CurrentPage = 1;

            Jobs = query.OrderByDescending(j => j.IsBoosted)
                        .Skip((CurrentPage - 1) * PageSize)
                        .Take(PageSize)
                        .ToList();
        }
    }
}
