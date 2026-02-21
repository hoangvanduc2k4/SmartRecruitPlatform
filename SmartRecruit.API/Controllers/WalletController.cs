using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        /// <summary>
        /// Xem số dư Wallet của một User
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
            var transactions = await _walletService.GetTransactionsAsync(request);
            return Ok(transactions.WrapPaged());
        }

        /// <summary>
        /// Lấy danh sách Transaction của một User cụ thể
        /// </summary>
        [HttpGet("user/{userId}/transactions")]
        public async Task<IActionResult> GetTransactionsByUser(long userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new TransactionSearchRequest(userId, null, null, null, page, pageSize);
            var transactions = await _walletService.GetTransactionsAsync(request);
            return Ok(transactions.WrapPaged());
        }
    }
}
