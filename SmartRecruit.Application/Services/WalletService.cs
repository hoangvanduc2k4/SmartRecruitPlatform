using AutoMapper;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.DTO.Admin;
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
        private readonly IExcelService _excelService;

        public WalletService(IWalletRepository walletRepository, IMapper mapper, ILogger<WalletService> logger, IExcelService excelService)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _logger = logger;
            _excelService = excelService;
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

        public async Task<FinanceStatsResponse> GetFinanceStatsAsync()
        {
            return await _walletRepository.GetFinanceStatsAsync();
        }

        public async Task<WeeklyRevenueResponse> GetWeeklyRevenueAsync()
        {
            var revenue = await _walletRepository.GetWeeklyRevenueAsync();
            return new WeeklyRevenueResponse { Revenue = revenue };
        }

        public async Task<byte[]> ExportTransactionsToExcelAsync(TransactionSearchRequest request)
        {
            // Fetch all matching transactions (large PageSize to simulate "All")
            request.Page = 1;
            request.PageSize = 1000000; 
            var transactions = await _walletRepository.GetTransactionsAsync(request);
            var dtos = _mapper.Map<List<TransactionResponse>>(transactions);

            var exportData = dtos.Select(t => new TransactionExportDto
            {
                MaGD = t.Id,
                NguoiDung = t.UserName,
                SoTien = t.Amount,
                LoaiGiaoDich = t.Type switch
                {
                    "TOPUP" => "Nạp tiền",
                    "JOB_POST" => "Đăng tin",
                    "BOOST" => "Đẩy tin",
                    "VIP" => "Nâng cấp VIP",
                    _ => t.Type
                },
                TrangThai = t.Status switch
                {
                    "PENDING" => "Đang chờ",
                    "SUCCESS" => "Thành công",
                    "FAILED" => "Thất bại",
                    _ => t.Status
                },
                MaDonHang = t.OrderCode?.ToString() ?? "N/A",
                MoTa = t.Description,
                ThoiGian = t.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();

            return _excelService.ExportToExcel(exportData, "Transactions");
        }
    }
}
