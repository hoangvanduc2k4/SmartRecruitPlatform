using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using AutoMapper;
using Hangfire;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
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
        private readonly Mock<ILogger<JobService>> _loggerMock;
        private readonly JobService _service;

        public JobServiceTests()
        {
            _jobRepoMock = new Mock<IJobRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _geminiMock = new Mock<IGeminiService>();
            _walletRepoMock = new Mock<IWalletRepository>();
            _aiLogRepoMock = new Mock<IAILogRepository>();
            _jobClientMock = new Mock<IBackgroundJobClient>();
            _loggerMock = new Mock<ILogger<JobService>>();

            _service = new JobService(
                _jobRepoMock.Object,
                _uowMock.Object,
                _mapperMock.Object,
                _geminiMock.Object,
                _walletRepoMock.Object,
                _aiLogRepoMock.Object,
                _jobClientMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task BoostJobAsync_ShouldThrowInvalidOperation_WhenInsufficientBalance()
        {
            // Arrange
            var userId = 1L;
            var jobId = 10L;
            var job = new Job { Id = jobId, RecruiterId = userId, IsAppealed = false };
            var wallet = new Wallet { UserId = userId, Balance = 5000 }; // Boost cost is 20000

            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _walletRepoMock.Setup(r => r.GetWalletByUserIdAsync(userId)).ReturnsAsync(wallet);

            // Act
            Func<Task> act = async () => await _service.BoostJobAsync(jobId, userId);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Insufficient balance*");
        }

        [Fact]
        public async Task BoostJobAsync_ShouldThrowUnauthorized_WhenUserIsNotOwner()
        {
            // Arrange
            var recruiterId = 1L;
            var otherUserId = 2L;
            var jobId = 10L;
            var job = new Job { Id = jobId, RecruiterId = recruiterId };

            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);

            // Act
            Func<Task> act = async () => await _service.BoostJobAsync(jobId, otherUserId);

            // Assert
            await act.Should().ThrowAsync<UnauthorizedAccessException>()
                .WithMessage("You can only boost your own jobs.");
        }

        [Fact]
        public async Task BoostJobAsync_ShouldSucceed_WhenDataIsValid()
        {
            // Arrange
            var userId = 1L;
            var jobId = 10L;
            var job = new Job { Id = jobId, RecruiterId = userId, IsAppealed = false };
            var wallet = new Wallet { Id = 101, UserId = userId, Balance = 50000 };

            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _walletRepoMock.Setup(r => r.GetWalletByUserIdAsync(userId)).ReturnsAsync(wallet);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.BoostJobAsync(jobId, userId);

            // Assert
            result.Should().BeTrue();
            wallet.Balance.Should().Be(30000); // 50000 - 20000
            job.BoostExpiryTime.Should().BeAfter(DateTime.UtcNow);
            _walletRepoMock.Verify(r => r.AddTransactionAsync(It.Is<Transaction>(t => t.Type == TransactionType.BOOST)), Times.Once);
        }

        [Fact]
        public async Task ModerateJobAsync_ShouldApproveJob_WhenAISaysSafe()
        {
            // Arrange
            var jobId = 10L;
            var job = new Job { Id = jobId, Title = "Safe Job", Description = "Safe Body", Status = JobStatus.CHECKING };
            var screeningResult = new JobScreeningResponse { IsSafe = true };

            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _geminiMock.Setup(g => g.CheckJobContentAsync(job.Title, job.Description)).ReturnsAsync(screeningResult);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            await _service.ModerateJobAsync(jobId);

            // Assert
            job.Status.Should().Be(JobStatus.APPROVED);
            job.ModerationNote.Should().Be("Approved by AI.");
            _jobRepoMock.Verify(r => r.Update(job), Times.Once);
        }

        [Fact]
        public async Task ModerateJobAsync_ShouldBlockJob_WhenAISaysUnsafe()
        {
            // Arrange
            var jobId = 10L;
            var job = new Job { Id = jobId, Title = "Scam", Description = "Send money", Status = JobStatus.CHECKING };
            var screeningResult = new JobScreeningResponse { IsSafe = false, ViolationType = "Scam", Analysis = "Fraud detected" };

            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _geminiMock.Setup(g => g.CheckJobContentAsync(job.Title, job.Description)).ReturnsAsync(screeningResult);
            _uowMock.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            await _service.ModerateJobAsync(jobId);

            // Assert
            job.Status.Should().Be(JobStatus.BLOCKED);
            job.ModerationNote.Should().Contain("Blocked by AI");
            _jobRepoMock.Verify(r => r.Update(job), Times.Once);
        }

        [Fact]
        public async Task ModerateJobAsync_ShouldRethrow_WhenTransientAIError()
        {
            // Arrange
            var jobId = 10L;
            var job = new Job { Id = jobId, Title = "Title", Status = JobStatus.CHECKING };
            
            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _geminiMock.Setup(g => g.CheckJobContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("429 Too Many Requests"));

            // Act
            Func<Task> act = async () => await _service.ModerateJobAsync(jobId);

            // Assert
            await act.Should().ThrowAsync<Exception>();
            job.Status.Should().Be(JobStatus.CHECKING); // Should NOT change status if re-thrown
        }

        [Fact]
        public async Task ModerateJobAsync_ShouldBlockJob_WhenPermanentAIError()
        {
            // Arrange
            var jobId = 10L;
            var job = new Job { Id = jobId, Title = "Title", Status = JobStatus.CHECKING };
            
            _jobRepoMock.Setup(r => r.GetByIdAsync(jobId)).ReturnsAsync(job);
            _geminiMock.Setup(g => g.CheckJobContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Some permanent error like invalid API key"));

            // Act
            await _service.ModerateJobAsync(jobId);

            // Assert
            job.Status.Should().Be(JobStatus.BLOCKED);
            job.ModerationNote.Should().Contain("AI Check Failed");
            _jobRepoMock.Verify(r => r.Update(job), Times.Once);
        }
    }
}
