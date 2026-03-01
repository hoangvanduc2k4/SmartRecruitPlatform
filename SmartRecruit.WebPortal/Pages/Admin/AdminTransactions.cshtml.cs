using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPortal.Pages
{
    public class AdminTransactionsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;

        public class TransactionViewModel
        {
            public required string Id { get; set; }
            public required string User { get; set; }
            public required string Type { get; set; }
            public decimal Amount { get; set; }
            public required string Method { get; set; }
            public required string Date { get; set; }
            public required string Status { get; set; }
        }

        public System.Collections.Generic.IList<TransactionViewModel> Transactions { get; set; } = new System.Collections.Generic.List<TransactionViewModel>();

        public void OnGet()
        {
            var allTransactions = new[] {
                new TransactionViewModel { Id = "TXN-9021", User = "TechCorp HR", Type = "WALLET_TOPUP", Amount = 5000000m, Method = "PAYOS", Date = "2023-11-21 14:30", Status = "SUCCESS" },
                new TransactionViewModel { Id = "TXN-9022", User = "Alice Developer", Type = "VIP_UPGRADE", Amount = -200000m, Method = "WALLET", Date = "2023-11-21 15:10", Status = "SUCCESS" },
                new TransactionViewModel { Id = "TXN-9023", User = "TechCorp HR", Type = "JOB_POST", Amount = -50000m, Method = "WALLET", Date = "2023-11-21 16:00", Status = "SUCCESS" },
                new TransactionViewModel { Id = "TXN-9024", User = "Global Startup", Type = "JOB_BOOST", Amount = -20000m, Method = "WALLET", Date = "2023-11-21 16:45", Status = "SUCCESS" },
                new TransactionViewModel { Id = "TXN-9025", User = "John Recruiter", Type = "WALLET_TOPUP", Amount = 1000000m, Method = "PAYOS", Date = "2023-11-21 17:30", Status = "SUCCESS" },
                new TransactionViewModel { Id = "TXN-9026", User = "Bob Backend", Type = "VIP_UPGRADE", Amount = -200000m, Method = "WALLET", Date = "2023-11-22 10:00", Status = "SUCCESS" }
            }.AsQueryable();

            var count = allTransactions.Count();
            TotalPages = (int)System.Math.Ceiling(count / (double)PageSize);
            if (CurrentPage < 1) CurrentPage = 1;

            Transactions = allTransactions.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
