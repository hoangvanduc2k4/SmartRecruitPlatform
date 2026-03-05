using System.ComponentModel.DataAnnotations;

namespace SmartRecruit.Application.DTO.Auth
{
    public class LogoutRequest
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
