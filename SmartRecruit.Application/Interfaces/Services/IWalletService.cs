using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IWalletService
    {
        Task<WalletResponse> GetWalletByUserIdAsync(long userId);
        Task<PagedList<TransactionResponse>> GetTransactionsAsync(TransactionSearchRequest request);
        Task<FinanceStatsResponse> GetFinanceStatsAsync();
        Task<WeeklyRevenueResponse> GetWeeklyRevenueAsync();
        Task<byte[]> ExportTransactionsToExcelAsync(TransactionSearchRequest request);
    }
}
