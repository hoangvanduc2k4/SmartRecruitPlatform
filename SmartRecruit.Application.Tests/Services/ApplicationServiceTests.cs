using AutoMapper;
using FluentAssertions;
using Hangfire;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Application.Tests.Extensions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Domain.Tests.Helpers;
using System.Linq.Expressions;
using Hangfire.States;
using Xunit;
using HangfireJob = Hangfire.Common.Job;

namespace SmartRecruit.Application.Tests.Services
{
    public class ApplicationServiceTests
    {
        private readonly Mock<IApplicationRepository> _applicationRepoMock;
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGeminiService> _geminiMock;
        private readonly Mock<IBackgroundJobClient> _jobClientMock;
        private readonly Mock<INotificationService> _notificationMock;
        private readonly Mock<ILogger<ApplicationService>> _loggerMock;
        private readonly ApplicationService _service;

        public ApplicationServiceTests()
        {
            _applicationRepoMock = new Mock<IApplicationRepository>().SetupMockApplicationRepository();
            _uowMock = new Mock<IUnitOfWork>().SetupMockUnitOfWork();
            _mapperMock = new Mock<IMapper>();
            _geminiMock = new Mock<IGeminiService>().SetupMockGeminiService();
            _jobClientMock = new Mock<IBackgroundJobClient>();
            _notificationMock = new Mock<INotificationService>();
            _loggerMock = new Mock<ILogger<ApplicationService>>();

            _service = new ApplicationService(
                _applicationRepoMock.Object,
                _uowMock.Object,
                _mapperMock.Object,
                _geminiMock.Object,
                _jobClientMock.Object,
                _notificationMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task ApplyJobAsync_WhenNotAppliedAndHasCV_ShouldSucceed()
        {
            // Arrange
            var request = new ApplyJobRequest(1, 1);
            _applicationRepoMock.Setup(x => x.IsAlreadyAppliedAsync(1, 1)).ReturnsAsync(false);
            
            var candidateProfile = new CandidateProfile { UserId = 1, CVText = "My Awesome CV" };
            _uowMock.Setup(x => x.CandidateProfiles.FindAsync(It.IsAny<Expression<Func<CandidateProfile, bool>>>()))
                .ReturnsAsync(candidateProfile);

            // Act
            var result = await _service.ApplyJobAsync(request);

            // Assert
            result.Should().BeTrue();
            _applicationRepoMock.Verify(x => x.AddAsync(It.IsAny<Applications>()), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
            _jobClientMock.Verify(x => x.Create(
                It.Is<HangfireJob>(j => j.Method.Name == nameof(IApplicationService.ScoreApplicationAsync)),
                It.IsAny<EnqueuedState>()), Times.Once);
        }

        [Fact]
        public async Task ApplyJobAsync_WhenAlreadyApplied_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var request = new ApplyJobRequest(1, 1);
            _applicationRepoMock.Setup(x => x.IsAlreadyAppliedAsync(1, 1)).ReturnsAsync(true);

            // Act
            Func<Task> act = async () => await _service.ApplyJobAsync(request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("You have already applied for this job.");
        }

        [Fact]
        public async Task ApplyJobAsync_WhenNoCV_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var request = new ApplyJobRequest(1, 1);
            _applicationRepoMock.Setup(x => x.IsAlreadyAppliedAsync(1, 1)).ReturnsAsync(false);
            _uowMock.Setup(x => x.CandidateProfiles.FindAsync(It.IsAny<Expression<Func<CandidateProfile, bool>>>()))
                .ReturnsAsync((CandidateProfile?)null);

            // Act
            Func<Task> act = async () => await _service.ApplyJobAsync(request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Please upload your CV in your profile before applying.");
        }

        [Fact]
        public async Task ScoreApplicationAsync_WhenSuccessful_ShouldUpdateApplication()
        {
            // Arrange
            var application = new Applications
            {
                Id = 1,
                Candidate = new User { CandidateProfile = new CandidateProfile { CVText = "Content" } },
                Job = new Job { Description = "Job" }
            };
            _applicationRepoMock.Setup(x => x.GetApplicationWithDetailsAsync(1)).ReturnsAsync(application);

            // Act
            await _service.ScoreApplicationAsync(1);

            // Assert
            application.MatchScore.Should().Be(85);
            application.AI_Summary.Should().Be("Good candidate");
            _applicationRepoMock.Verify(x => x.Update(application), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task ScoreApplicationAsync_WhenTransientError_ShouldThrowToRetry()
        {
            // Arrange
            var application = new Applications { Id = 1, Candidate = new User() };
            _applicationRepoMock.Setup(x => x.GetApplicationWithDetailsAsync(1)).ReturnsAsync(application);
            _geminiMock.Setup(x => x.ScoreCvAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("503 Service Unavailable"));

            // Act
            Func<Task> act = async () => await _service.ScoreApplicationAsync(1);

            // Assert
            await act.Should().ThrowAsync<Exception>();
        }
        [Fact]
        public async Task UpdateStatusAsync_WhenValidTransitionToInterviewing_ShouldSucceed()
        {
            // Arrange
            var application = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _applicationRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(application);
            _uowMock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);

            var request = new UpdateApplicationStatusRequest 
            { 
                Status = ApplicationStatus.INTERVIEWING, 
                InterviewDate = DateTime.UtcNow.AddDays(1) 
            };

            // Act
            var result = await _service.UpdateStatusAsync(1, request);

            // Assert
            result.Should().BeTrue();
            application.Status.Should().Be(ApplicationStatus.INTERVIEWING);
            application.Notes.Should().Contain("Interview Date");
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateStatusAsync_WhenInvalidTransition_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var application = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _applicationRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(application);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.OFFERED };

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("*Invalid status transition*");
        }

        [Fact]
        public async Task UpdateStatusAsync_WhenRejectedWithoutReason_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var application = new Applications { Id = 1, Status = ApplicationStatus.REVIEWING };
            _applicationRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(application);

            var request = new UpdateApplicationStatusRequest { Status = ApplicationStatus.REJECTED, RejectionReason = null };

            // Act
            Func<Task> act = async () => await _service.UpdateStatusAsync(1, request);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Rejection reason is required when rejecting an application.");
        }

        [Fact]
        public async Task BulkUpdateStatusAsync_ShouldReturnCorrectCount()
        {
            // Arrange
            var ids = new List<long> { 1, 2 };
            _applicationRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync((long id) => new Applications { Id = id, Status = ApplicationStatus.REVIEWING });
            _uowMock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);

            var request = new BulkUpdateApplicationStatusRequest 
            { 
                ApplicationIds = ids, 
                Status = ApplicationStatus.INTERVIEWING,
                InterviewDate = DateTime.UtcNow.AddDays(1)
            };

            // Act
            var result = await _service.BulkUpdateStatusAsync(request);

            // Assert
            result.Should().Be(2);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Exactly(2));
        }
    }
}
