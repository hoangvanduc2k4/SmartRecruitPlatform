using FluentAssertions;
using Moq;
using AutoMapper;
using SmartRecruit.Application.DTO.Report;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;
using System.Collections.Generic;

namespace SmartRecruit.Tests.Unit.Services
{
    public class ReportServiceTests
    {
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IGenericRepository<Report>> _reportRepoMock;
        private readonly Mock<IJobRepository> _jobRepoMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ReportService _service;

        public ReportServiceTests()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _reportRepoMock = new Mock<IGenericRepository<Report>>();
            _jobRepoMock = new Mock<IJobRepository>();
            _userRepoMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();

            _uowMock.Setup(u => u.Reports).Returns(_reportRepoMock.Object);
            _uowMock.Setup(u => u.Jobs).Returns(_jobRepoMock.Object);
            _uowMock.Setup(u => u.Users).Returns(_userRepoMock.Object);

            _service = new ReportService(_uowMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetReportsAsync_ShouldReturnPagedList()
        {
            // Arrange
            var reports = new List<Report>
            {
                new Report { Id = 1, JobId = 10, ReporterId = 100, Reason = "Spam", CreatedAt = DateTime.UtcNow }
            };
            var job = new Job { Id = 10, Title = "Spam Job" };
            var reporter = new User { Id = 100, FullName = "Reporter One" };

            _reportRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(reports.AsQueryable());
            _jobRepoMock.Setup(r => r.GetByIdAsync(10L)).ReturnsAsync(job);
            _userRepoMock.Setup(r => r.GetByIdAsync(100L)).ReturnsAsync(reporter);

            // Act
            var result = await _service.GetReportsAsync(1, 10);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].JobTitle.Should().Be("Spam Job");
            result[0].ReporterName.Should().Be("Reporter One");
        }
    }
}
