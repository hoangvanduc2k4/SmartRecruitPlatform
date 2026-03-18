using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class WalletModel : PageModel
    {
        private readonly IWalletApiService _walletApiService;

        public WalletModel(IWalletApiService walletApiService)
        {
            _walletApiService = walletApiService;
        }

        public WalletData Wallet { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
        public decimal TotalAmountPaid { get; set; }
        public int TotalTransactions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var walletInfo = await _walletApiService.GetWalletInfoAsync();
            if (walletInfo != null)
            {
                Wallet = walletInfo;
            }

            var transactionsResponse = await _walletApiService.GetTransactionsAsync();
            if (transactionsResponse?.Data != null)
            {
                Transactions = transactionsResponse.Data.ToList();
                TotalTransactions = transactionsResponse.TotalCount;
                var paidTypes = new[] { "JOB_POST", "BOOST", "VIP", "OTHER" };
                TotalAmountPaid = Transactions.Where(t => paidTypes.Contains(t.Type?.ToUpper()) && t.Status?.ToUpper() == "SUCCESS").Sum(t => Math.Abs(t.Amount));
            }

            return Page();
        }

        public async Task<IActionResult> OnPostTopUpAsync(decimal amount)
        {
            if (amount <= 0)
            {
                return Page();
            }

            var (checkoutUrl, error) = await _walletApiService.CreateDepositLinkAsync(amount);
            if (!string.IsNullOrEmpty(checkoutUrl))
            {
                return Redirect(checkoutUrl);
            }

            ModelState.AddModelError("", error ?? "Failed to create payment link. Please try again.");
            return await OnGetAsync();
        }
    }
}
