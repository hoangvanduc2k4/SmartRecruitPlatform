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

            await _context.RefreshTokens
                .Where(t => t.ExpiryDate <= now || t.IsRevoked)
                .ExecuteDeleteAsync();

            await _context.OtpTokens
                .Where(t => t.ExpiryDate <= now || t.IsUsed)
                .ExecuteDeleteAsync();
        }
    }
}
