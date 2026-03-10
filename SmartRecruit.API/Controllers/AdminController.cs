using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.DTO.Wallet;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IAILogService _aiLogService;
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAILogService aiLogService, IUserService userService, IWalletService walletService, ILogger<AdminController> logger)
        {
            _aiLogService = aiLogService;
            _userService = userService;
            _walletService = walletService;
            _logger = logger;
        }

        [HttpGet("content/ai-logs")]
        public async Task<IActionResult> GetAILogs([FromQuery] AILogRequest request)
        {
            _logger.LogInformation("API GetAILogs called with search parameters: {@Request}", request);
            var logs = await _aiLogService.GetAILogsAsync(request);
            var response = logs.WrapPaged("AI logs retrieved successfully");
            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] UserSearchRequest request)
        {
            _logger.LogInformation("API GetUsers called with parameters: {@Request}", request);
            var users = await _userService.GetUsersAsync(request);
            return Ok(users.WrapPaged("Users retrieved successfully"));
        }

        [HttpPatch("users/{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(long id, [FromBody] UpdateUserStatusRequest request)
        {
            _logger.LogInformation("API UpdateUserStatus called for UserId: {UserId}, Status: {IsActive}", id, request.IsActive);
            var success = await _userService.UpdateUserStatusAsync(id, request);
            string message = request.IsActive ? "User account activated successfully" : "User account locked successfully";
            return Ok(new { Success = success }.Wrap(message));
        }

        [HttpGet("finance/stats")]
        public async Task<IActionResult> GetFinanceStats()
        {
            _logger.LogInformation("API GetFinanceStats called");
            var stats = await _walletService.GetFinanceStatsAsync();
            return Ok(stats.Wrap("Finance statistics retrieved successfully"));
        }

        [HttpGet("finance/logs")]
        public async Task<IActionResult> GetFinanceLogs([FromQuery] TransactionSearchRequest request)
        {
            _logger.LogInformation("API GetFinanceLogs called with parameters: {@Request}", request);
            var logs = await _walletService.GetTransactionsAsync(request);
            return Ok(logs.WrapPaged("Financial logs retrieved successfully"));
        }
    }
}
