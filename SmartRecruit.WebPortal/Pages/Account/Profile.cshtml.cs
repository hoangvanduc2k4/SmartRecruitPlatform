
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class ProfileModel : BasePageModel
    {
        private readonly IAuthApiService _authApiService;

        public ProfileModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }


        public bool IsOwnProfile { get; set; } = true;

        [BindProperty(SupportsGet = true)]
        public string Tab { get; set; } = "IDENTITY"; // IDENTITY, SKILLS (Candidate), COMPANY (Recruiter), SECURITY

        [BindProperty]
        public UpdateProfileRequest UpdateInput { get; set; } = new();

        [BindProperty]
        public IFormFile? CvFile { get; set; }

        [BindProperty]
        public IFormFile? AvatarFile { get; set; }

        public async Task<IActionResult> OnGetAsync(long? userId)
        {
            try
            {
                // If userId is provided, we are viewing someone else (or ourselves via ID)
                // If not, we are viewing the current logged-in user
                CurrentUser = await _authApiService.GetProfileAsync(userId);

                if (CurrentUser == null)
                {
                    if (!userId.HasValue) return RedirectToPage("/Account/Auth");
                    return NotFound();
                }

                // Determine if this is the user's own profile
                IsOwnProfile = !userId.HasValue || userId == CurrentUserId;

                // Pre-fill update form with current values (always, so they can be seen in read-only mode)
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
                    TempData["SuccessMessage"] = "Đồng bộ hồ sơ thành công.";
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
                TempData["ErrorMessage"] = "Vui lòng chọn tệp CV (PDF) để tải lên.";
                return RedirectToPage(new { Tab = "CVS" });
            }

            if (!CvFile.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                TempData["ErrorMessage"] = "Chỉ hỗ trợ tệp PDF để tải lên CV.";
                return RedirectToPage(new { Tab = "CVS" });
            }

            try
            {
                using var stream = CvFile.OpenReadStream();
                var success = await _authApiService.UploadCvAsync(stream, CvFile.FileName);
                if (success)
                {
                    TempData["SuccessMessage"] = "Tải lên CV và trích xuất văn bản thành công.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage(new { Tab = "CVS" });
        }

        public async Task<IActionResult> OnPostUploadAvatarAsync()
        {
            if (AvatarFile == null || AvatarFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Vui lòng chọn một tệp hình ảnh để tải lên.";
                return RedirectToPage(new { Tab });
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(AvatarFile.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                TempData["ErrorMessage"] = "Chỉ hỗ trợ các định dạng ảnh JPG, PNG hoặc WEBP.";
                return RedirectToPage(new { Tab });
            }

            try
            {
                using var stream = AvatarFile.OpenReadStream();
                var success = await _authApiService.UploadAvatarAsync(stream, AvatarFile.FileName);
                if (success)
                {
                    TempData["SuccessMessage"] = "Cập nhật ảnh đại diện thành công.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage(new { Tab });
        }
    }
}

