using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Services;

namespace WebPortal.Pages
{
    public class WalletModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public WalletModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public User CurrentUser { get; set; } = new User();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void OnGet()
        {
            // Simulate logged in user
            CurrentUser = _mockDataService.Users.FirstOrDefault() ?? new User { WalletBalance = 2500000 };

            Transactions = _mockDataService.Transactions
                .Where(t => t.UserId == CurrentUser.Id)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            // Fallback mock transactions if empty
            if (!Transactions.Any())
            {
                Transactions = new List<Transaction>
                {
                    new Transaction { Id = 1001, UserId = CurrentUser.Id, Amount = -50000, Type = "SERVICE_FEE", Description = "Job Post: Senior .NET Dev", CreatedAt = System.DateTime.Now.AddDays(-2) },
                    new Transaction { Id = 1002, UserId = CurrentUser.Id, Amount = 500000, Type = "TOP_UP", Description = "Top Up: PayOS", CreatedAt = System.DateTime.Now.AddDays(-3) },
                    new Transaction { Id = 1003, UserId = CurrentUser.Id, Amount = -10000, Type = "JOB_BOOST", Description = "Candidate Unlock: Bob Backend", CreatedAt = System.DateTime.Now.AddDays(-4) }
                };
            }
        }

        public IActionResult OnPostTopUp(int amount)
        {
            // Simulate top-up
            var user = _mockDataService.Users.FirstOrDefault();
            if (user != null && amount > 0)
            {
                user.WalletBalance += amount;
                _mockDataService.Transactions.Add(new Transaction
                {
                    Id = (long)_mockDataService.Transactions.Count + 1,
                    UserId = user.Id,
                    Amount = amount,
                    Type = "TOP_UP",
                    Description = "Top Up: PayOS",
                    CreatedAt = System.DateTime.Now
                });
            }
            return RedirectToPage();
        }
    }
}
