using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPortal.Pages
{
    public class AdminOversightModel : PageModel
    {
        private readonly WebPortal.Services.Api.IAdminApiService _adminApiService;

        public AdminOversightModel(WebPortal.Services.Api.IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }

        public WebPortal.Models.Api.PagedResponse<WebPortal.Models.Api.Admin.AILogResponse> AILogs { get; set; }

        public async Task OnGetAsync(int page = 1)
        {
            AILogs = await _adminApiService.GetAiLogsAsync(page: page, pageSize: 12);
        }
    }
}
