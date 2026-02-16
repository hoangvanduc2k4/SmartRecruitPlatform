using System.ComponentModel.DataAnnotations;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Application.DTO.Auth
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
