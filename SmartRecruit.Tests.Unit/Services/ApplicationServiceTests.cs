using FluentAssertions;
using Moq;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using Microsoft.Extensions.Logging;
using Hangfire;
using AutoMapper;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class ApplicationServiceTests
    {
        private readonly Mock<IApplicationRepository> _appRepoMock;
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGeminiService> _geminiMock;
        private readonly Mock<IBackgroundJobClient> _jobClientMock;
        private readonly Mock<ILogger<ApplicationService>> _loggerMock;
        private readonly ApplicationService _service;

        public ApplicationServiceTests()
        {
            _appRepoMock = new Mock<IApplicationRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _geminiMock = new Mock<IGeminiService>();
            _jobClientMock = new Mock<IBackgroundJobClient>();
            _loggerMock = new Mock<ILogger<ApplicationService>>();

            _service = new ApplicationService(
                _appRepoMock.Object,
                _uowMock.Object,
                _mapperMock.Object,
                _geminiMock.Object,
                _jobClientMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowInvalidOperation_WhenTransitionIsSkipped()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.OFFERED }; // Reviewing(0) -> Offered(2) is a skip

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Invalid status transition*");
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowInvalidOperation_WhenMovingToInterviewingWithoutDate()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.INTERVIEWING }; // No InterviewDate

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Interview date is required*");
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowInvalidOperation_WhenRejectingWithoutReason()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.REJECTED }; // No RejectionReason

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Rejection reason is required*");
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldSucceed_WhenValidTransition()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            var request = new UpdateApplicationStatusRequest 
            { 
                Status = ApplicationStatus.INTERVIEWING, 
                InterviewDate = DateTime.Now.AddDays(1) 
            };

            // Act
            var result = await _service.UpdateStatusAsync(1, request);

            // Assert
            result.Should().BeTrue();
            app.Status.Should().Be(ApplicationStatus.INTERVIEWING);
            app.Notes.Should().Contain("Interview Date:");
            _appRepoMock.Verify(r => r.Update(app), Times.Once);
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldSucceed_WhenRejectingFromInterviewing()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.INTERVIEWING };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            var request = new UpdateApplicationStatusRequest 
            { 
                Status = ApplicationStatus.REJECTED, 
                RejectionReason = "Not qualified" 
            };

            // Act
            var result = await _service.UpdateStatusAsync(1, request);

            // Assert
            result.Should().BeTrue();
            app.Status.Should().Be(ApplicationStatus.REJECTED);
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldThrowInvalidOperation_WhenAlreadyRejected()
        {
            // Arrange
            var app = new Applications { Id = 1, Status = ApplicationStatus.REJECTED };
            _appRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(app);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.REJECTED };

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Application is already rejected.");
        }

        [Fact]
        public async Task ApplyJobAsync_ShouldThrowInvalidOperation_WhenDuplicateApplication()
        {
            // Arrange
            var request = new ApplyJobRequest(10, 5);
            _appRepoMock.Setup(r => r.IsAlreadyAppliedAsync(10, 5)).ReturnsAsync(true);

            // Act
            Func<Task> act = async () => await _service.ApplyJobAsync(request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("You have already applied for this job.");
        }
    }
}
