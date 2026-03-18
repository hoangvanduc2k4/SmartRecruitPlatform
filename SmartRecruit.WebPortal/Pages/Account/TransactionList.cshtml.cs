using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;
using System.Linq;

namespace WebPortal.Pages
{
    public class TransactionHistoryModel : PageModel
    {
        private readonly IWalletApiService _walletApiService;

        public TransactionHistoryModel(IWalletApiService walletApiService)
        {
            _walletApiService = walletApiService;
        }

        public PagedResponse<Transaction>? Transactions { get; set; }
        public decimal Balance { get; set; }

        [BindProperty(SupportsGet = true, Name = "page")]
        public int PageNumber { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public int? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Status { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (PageNumber < 1) PageNumber = 1;
            
            var wallet = await _walletApiService.GetWalletInfoAsync();
            Balance = wallet?.Balance ?? 0;

            Transactions = await _walletApiService.GetTransactionsAsync(null, PageNumber, PageSize, Type, Status);
            return Page();
        }
    }
}
