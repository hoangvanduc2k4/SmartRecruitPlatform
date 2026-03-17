using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api.Admin;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Admin
{
    public class AdminModerationModel : PageModel
    {
        private readonly IAdminApiService _adminApiService;

        public AdminModerationModel(IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }

        public IList<AppealedJobResponse> Appeals { get; set; } = new List<AppealedJobResponse>();
        
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync()
        {
            var response = await _adminApiService.GetAppealsAsync(CurrentPage, PageSize);
            if (response.Success)
            {
                Appeals = response.Data?.ToList() ?? new List<AppealedJobResponse>();
                TotalPages = response.TotalPages;
            }
        }

        public async Task<IActionResult> OnPostApproveAsync(long jobId)
        {
            var success = await _adminApiService.OverrideAiDecisionAsync(jobId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync(long jobId)
        {
            var success = await _adminApiService.RejectAppealAsync(jobId);
            return RedirectToPage();
        }
    }
}
