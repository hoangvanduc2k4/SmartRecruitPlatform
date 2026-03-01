using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartRecruitWeb.Models;
using SmartRecruitWeb.Services;

namespace SmartRecruitWeb.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IMockDataService _mockDataService;

        public ProfileModel(IMockDataService mockDataService)
        {
            _mockDataService = mockDataService;
        }

        public User CurrentUser { get; set; } = new User();
        public List<string> Skills { get; set; } = new List<string> { "C#", "React", "SQL", "System Design", "Cloud Architecture" };

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "IDENTITY"; // IDENTITY, SKILLS, SECURITY

        public void OnGet()
        {
            CurrentUser = _mockDataService.Users.FirstOrDefault(u => u.Role == UserRole.CANDIDATE) ?? new User();
        }

        public IActionResult OnPostUploadSim()
        {
            // Simulate AI parsing
            Skills.Add("ASP.NET Core");
            Skills.Add("Azure");
            return RedirectToPage(new { Tab = "SKILLS" });
        }

        public IActionResult OnPostUpdatePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            // Mock update password
            return RedirectToPage(new { Tab = "SECURITY" });
        }
    }
}
