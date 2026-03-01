using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartRecruitWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        var mockRole = Request.Cookies["MockUserRole"];
        if (string.IsNullOrEmpty(mockRole))
        {
            return Page();
        }

        return mockRole switch
        {
            "ADMIN" => RedirectToPage("/Admin/AdminDashboard"),
            "RECRUITER" => RedirectToPage("/Recruiter/RecruiterJobs"),
            "CANDIDATE" => RedirectToPage("/Candidate/Dashboard"),
            _ => Page()
        };
    }
}
