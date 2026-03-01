using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRecruitWeb.Models;
using SmartRecruitWeb.Services;

namespace SmartRecruitWeb.Pages
{
    public class RecruiterJobsModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public RecruiterJobsModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public IList<Job> Jobs { get; set; } = new List<Job>();
        public IList<Application> Applications { get; set; } = new List<Application>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public void OnGet()
        {
            var user = _mockDataService.Users.FirstOrDefault(u => u.Role == UserRole.RECRUITER) ?? _mockDataService.Users.FirstOrDefault();
            if (user != null)
            {
                var query = _mockDataService.Jobs.Where(j => j.RecruiterId == user.Id);
                
                var count = query.Count();
                TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);
                if (CurrentPage < 1) CurrentPage = 1;

                Jobs = query.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                Applications = _mockDataService.Applications.ToList();
            }
        }

        public IActionResult OnPostToggleStatus(string jobId)
        {
            var job = _mockDataService.Jobs.FirstOrDefault(j => j.Id == jobId);
            if (job != null)
            {
                job.Status = job.Status == JobStatus.PUBLISHED ? JobStatus.CLOSED : JobStatus.PUBLISHED;
            }
            return RedirectToPage();
        }
        
        public IActionResult OnPostAppealBlock(string jobId, string message)
        {
            // Just simulate appeal
            return RedirectToPage();
        }
    }
}
