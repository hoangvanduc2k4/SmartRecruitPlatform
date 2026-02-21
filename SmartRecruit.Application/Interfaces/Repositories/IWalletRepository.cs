using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<Wallet?> GetWalletByUserIdAsync(long userId);
        Task<PagedList<Transaction>> GetTransactionsAsync(TransactionSearchRequest request);
    }
}
