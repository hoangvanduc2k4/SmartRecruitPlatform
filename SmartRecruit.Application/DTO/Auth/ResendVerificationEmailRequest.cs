using System.ComponentModel.DataAnnotations;

namespace SmartRecruit.Application.DTO.Auth
{
    public class ResendVerificationEmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
