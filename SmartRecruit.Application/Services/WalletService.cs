using AutoMapper;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace SmartRecruit.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WalletService> _logger;

        public WalletService(IWalletRepository walletRepository, IMapper mapper, ILogger<WalletService> logger)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WalletResponse> GetWalletByUserIdAsync(long userId)
        {
            _logger.LogInformation("Executing GetWalletByUserId use-case for UserId: {UserId}", userId);
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            if (wallet == null) 
            {
                _logger.LogWarning("GetWalletByUserId use-case failed: Wallet not found for userId: {UserId}", userId);
                throw new KeyNotFoundException($"Wallet not found for user {userId}");
            }
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
