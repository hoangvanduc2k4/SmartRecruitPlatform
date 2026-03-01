using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPortal.Pages
{
    public class AdminOversightModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "AI_LOGS"; // AI_LOGS, APPEALS, FINANCIAL

        public void OnGet()
        {
        }

        public IActionResult OnPostApproveAppeal()
        {
            return RedirectToPage(new { Tab = "APPEALS" });
        }

        public IActionResult OnPostRejectAppeal()
        {
            return RedirectToPage(new { Tab = "APPEALS" });
        }
    }
}
