using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Services.Api;
using WebPortal.Models;

namespace WebPortal.Pages
{
    public class AdminTransactionsModel : PageModel
    {
        private readonly IWalletApiService _walletApiService;

        public AdminTransactionsModel(IWalletApiService walletApiService)
        {
            _walletApiService = walletApiService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;

        public class TransactionViewModel
        {
            public required string Id { get; set; }
            public required string User { get; set; }
            public required string Type { get; set; }
            public decimal Amount { get; set; }
            public required string Date { get; set; }
            public required string Status { get; set; }
        }

        public IList<TransactionViewModel> Transactions { get; set; } = new List<TransactionViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            if (CurrentPage < 1) CurrentPage = 1;

            var response = await _walletApiService.GetTransactionsAsync(null, CurrentPage, PageSize);
            if (response?.Data != null)
            {
                Transactions = response.Data.Select(t => new TransactionViewModel
                {
                    Id = t.Id.ToString(),
                    User = $"User {t.UserId}", // Ideally fetch username, but for now using ID
                    Type = t.Type ?? "UNKNOWN",
                    Amount = t.Amount,
                    Date = t.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                    Status = t.Status ?? "SUCCESS"
                }).ToList();

                TotalPages = response.TotalPages;
            }

            return Page();
        }

        public async Task<IActionResult> OnGetExport()
        {
            var fileBytes = await _walletApiService.DownloadTransactionsExcelAsync();
            if (fileBytes == null)
            {
                return RedirectToPage();
            }

            var fileName = $"SystemTransactions_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
