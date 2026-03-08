using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IAILogService
    {
        Task<PagedList<AILogResponse>> GetAILogsAsync(AILogRequest request);
    }
}
