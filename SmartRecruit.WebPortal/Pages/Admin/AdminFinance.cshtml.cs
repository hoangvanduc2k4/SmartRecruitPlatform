using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api.Admin;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Admin
{
    public class AdminFinanceModel : PageModel
    {
        private readonly IAdminApiService _adminApiService;

        public AdminFinanceModel(IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "OVERVIEW"; // OVERVIEW, LEDGER

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public FinanceStatsResponse Stats { get; set; } = new();
        public List<TransactionResponse> RecentTransactions { get; set; } = new();

        public async Task OnGetAsync()
        {
            Stats = await _adminApiService.GetFinanceStatsAsync() ?? new FinanceStatsResponse();
            
            var pagedTransactions = await _adminApiService.GetGlobalTransactionsAsync(PageNumber, PageSize);
            RecentTransactions = pagedTransactions?.Data?.ToList() ?? new List<TransactionResponse>();
            TotalPages = pagedTransactions?.TotalPages ?? 1;
        }
    }
}
