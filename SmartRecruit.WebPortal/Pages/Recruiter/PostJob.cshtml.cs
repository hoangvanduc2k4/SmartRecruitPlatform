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
        private readonly IAuthApiService _authApiService;

        public PostJobModel(IJobApiService jobApiService, IWalletApiService walletApiService, IAuthApiService authApiService)
        {
            _jobApiService = jobApiService;
            _walletApiService = walletApiService;
            _authApiService = authApiService;
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

            // Pre-fill Company Name from CompanyProfile
            if (CurrentUserId.HasValue)
            {
                var profile = await _authApiService.GetProfileAsync(CurrentUserId.Value);
                if (profile?.CompanyProfile != null && !string.IsNullOrEmpty(profile.CompanyProfile.CompanyName))
                {
                    JobInput.Company = profile.CompanyProfile.CompanyName;
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var recruiterId = CurrentUserId;
            if (!recruiterId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            var result = await _jobApiService.CreateJobAsync(new Job
            {
                RecruiterId = recruiterId.Value,
                Title = JobInput.Title ?? "",
                Company = JobInput.Company ?? "",
                Description = JobInput.Description ?? "",
                Requirement = JobInput.Requirement ?? "",
                Benefits = JobInput.Benefits ?? "",
                SkillsRequired = SkillsInput ?? "",
                SalaryMin = JobInput.SalaryMin,
                SalaryMax = JobInput.SalaryMax,
                JobType = JobInput.JobType,
                Location = string.IsNullOrEmpty(JobInput.Location) ? "Remote" : JobInput.Location,
                CategoryId = JobInput.CategoryId,
                ExpireDate = JobInput.ExpireDate
            });

            if (result != null)
            {
                return RedirectToPage("/Recruiter/RecruiterJobs");
            }

            ModelState.AddModelError(string.Empty, "Tạo công việc thất bại. Vui lòng thử lại.");
            Categories = await _jobApiService.GetCategoriesAsync();
            return Page();
        }
    }
}
