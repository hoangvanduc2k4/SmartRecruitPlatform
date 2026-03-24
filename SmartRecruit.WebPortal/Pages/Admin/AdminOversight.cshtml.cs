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

        public WebPortal.Models.Api.PagedResponse<WebPortal.Models.Api.Admin.AILogResponse> AILogs { get; set; } = default!;
        
        [BindProperty(Name = "page", SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(Name = "pageSize", SupportsGet = true)]
        public int PageSize { get; set; } = 12;

        public async Task OnGetAsync()
        {
            // Bypassing model binding for absolute reliability
            if (int.TryParse(Request.Query["page"], out int p)) PageNumber = p;
            if (int.TryParse(Request.Query["pageSize"], out int ps)) PageSize = ps;

            AILogs = await _adminApiService.GetAiLogsAsync(page: PageNumber, pageSize: PageSize);
        }
    }
}
