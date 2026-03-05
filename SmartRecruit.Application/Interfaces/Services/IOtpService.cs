using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IOtpService
    {
        string GenerateOtp(int length = 6);
        Task<OtpToken> CreateOtpAsync(string email, string otpType);
        Task<bool> VerifyOtpAsync(string email, string otpCode, string otpType);
        Task IncrementAttemptCountAsync(string email, string otpCode, string otpType);
        Task<bool> CanCreateNewOtpAsync(string email, string otpType);
    }
}
