using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRecruitWeb.Models;
using SmartRecruitWeb.Services;

namespace SmartRecruitWeb.Pages
{
    public class AuthModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public AuthModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;
        
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        
        [BindProperty]
        public string Mode { get; set; } = "LOGIN"; // LOGIN, REGISTER, FORGOT_PASSWORD

        [BindProperty]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        public UserRole Role { get; set; } = UserRole.CANDIDATE;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Simulate Authentication
            Response.Cookies.Append("MockUserRole", Role.ToString());
            return RedirectToPage("/Index");
        }
        
        public IActionResult OnPostQuickLogin(string userRole)
        {
            // Mock quick login, redirect to Index
            Response.Cookies.Append("MockUserRole", userRole);
            return RedirectToPage("/Index");
        }

        public IActionResult OnGetLogout()
        {
            Response.Cookies.Delete("MockUserRole");
            return RedirectToPage("/Index");
        }
    }
}
