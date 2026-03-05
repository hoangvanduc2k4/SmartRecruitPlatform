using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OtpService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GenerateOtp(int length = 6)
        {
            var random = new Random();
            var otp = "";
            for (int i = 0; i < length; i++)
            {
                otp += random.Next(0, 10).ToString();
            }
            return otp;
        }

        public async Task<OtpToken> CreateOtpAsync(string email, string otpType)
        {
            // Invalidate all active OTPs for this email and type
            var existingOtps = await _unitOfWork.OtpTokens.FindAllAsync(o => 
                o.Email == email && 
                o.Type == otpType && 
                !o.IsUsed && 
                o.ExpiryDate > DateTime.UtcNow);

            foreach (var existing in existingOtps)
            {
                existing.IsUsed = true; // Mark as "used" to invalidate
                _unitOfWork.OtpTokens.Update(existing);
            }

            // Create new OTP
            var otpCode = GenerateOtp();
            var otp = new OtpToken
            {
                Email = email,
                Code = otpCode,
                Type = otpType,
                ExpiryDate = DateTime.UtcNow.AddMinutes(15),
                IsUsed = false,
                AttemptCount = 0,
            };

            await _unitOfWork.OtpTokens.AddAsync(otp);
            await _unitOfWork.CompleteAsync();

            return otp;
        }

        public async Task<bool> VerifyOtpAsync(string email, string otpCode, string otpType)
        {
            var otp = await _unitOfWork.OtpTokens.FindAsync(o => 
                o.Email == email && 
                o.Code == otpCode && 
                o.Type == otpType && 
                !o.IsUsed);

            if (otp == null)
            {
                return false;
            }

            if (otp.ExpiryDate < DateTime.UtcNow)
            {
                otp.IsUsed = true; // Mark expired as used
                _unitOfWork.OtpTokens.Update(otp);
                await _unitOfWork.CompleteAsync();
                return false;
            }

            if (otp.AttemptCount >= 5)
            {
                otp.IsUsed = true; // Invalidate after 5 attempts
                _unitOfWork.OtpTokens.Update(otp);
                await _unitOfWork.CompleteAsync();
                throw new Exception("Quá số lần nhập sai cho phép. Vui lòng gửi lại mã OTP.");
            }

            // Valid
            otp.IsUsed = true;
            _unitOfWork.OtpTokens.Update(otp);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task IncrementAttemptCountAsync(string email, string otpCode, string otpType)
        {
            // Find the active OTP trying to be verified
            var otpItems = await _unitOfWork.OtpTokens.FindAllAsync(o => 
                o.Email == email && 
                o.Type == otpType && 
                !o.IsUsed &&
                o.ExpiryDate > DateTime.UtcNow);
                
            var activeOtp = otpItems.OrderByDescending(o => o.CreatedAt).FirstOrDefault();

            if (activeOtp != null)
            {
                activeOtp.AttemptCount++;
                _unitOfWork.OtpTokens.Update(activeOtp);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<bool> CanCreateNewOtpAsync(string email, string otpType)
        {
            var otps = await _unitOfWork.OtpTokens.FindAllAsync(o => 
                o.Email == email && 
                o.Type == otpType);
                
            var lastOtp = otps.OrderByDescending(o => o.CreatedAt).FirstOrDefault();

            if (lastOtp == null)
                return true;

            // Cooldown 2 mins
            return lastOtp.CreatedAt.AddMinutes(2) < DateTime.UtcNow;
        }
    }
}
