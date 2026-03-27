using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<Wallet?> GetWalletByUserIdAsync(long userId);
        Task<Wallet?> GetWalletForUpdateAsync(long userId);
        Task<PagedList<Transaction>> GetTransactionsAsync(TransactionSearchRequest request);
        Task<Transaction?> GetTransactionByOrderCodeAsync(long orderCode);
        Task AddTransactionAsync(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        Task<FinanceStatsResponse> GetFinanceStatsAsync();
    }
}
