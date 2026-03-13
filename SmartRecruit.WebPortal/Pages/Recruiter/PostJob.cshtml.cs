using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class PostJobModel : BasePageModel
    {
        private readonly IJobApiService _jobApiService;
        private readonly IWalletApiService _walletApiService;

        public PostJobModel(IJobApiService jobApiService, IWalletApiService walletApiService)
        {
            _jobApiService = jobApiService;
            _walletApiService = walletApiService;
        }

        [BindProperty]
        public Job JobInput { get; set; } = new Job
        {
            JobType = JobType.FULL_TIME,
            SalaryMin = 1000,
            SalaryMax = 3000
        };

        [BindProperty]
        public string SkillsInput { get; set; } = string.Empty;

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public decimal WalletBalance { get; set; }
        public int PageSize { get; set; } = 5;


        public async Task OnGetAsync()
        {
            Categories = await _jobApiService.GetCategoriesAsync();
            var wallet = await _walletApiService.GetWalletInfoAsync();
            if (wallet != null)
            {
                WalletBalance = wallet.Balance;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var recruiterId = CurrentUserId;
            if (!recruiterId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            // Wallet check
            var wallet = await _walletApiService.GetWalletInfoAsync();
            if (wallet == null || wallet.Balance < 50000)
            {
                ModelState.AddModelError(string.Empty, "Insufficient wallet balance. Posting a job costs 50,000 VNĐ.");
                Categories = await _jobApiService.GetCategoriesAsync();
                WalletBalance = wallet?.Balance ?? 0;
                return Page();
            }

            var result = await _jobApiService.CreateJobAsync(new Job
            {
                RecruiterId = recruiterId.Value,
                Title = JobInput.Title ?? "",
                Description = JobInput.Description ?? "",
                Requirement = JobInput.Requirement ?? "",
                SkillsRequired = SkillsInput ?? "",
                SalaryMin = JobInput.SalaryMin,
                SalaryMax = JobInput.SalaryMax,
                JobType = JobInput.JobType,
                Location = string.IsNullOrEmpty(JobInput.Location) ? "Remote" : JobInput.Location,
                CategoryId = JobInput.CategoryId
            });

            if (result != null)
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }

            ModelState.AddModelError(string.Empty, "Failed to create job. Please try again.");
            Categories = await _jobApiService.GetCategoriesAsync();
            return Page();
        }
    }
}
