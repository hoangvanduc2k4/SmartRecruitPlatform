using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IAILogRepository : IGenericRepository<AILog>
    {
        Task<PagedList<AILog>> GetAILogsAsync(AILogRequest request);
    }
}
