using Microsoft.EntityFrameworkCore;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Jobs
{
    public class TokenCleanupJob
    {
        private readonly ApplicationDbContext _context;

        public TokenCleanupJob(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RunAsync()
        {
            var now = DateTime.UtcNow;

            var expiredRefreshTokens = await _context.RefreshTokens
                .Where(t => t.ExpiryDate <= now || t.IsRevoked)
                .ToListAsync();

            if (expiredRefreshTokens.Any())
            {
                _context.RefreshTokens.RemoveRange(expiredRefreshTokens);
            }

            var expiredOtpTokens = await _context.OtpTokens
                .Where(t => t.ExpiryDate <= now || t.IsUsed)
                .ToListAsync();

            if (expiredOtpTokens.Any())
            {
                _context.OtpTokens.RemoveRange(expiredOtpTokens);
            }

            if (expiredRefreshTokens.Any() || expiredOtpTokens.Any())
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
