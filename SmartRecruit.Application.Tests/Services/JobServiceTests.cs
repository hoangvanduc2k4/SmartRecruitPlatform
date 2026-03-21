using AutoMapper;
using FluentAssertions;
using Hangfire;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Application.Tests.Extensions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Domain.Tests.Helpers;
using Xunit;

namespace SmartRecruit.Application.Tests.Services
{
    public class JobServiceTests
    {
        private readonly Mock<IJobRepository> _jobRepoMock;
        private readonly Mock<IUnitOfWork> _uowMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGeminiService> _geminiMock;
        private readonly Mock<IWalletRepository> _walletRepoMock;
        private readonly Mock<IAILogRepository> _aiLogRepoMock;
        private readonly Mock<IBackgroundJobClient> _jobClientMock;
        private readonly Mock<INotificationService> _notificationMock;
        private readonly Mock<ILogger<JobService>> _loggerMock;
        private readonly JobService _service;

        public JobServiceTests()
        {
            _jobRepoMock = new Mock<IJobRepository>();
            _uowMock = new Mock<IUnitOfWork>().SetupMockUnitOfWork();
            _mapperMock = new Mock<IMapper>();
            _geminiMock = new Mock<IGeminiService>().SetupMockGeminiService();
            _walletRepoMock = new Mock<IWalletRepository>();
            _aiLogRepoMock = new Mock<IAILogRepository>();
            _jobClientMock = new Mock<IBackgroundJobClient>();
            _notificationMock = new Mock<INotificationService>();
            _loggerMock = new Mock<ILogger<JobService>>();

            _service = new JobService(
                _jobRepoMock.Object,
                _uowMock.Object,
                _mapperMock.Object,
                _geminiMock.Object,
                _walletRepoMock.Object,
                _aiLogRepoMock.Object,
                _jobClientMock.Object,
                _notificationMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task CreateJobAsync_ShouldSucceed_AsDraft()
        {
            // Arrange
            var request = new JobCreateRequest(
                "New Job", "Company", "Benefits", 1, "Desc", "Req", "Skills", 1000, 5000, JobType.FULL_TIME, "Location", 1);
            
            _jobRepoMock.Setup(x => x.AddAsync(It.IsAny<Job>()))
                .Callback<Job>(j => j.Id = 1);
            _jobRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(new Job { Id = 1, Status = JobStatus.DRAFT });

            // Act
            var result = await _service.CreateJobAsync(request);

            // Assert
            _jobRepoMock.Verify(x => x.AddAsync(It.Is<Job>(j => j.Status == JobStatus.DRAFT)), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task ModerateJobAsync_WhenSafe_ShouldApprove()
        {
            // Arrange
            var job = new Job { Id = 1, Title = "Safe Job", Description = "Safe Desc", RecruiterId = 1 };
            _jobRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(job);

            // Act
            await _service.ModerateJobAsync(1);

            // Assert
            job.Status.Should().Be(JobStatus.APPROVED);
            _aiLogRepoMock.Verify(x => x.AddAsync(It.IsAny<AILog>()), Times.Once);
            _jobRepoMock.Verify(x => x.Update(job), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task PublishJobAsync_WhenInsufficientBalance_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var job = new Job { Id = 1, Status = JobStatus.DRAFT, RecruiterId = 1 };
            var wallet = new Wallet { UserId = 1, Balance = 10000 }; // Needs 50k
            
            _jobRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(job);
            _walletRepoMock.Setup(x => x.GetWalletByUserIdAsync(1)).ReturnsAsync(wallet);

            // Act
            Func<Task> act = async () => await _service.PublishJobAsync(1, 1);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Insufficient balance to publish.");
        }

        [Fact]
        public async Task PublishJobAsync_WhenSufficientBalance_ShouldDeductAndEnqueue()
        {
            // Arrange
            var job = new Job { Id = 1, Status = JobStatus.DRAFT, RecruiterId = 1, Title = "Job" };
            var wallet = new Wallet { UserId = 1, Balance = 100000 };
            
            _jobRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(job);
            _walletRepoMock.Setup(x => x.GetWalletByUserIdAsync(1)).ReturnsAsync(wallet);

            // Act
            var result = await _service.PublishJobAsync(1, 1);

            // Assert
            wallet.Balance.Should().Be(50000);
            job.Status.Should().Be(JobStatus.CHECKING);
            _walletRepoMock.Verify(x => x.AddTransactionAsync(It.IsAny<Transaction>()), Times.Once);
            _uowMock.Verify(x => x.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task SaveDraftAsync_WhenApprovedJob_ShouldSaveToDraftChanges()
        {
            // Arrange
            var job = new Job { Id = 1, Status = JobStatus.APPROVED, RecruiterId = 1 };
            _jobRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(job);
            
            var request = new JobDraftRequest { Title = "Updated Title" };

            // Act
            await _service.SaveDraftAsync(1, request, 1);

            // Assert
            job.DraftChanges.Should().NotBeNull();
            job.Title.Should().NotBe("Updated Title"); // Should not update main title yet
            _jobRepoMock.Verify(x => x.Update(job), Times.Once);
        }

        [Fact]
        public async Task GetRecruiterStatsAsync_ShouldReturnStats()
        {
            // Arrange
            var stats = new RecruiterStatsResponse(100, 20, 50, 2.5);
            _jobRepoMock.Setup(x => x.GetRecruiterStatsAsync(1)).ReturnsAsync(stats);

            // Act
            var result = await _service.GetRecruiterStatsAsync(1);

            // Assert
            result.TotalViews.Should().Be(100);
            result.TotalApplications.Should().Be(50);
        }
    }
}
