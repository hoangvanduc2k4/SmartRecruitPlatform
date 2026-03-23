using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebPortal.Models;
using WebPortal.Models.Api;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class AuthInputModel : IValidatableObject
    {
        public string Mode { get; set; } = "LOGIN"; // LOGIN, REGISTER, FORGOT_PASSWORD

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        public string? OTPCode { get; set; }

        public string? Password { get; set; }
        
        public string? FullName { get; set; }
        
        public UserRole Role { get; set; } = UserRole.CANDIDATE;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Mode == "LOGIN" || Mode == "REGISTER")
            {
                if (string.IsNullOrWhiteSpace(Password))
                {
                    yield return new ValidationResult("The Password field is required.", new[] { nameof(Password) });
                }
            }

            if (Mode == "REGISTER")
            {
                if (string.IsNullOrWhiteSpace(FullName))
                {
                    yield return new ValidationResult("The Full Name field is required.", new[] { nameof(FullName) });
                }
            }

            if (Mode == "VERIFY_OTP" || Mode == "RESET_PASSWORD")
            {
                if (string.IsNullOrWhiteSpace(OTPCode))
                {
                    yield return new ValidationResult("The Security Code is required.", new[] { nameof(OTPCode) });
                }
            }

            if (Mode == "RESET_PASSWORD")
            {
                if (string.IsNullOrWhiteSpace(Password))
                {
                    yield return new ValidationResult("The New Password field is required.", new[] { nameof(Password) });
                }
            }
        }
    }

    [IgnoreAntiforgeryToken]
    public class AuthModel : PageModel
    {
        private readonly IAuthApiService _authApiService;

        public AuthModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        [BindProperty]
        public AuthInputModel Input { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.Mode == "LOGIN")
            {
                try
                {
                    var response = await _authApiService.LoginAsync(new LoginRequest { Email = Input.Email!, Password = Input.Password! });
                    if (response != null && !string.IsNullOrEmpty(response.Token))
                    {
                        return RedirectToPage("/Index");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("verify your email", StringComparison.OrdinalIgnoreCase))
                    {
                        // Intercept and redirect to the OTP screen!
                        ModelState.Remove("Input.Mode"); // MUST REMOVE FROM CACHE TO OVERRIDE THE VIEW
                        Input.Mode = "VERIFY_OTP";
                        ModelState.AddModelError(string.Empty, "Please enter the security code sent to your email to verify your account.");
                        return Page();
                    }
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return Page();
            }
            else if (Input.Mode == "REGISTER")
            {
                try
                {
                    var success = await _authApiService.RegisterAsync(new RegisterRequest { 
                        Email = Input.Email!, 
                        Password = Input.Password!, 
                        FullName = Input.FullName!, 
                        Role = Input.Role 
                    });

                    if (success)
                    {
                        ModelState.Remove("Input.Mode"); // MUST REMOVE CACHE
                        Input.Mode = "VERIFY_OTP";
                        TempData["SuccessMessage"] = "Registration successful! We've sent an OTP code to your email.";
                        return Page();
                    }
                    ModelState.AddModelError(string.Empty, "Registration failed. Email might already exist.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return Page();
            }
            else if (Input.Mode == "VERIFY_OTP")
            {
                try
                {
                    var success = await _authApiService.VerifyEmailAsync(new VerifyEmailRequest { Email = Input.Email!, Code = Input.OTPCode! });
                    if (success)
                    {
                        TempData["SuccessMessage"] = "Email verified successfully! You can now login.";
                        ModelState.Remove("Input.Mode");
                        Input.Mode = "LOGIN";
                        Input.OTPCode = string.Empty; // Clear code
                        return Page();
                    }
                    ModelState.AddModelError(string.Empty, "Verification failed. Invalid or expired OTP.");
                }
                catch (Exception ex)
                {
                     ModelState.AddModelError(string.Empty, ex.Message);
                }
                return Page();
            }
            else if (Input.Mode == "FORGOT_PASSWORD")
            {
                try
                {
                    var success = await _authApiService.ForgotPasswordAsync(Input.Email!);
                    if (success)
                    {
                        ModelState.Remove("Input.Mode");
                        Input.Mode = "RESET_PASSWORD";
                        TempData["SuccessMessage"] = "Password reset instructions sent! Please check your email.";
                        return Page();
                    }
                    ModelState.AddModelError(string.Empty, "Failed to initiate password reset.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return Page();
            }
            else if (Input.Mode == "RESET_PASSWORD")
            {
                try
                {
                    var success = await _authApiService.ResetPasswordAsync(new ResetPasswordRequest { Email = Input.Email!, Code = Input.OTPCode!, NewPassword = Input.Password! });
                    if (success)
                    {
                        TempData["SuccessMessage"] = "Password reset successfully! You can now login.";
                        ModelState.Remove("Input.Mode");
                        Input.Mode = "LOGIN";
                        Input.Password = string.Empty; // Clear password
                        return Page();
                    }
                    ModelState.AddModelError(string.Empty, "Failed to reset password. Invalid code.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostResendOtpAsync([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new JsonResult(new { success = false, message = "Email is required to resend OTP." });
            }
            try
            {
                var success = await _authApiService.ResendVerificationEmailAsync(email);
                return new JsonResult(new { success = success, message = success ? "New security code sent!" : "Failed to send code." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> OnPostGoogleCallbackAsync([FromForm(Name = "id_token")] string? idToken)
        {
            if (string.IsNullOrEmpty(idToken))
            {
                return new JsonResult(new { success = false, message = "Google identity token missing." });
            }

            try
            {
                var response = await _authApiService.GoogleLoginAsync(idToken);
                if (response != null && !string.IsNullOrEmpty(response.Token))
                {
                    return new JsonResult(new { success = true, redirectUrl = "/Index" });
                }
                return new JsonResult(new { success = false, message = "Login failed. Profile could not be established." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        public IActionResult OnPostQuickLogin(string userRole)
        {
            // Keeping this temporarily for UI ease of testing, but it should be removed in production
            Response.Cookies.Append("MockUserRole", userRole);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await _authApiService.LogoutAsync();
            return RedirectToPage("/Index");
        }
    }
}
