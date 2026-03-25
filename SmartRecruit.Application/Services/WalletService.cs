using AutoMapper;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using SmartRecruit.Domain.Constants;
using SmartRecruit.Domain.Exceptions;

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
                throw new NotFoundException(Messages.GeneralMsg.NOT_FOUND);
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

        public async Task<byte[]> ExportTransactionsToExcelAsync(TransactionSearchRequest request)
        {
            // Fetch all matching transactions (large PageSize to simulate "All")
            request.Page = 1;
            request.PageSize = 1000000; 
            var transactions = await _walletRepository.GetTransactionsAsync(request);
            var dtos = _mapper.Map<List<TransactionResponse>>(transactions);

            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Transactions");
                
                // Headers (Vietnamese)
                worksheet.Cell(1, 1).Value = "Mã GD";
                worksheet.Cell(1, 2).Value = "Người dùng";
                worksheet.Cell(1, 3).Value = "Số tiền (VND)";
                worksheet.Cell(1, 4).Value = "Loại giao dịch";
                worksheet.Cell(1, 5).Value = "Trạng thái";
                worksheet.Cell(1, 6).Value = "Mã đơn hàng";
                worksheet.Cell(1, 7).Value = "Mô tả";
                worksheet.Cell(1, 8).Value = "Thời gian tạo";

                // Format Headers
                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray;

                // Data
                for (int i = 0; i < dtos.Count; i++)
                {
                    var t = dtos[i];
                    int row = i + 2;
                    
                    // Translation logic
                    string viType = t.Type switch
                    {
                        "TOPUP" => "Nạp tiền",
                        "JOB_POST" => "Đăng tin",
                        "BOOST" => "Đẩy tin",
                        "VIP" => "Nâng cấp VIP",
                        _ => t.Type
                    };

                    string viStatus = t.Status switch
                    {
                        "PENDING" => "Đang chờ",
                        "SUCCESS" => "Thành công",
                        "FAILED" => "Thất bại",
                        _ => t.Status
                    };

                    worksheet.Cell(row, 1).Value = t.Id;
                    worksheet.Cell(row, 2).Value = t.UserName; // Using UserName
                    worksheet.Cell(row, 3).Value = t.Amount;
                    worksheet.Cell(row, 4).Value = viType; // Translated Type
                    worksheet.Cell(row, 5).Value = viStatus; // Translated Status
                    worksheet.Cell(row, 6).Value = t.OrderCode?.ToString() ?? "N/A";
                    worksheet.Cell(row, 7).Value = t.Description;
                    worksheet.Cell(row, 8).Value = t.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
