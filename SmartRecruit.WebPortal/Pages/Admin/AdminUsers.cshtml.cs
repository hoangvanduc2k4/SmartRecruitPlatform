using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartRecruitWeb.Pages
{
    public class AdminUsersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";
        
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalUsers { get; set; }

        public class UserViewModel {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public SmartRecruitWeb.Models.UserRole Role { get; set; }
            public bool IsLocked { get; set; }
            public decimal Balance { get; set; }
        }

        public System.Collections.Generic.IList<UserViewModel> Users { get; set; } = new System.Collections.Generic.List<UserViewModel>();

        public void OnGet()
        {
            var allUsers = new[] {
                new UserViewModel { Id = "1", Name = "Alice Developer", Email = "alice@dev.com", Role = SmartRecruitWeb.Models.UserRole.CANDIDATE, IsLocked = false, Balance = 0m },
                new UserViewModel { Id = "2", Name = "John Recruiter", Email = "hr@tech.com", Role = SmartRecruitWeb.Models.UserRole.RECRUITER, IsLocked = false, Balance = 2500000m },
                new UserViewModel { Id = "3", Name = "Spam Bot #1", Email = "scam@bot.com", Role = SmartRecruitWeb.Models.UserRole.RECRUITER, IsLocked = true, Balance = 50000m },
                new UserViewModel { Id = "4", Name = "System Admin", Email = "admin@smartrecruit.com", Role = SmartRecruitWeb.Models.UserRole.ADMIN, IsLocked = false, Balance = 0m },
                new UserViewModel { Id = "5", Name = "Bob Backend", Email = "bob@backend.io", Role = SmartRecruitWeb.Models.UserRole.CANDIDATE, IsLocked = false, Balance = 0m },
                new UserViewModel { Id = "6", Name = "Charlie HR", Email = "charlie@enterprise.net", Role = SmartRecruitWeb.Models.UserRole.RECRUITER, IsLocked = false, Balance = 1000000m },
                new UserViewModel { Id = "7", Name = "Dave Spam", Email = "dave@spam.net", Role = SmartRecruitWeb.Models.UserRole.CANDIDATE, IsLocked = true, Balance = 0m }
            }.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                allUsers = allUsers.Where(u => u.Name.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase) || u.Email.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase));
            }

            TotalUsers = allUsers.Count();
            TotalPages = (int)System.Math.Ceiling(TotalUsers / (double)PageSize);
            if (CurrentPage < 1) CurrentPage = 1;

            Users = allUsers.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
