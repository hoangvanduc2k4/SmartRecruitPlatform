using AutoMapper;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<WalletResponse> GetWalletByUserIdAsync(long userId)
        {
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) throw new KeyNotFoundException($"Wallet not found for user {userId}");
            return _mapper.Map<WalletResponse>(wallet);
        }

        public async Task<PagedList<TransactionResponse>> GetTransactionsAsync(TransactionSearchRequest request)
        {
            var transactions = await _walletRepository.GetTransactionsAsync(request);
            var dtos = _mapper.Map<List<TransactionResponse>>(transactions);
            return new PagedList<TransactionResponse>(dtos, transactions.TotalCount, transactions.CurrentPage, transactions.PageSize);
        }
    }
}
