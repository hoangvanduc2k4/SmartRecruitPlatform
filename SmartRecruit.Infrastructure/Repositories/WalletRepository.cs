using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WalletRepository> _logger;

        public WalletRepository(ApplicationDbContext context, ILogger<WalletRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }   

        public async Task<Wallet?> GetWalletByUserIdAsync(long userId)
        {
            _logger.LogTrace("Executing SQL query to fetch Wallet by UserId: {UserId}", userId);
            return await _context.Set<Wallet>()
                .Include(w => w.User)
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }

        public async Task<PagedList<Transaction>> GetTransactionsAsync(TransactionSearchRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch transactions with parameters: {@Request}", request);
            var query = _context.Set<Transaction>()
                .Include(t => t.User)
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

        public async Task<Transaction?> GetTransactionByOrderCodeAsync(long orderCode)
        {
            return await _context.Set<Transaction>()
                .FirstOrDefaultAsync(t => t.OrderCode == orderCode);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Set<Transaction>().AddAsync(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _logger.LogTrace("Executing SQL update for transaction OrderCode: {OrderCode} to Status: {Status}", transaction.OrderCode, transaction.Status);
            _context.Set<Transaction>().Update(transaction);
        }

        public async Task<FinanceStatsResponse> GetFinanceStatsAsync()
        {
            var transactions = await _context.Set<Transaction>()
                .Where(t => t.Status == TransactionStatus.SUCCESS)
                .ToListAsync();

            var totalTransactions = await _context.Set<Transaction>().CountAsync();
            var pendingCount = await _context.Set<Transaction>().CountAsync(t => t.Status == TransactionStatus.PENDING);
            var successCount = await _context.Set<Transaction>().CountAsync(t => t.Status == TransactionStatus.SUCCESS);
            var failedCount = await _context.Set<Transaction>().CountAsync(t => t.Status == TransactionStatus.FAILED);

            var cashInflow = transactions
                .Where(t => t.Type == TransactionType.TOPUP)
                .Sum(t => t.Amount);

            var recognizedRevenue = transactions
                .Where(t => t.Type != TransactionType.TOPUP)
                .Sum(t => Math.Abs(t.Amount));

            var jobPostRevenue = transactions
                .Where(t => t.Type == TransactionType.JOB_POST)
                .Sum(t => Math.Abs(t.Amount));

            var boostRevenue = transactions
                .Where(t => t.Type == TransactionType.BOOST)
                .Sum(t => Math.Abs(t.Amount));

            var vipRevenue = transactions
                .Where(t => t.Type == TransactionType.VIP)
                .Sum(t => Math.Abs(t.Amount));

            var otherRevenue = transactions
                .Where(t => t.Type == TransactionType.OTHER)
                .Sum(t => Math.Abs(t.Amount));

            var systemCirculatingBalance = await _context.Set<Wallet>().SumAsync(w => w.Balance);

            return new FinanceStatsResponse
            {
                TotalCashInflow = cashInflow,
                SystemCirculatingBalance = systemCirculatingBalance,
                TotalRecognizedRevenue = recognizedRevenue,
                JobPostRevenue = jobPostRevenue,
                BoostRevenue = boostRevenue,
                VipRevenue = vipRevenue,
                OtherRevenue = otherRevenue,
                TotalTransactions = totalTransactions,
                PendingTransactions = pendingCount,
                SuccessTransactions = successCount,
                FailedTransactions = failedCount
            };
        }
    }
}
