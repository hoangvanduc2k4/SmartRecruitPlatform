using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly ApplicationDbContext _context;

        public WalletRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Wallet?> GetWalletByUserIdAsync(long userId)
        {
            return await _context.Set<Wallet>()
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task<PagedList<Transaction>> GetTransactionsAsync(TransactionSearchRequest request)
        {
            var query = _context.Set<Transaction>()
                .AsQueryable();

            // Filter by UserId
            if (request.UserId.HasValue)
            {
                query = query.Where(t => t.UserId == request.UserId.Value);
            }

            // Filter by WalletId
            if (request.WalletId.HasValue)
            {
                query = query.Where(t => t.WalletId == request.WalletId.Value);
            }

            // Filter by TransactionType
            if (request.Type.HasValue)
            {
                query = query.Where(t => (int)t.Type == request.Type.Value);
            }

            // Filter by TransactionStatus
            if (request.Status.HasValue)
            {
                query = query.Where(t => (int)t.Status == request.Status.Value);
            }

            // Default sort: newest first
            query = query.OrderByDescending(t => t.CreatedAt);

            return await PagedList<Transaction>.CreateAsync(query, request.Page, request.PageSize);
        }
    }
}
