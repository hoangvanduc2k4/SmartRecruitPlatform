using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class PostJobModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public PostJobModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        [BindProperty]
        public Job JobInput { get; set; } = new Job
        {
            JobType = JobType.FULL_TIME,
            Category = "Software Development",
            SalaryMin = 1000,
            SalaryMax = 3000
        };

        [BindProperty]
        public string SkillsInput { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var user = _mockDataService.Users.FirstOrDefault(u => u.Role == UserRole.RECRUITER);
            if (user != null)
            {
                if (user.WalletBalance >= 50000)
                {
                    user.WalletBalance -= 50000;

                    var newJob = new Job
                    {
                        Id = (long)_mockDataService.Jobs.Count + 1,
                        RecruiterId = user.Id,
                        Title = JobInput.Title ?? "",
                        Description = JobInput.Description ?? "",
                        Requirement = JobInput.Requirement ?? "",
                        SkillsRequired = SkillsInput ?? "",
                        SalaryMin = JobInput.SalaryMin,
                        SalaryMax = JobInput.SalaryMax,
                        JobType = JobInput.JobType,
                        Status = JobStatus.APPROVED,
                        Location = string.IsNullOrEmpty(JobInput.Location) ? "Remote" : JobInput.Location,
                        Category = JobInput.Category ?? "Software Development",
                        CreatedTime = System.DateTime.Now
                    };

                    _mockDataService.Jobs.Add(newJob);

                    _mockDataService.Transactions.Add(new Transaction
                    {
                        Id = (long)_mockDataService.Transactions.Count + 1,
                        UserId = user.Id,
                        Amount = -50000,
                        Type = "JOB_POST",
                        Description = $"Job Post: {newJob.Title}",
                        CreatedAt = System.DateTime.Now
                    });
                }
            }
            return RedirectToPage("/Jobs/Jobs");
        }
    }
}
