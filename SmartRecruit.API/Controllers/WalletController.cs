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
            _logger.LogInformation("API GetMyWallet called for UserId: {UserId}", CurrentUserId);
            var wallet = await _walletService.GetWalletByUserIdAsync(CurrentUserId);
            return Ok(wallet.Wrap());
        }

        /// <summary>
        /// Xem số dư Wallet của một User (Admin only hoặc internal)
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWalletByUserId(long userId)
        {
            _logger.LogInformation("API GetWalletByUserId called for UserId: {UserId}", userId);
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
            var searchRequest = request with { UserId = userId };
            var transactions = await _walletService.GetTransactionsAsync(searchRequest);
            return Ok(transactions.WrapPaged());
        }
    }
}
