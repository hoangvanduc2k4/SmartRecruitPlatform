using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using SmartRecruit.API.Controllers;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/wallet")]
    public class WalletController : BaseController
    {
        private readonly IWalletService _walletService;
        private readonly ILogger<WalletController> _logger;

        public WalletController(IWalletService walletService, ILogger<WalletController> logger)
        {
            _walletService = walletService;
            _logger = logger;
        }

        /// <summary>
        /// Xem số dư Wallet của chính người dùng hiện tại
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetMyWallet()
        {
            var wallet = await _walletService.GetWalletByUserIdAsync(CurrentUserId);
            return Ok(wallet.Wrap());
        }

        /// <summary>
        /// Xem số dư Wallet của một User (Admin only hoặc internal)
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWalletByUserId(long userId)
        {
            var wallet = await _walletService.GetWalletByUserIdAsync(userId);
            return Ok(wallet.Wrap());
        }

        /// <summary>
        /// Lấy danh sách Transaction (lọc theo userId, walletId, type, status)
        /// </summary>
        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions([FromQuery] TransactionSearchRequest request)
        {
            _logger.LogInformation("API GetTransactions called with parameters: {@Request}", request);

            // Security: If not admin, can only see own transactions
            if (CurrentUserRole != SmartRecruit.Domain.Enums.UserRole.ADMIN)
            {
                request.UserId = CurrentUserId;
            }

            var transactions = await _walletService.GetTransactionsAsync(request);
            return Ok(transactions.WrapPaged());
        }

        /// <summary>
        /// Lấy danh sách Transaction của một User cụ thể
        /// </summary>
        [HttpGet("user/{userId}/transactions")]
        public async Task<IActionResult> GetTransactionsByUser(long userId, [FromQuery] TransactionSearchRequest request)
        {
            _logger.LogInformation("API GetTransactionsByUser called for UserId: {UserId}, Page: {Page}, PageSize: {PageSize}", userId, request.Page, request.PageSize);
            // Overwrite UserId in request with the one from route
            request.UserId = userId;
            var transactions = await _walletService.GetTransactionsAsync(request);
            return Ok(transactions.WrapPaged());
        }

        /// <summary>
        /// Xuất danh sách Transaction ra file Excel
        /// </summary>
        [HttpGet("transactions/export")]
        public async Task<IActionResult> ExportTransactions([FromQuery] TransactionSearchRequest request)
        {
            _logger.LogInformation("API ExportTransactions called with parameters: {@Request}", request);

            // Security: If not admin, can only export own transactions
            if (CurrentUserRole != SmartRecruit.Domain.Enums.UserRole.ADMIN)
            {
                request.UserId = CurrentUserId;
            }

            var fileContent = await _walletService.ExportTransactionsToExcelAsync(request);
            var fileName = $"Transactions_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
