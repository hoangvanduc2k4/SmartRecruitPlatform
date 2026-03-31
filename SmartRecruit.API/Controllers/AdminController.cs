
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
    public class AdminController : BaseController
    {
        private readonly IAILogService _aiLogService;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;
        private readonly IWalletService _walletService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAILogService aiLogService, IUserService userService, IJobService jobService, IWalletService walletService, ILogger<AdminController> logger)
        {
            _aiLogService = aiLogService;
            _userService = userService;
            _jobService = jobService;
            _walletService = walletService;
            _logger = logger;
        }

        [HttpGet("content/ai-logs")]
        public async Task<IActionResult> GetAILogs([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] long? jobId = null)
        {
            _logger.LogInformation("API GetAILogs called with page: {Page}, pageSize: {PageSize}, jobId: {JobId}", page, pageSize, jobId);
            var request = new AILogRequest { Page = page, PageSize = pageSize, JobId = jobId };
            var logs = await _aiLogService.GetAILogsAsync(request);
            var response = logs.WrapPaged("Tải nhật ký AI thành công");
            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] UserSearchRequest request)
        {
            _logger.LogInformation("API GetUsers called with parameters: {@Request}", request);
            var users = await _userService.GetUsersAsync(request);
            return Ok(users.WrapPaged("Tải danh sách người dùng thành công"));
        }

        [HttpPatch("users/{id}/status")]
        public async Task<IActionResult> UpdateUserStatus(long id, [FromBody] UpdateUserStatusRequest request)
        {
            _logger.LogInformation("API UpdateUserStatus called for UserId: {UserId}, Status: {IsActive}", id, request.IsActive);
            var success = await _userService.UpdateUserStatusAsync(id, request);
            string message = request.IsActive ? "Kích hoạt tài khoản người dùng thành công" : "Khóa tài khoản người dùng thành công";
            return Ok(new { Success = success }.Wrap(message));
        }

        [HttpGet("finance/stats")]
        public async Task<IActionResult> GetFinanceStats()
        {
            _logger.LogInformation("API GetFinanceStats called");
            var stats = await _walletService.GetFinanceStatsAsync();
            return Ok(stats.Wrap("Tải thống kê tài chính thành công"));
        }

        [HttpGet("users/stats")]
        public async Task<IActionResult> GetUserStats()
        {
            _logger.LogInformation("API GetUserStats called");
            var stats = await _userService.GetAdminUserStatsAsync();
            return Ok(stats.Wrap("Tải thống kê người dùng thành công"));
        }

        [HttpGet("users/export")]
        public async Task<IActionResult> ExportUsers([FromQuery] UserSearchRequest request)
        {
            _logger.LogInformation("API ExportUsers called with Filter: {@Request}", request);
            var fileContent = await _userService.ExportUsersToExcelAsync(request);
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"SmartRecruit_Users_{DateTime.Now:yyyyMMdd}.xlsx");
        }

        [HttpGet("jobs/stats")]
        public async Task<IActionResult> GetJobStats()
        {
            _logger.LogInformation("API GetJobStats called");
            var stats = await _jobService.GetAdminJobStatsAsync();
            return Ok(stats.Wrap("Tải thống kê công việc thành công"));
        }

        [HttpGet("finance/weekly-revenue")]
        public async Task<IActionResult> GetWeeklyRevenue()
        {
            _logger.LogInformation("API GetWeeklyRevenue called");
            var revenue = await _walletService.GetWeeklyRevenueAsync();
            return Ok(revenue.Wrap("Tải doanh thu tuần thành công"));
        }

        [HttpGet("finance/logs")]
        public async Task<IActionResult> GetFinanceLogs([FromQuery] TransactionSearchRequest request)
        {
            _logger.LogInformation("API GetFinanceLogs called with parameters: {@Request}", request);
            var logs = await _walletService.GetTransactionsAsync(request);
            return Ok(logs.WrapPaged("Tải nhật ký tài chính thành công"));
        }

        [HttpGet("content/appeals")]
        public async Task<IActionResult> GetAppeals([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("API GetAppeals called with page: {Page}", page);
            var appeals = await _jobService.GetAppealedJobsAsync(page, pageSize);
            return Ok(appeals.WrapPaged("Tải danh sách khiếu nại thành công"));
        }

        [HttpPost("content/jobs/{id}/override-ai")]
        public async Task<IActionResult> OverrideAI(long id)
        {
            _logger.LogInformation("API OverrideAI called for JobId: {JobId}", id);
            var success = await _jobService.OverrideAIAsync(id);
            return Ok(new { Success = success }.Wrap("Đã ghi đè kiểm duyệt và phê duyệt công việc thành công"));
        }

        [HttpPost("content/jobs/{id}/reject-appeal")]
        public async Task<IActionResult> RejectAppeal(long id)
        {
            _logger.LogInformation("API RejectAppeal called for JobId: {JobId}", id);
            var success = await _jobService.RejectAppealAsync(id);
            return Ok(new { Success = success }.Wrap("Từ chối khiếu nại thành công"));
        }

    }
}
