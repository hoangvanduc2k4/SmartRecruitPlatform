using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IAuthApiService _authApiService;

        public ProfileModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        public UserProfileResponse? CurrentUser { get; set; }
        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "IDENTITY"; // IDENTITY, SKILLS (Candidate), COMPANY (Recruiter), SECURITY

        [BindProperty]
        public UpdateProfileRequest UpdateInput { get; set; } = new();

        [BindProperty]
        public IFormFile? CvFile { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                CurrentUser = await _authApiService.GetProfileAsync();
                if (CurrentUser == null)
                    return RedirectToPage("/Account/Auth");

                // Pre-fill update form with current values
                UpdateInput.FullName = CurrentUser.FullName;
                if (CurrentUser.CandidateProfile != null)
                {
                    UpdateInput.Skills = CurrentUser.CandidateProfile.Skills;
                    UpdateInput.ExperienceYears = CurrentUser.CandidateProfile.ExperienceYears;
                    UpdateInput.ExpectedSalary = CurrentUser.CandidateProfile.ExpectedSalary;
                }
                if (CurrentUser.CompanyProfile != null)
                {
                    UpdateInput.CompanyName = CurrentUser.CompanyProfile.CompanyName;
                    UpdateInput.CompanyDescription = CurrentUser.CompanyProfile.CompanyDescription;
                    UpdateInput.WebsiteUrl = CurrentUser.CompanyProfile.WebsiteUrl;
                    UpdateInput.Address = CurrentUser.CompanyProfile.Address;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            try
            {
                var success = await _authApiService.UpdateProfileAsync(UpdateInput);
                if (success)
                {
                    TempData["SuccessMessage"] = "Profile synchronized successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToPage(new { Tab });
        }

        public async Task<IActionResult> OnPostUploadCvAsync()
        {
            if (CvFile == null || CvFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Please select a CV file (PDF) to upload.";
                return RedirectToPage(new { Tab = "CVS" });
            }

            if (!CvFile.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                TempData["ErrorMessage"] = "Only PDF files are supported for CV upload.";
                return RedirectToPage(new { Tab = "CVS" });
            }

            try
            {
                using var stream = CvFile.OpenReadStream();
                var success = await _authApiService.UploadCvAsync(stream, CvFile.FileName);
                if (success)
                {
                    TempData["SuccessMessage"] = "CV uploaded and text extracted successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage(new { Tab = "CVS" });
        }
    }
}

