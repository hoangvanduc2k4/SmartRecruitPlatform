using AutoMapper;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class AILogService : IAILogService
    {
        private readonly IAILogRepository _aiLogRepository;
        private readonly IMapper _mapper;

        public AILogService(IAILogRepository aiLogRepository, IMapper mapper)
        {
            _aiLogRepository = aiLogRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<AILogResponse>> GetAILogsAsync(AILogRequest request)
        {
            var logs = await _aiLogRepository.GetAILogsAsync(request);
            return logs.MapToPagedList<AILog, AILogResponse>(_mapper);
        }

    }
}
