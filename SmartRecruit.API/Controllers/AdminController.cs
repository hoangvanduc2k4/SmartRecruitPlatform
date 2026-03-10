using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IAILogService _aiLogService;
        private readonly IUserService _userService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAILogService aiLogService, IUserService userService, ILogger<AdminController> logger)
        {
            _aiLogService = aiLogService;
            _userService = userService;
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
    }
}
