using Microsoft.Extensions.Logging;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class AILogRepository : GenericRepository<AILog>, IAILogRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AILogRepository> _logger;

        public AILogRepository(ApplicationDbContext context, ILogger<AILogRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<AILog>> GetAILogsAsync(AILogRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch ai logs with parameters: {@Request}", request);

            var query = _context.AILogs.OrderByDescending(x => x.CreatedAt);
            return await PagedList<AILog>.CreateAsync(query, request.Page, request.PageSize);
        }
    }
}
