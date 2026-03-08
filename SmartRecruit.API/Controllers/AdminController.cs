using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAILogService _aiLogService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAILogService aiLogService, ILogger<AdminController> logger)
        {
            _aiLogService = aiLogService;
            _logger = logger;
        }

        [HttpGet("content/ai-logs")]
        public async Task<IActionResult> GetAILogs([FromQuery] AILogRequest request)
        {
            _logger.LogInformation("API GetAILogs called with search parameters: {@Request}", request);
            var logs = await _aiLogService.GetAILogsAsync(request);
            var response = logs.WrapPaged();
            return Ok(response);
        }
    }
}
