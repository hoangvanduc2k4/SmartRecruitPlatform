using FluentAssertions;
using Moq;
using AutoMapper;
using SmartRecruit.Application.DTO.AILog;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;
using System.Collections.Generic;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Tests.Unit.Services
{
    public class AILogServiceTests
    {
        private readonly Mock<IAILogRepository> _aiLogRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly AILogService _service;

        public AILogServiceTests()
        {
            _aiLogRepoMock = new Mock<IAILogRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new AILogService(_aiLogRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAILogsAsync_ShouldReturnPagedList()
        {
            // Arrange
            var request = new AILogRequest { JobId = 10L };
            var logs = new PagedList<AILog>(new List<AILog> { new AILog { Id = 1, JobId = 10 } }, 1, 1, 10);

            _aiLogRepoMock.Setup(r => r.GetAILogsAsync(request)).ReturnsAsync(logs);
            _mapperMock.Setup(m => m.Map<List<AILogResponse>>(It.IsAny<List<AILog>>()))
                .Returns(new List<AILogResponse> { new AILogResponse { Id = 1 } });

            // Act
            var result = await _service.GetAILogsAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            _aiLogRepoMock.Verify(r => r.GetAILogsAsync(request), Times.Once);
        }
    }
}
