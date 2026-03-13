using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;

namespace SmartRecruit.Tests.Unit.Services
{
    public class WalletServiceTests
    {
        private readonly Mock<IWalletRepository> _walletRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<WalletService>> _loggerMock;
        private readonly WalletService _service;

        public WalletServiceTests()
        {
            _walletRepoMock = new Mock<IWalletRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<WalletService>>();

            _service = new WalletService(
                _walletRepoMock.Object,
                _mapperMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task GetWalletByUserIdAsync_ShouldThrowKeyNotFound_WhenWalletDoesNotExist()
        {
            // Arrange
            _walletRepoMock.Setup(r => r.GetWalletByUserIdAsync(It.IsAny<long>())).ReturnsAsync((Wallet)null);

            // Act
            Func<Task> act = async () => await _service.GetWalletByUserIdAsync(1);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Wallet not found for user 1");
        }

        [Fact]
        public async Task GetWalletByUserIdAsync_ShouldReturnResponse_WhenWalletExists()
        {
            // Arrange
            var userId = 1L;
            var wallet = new Wallet { Id = 10, UserId = userId, Balance = 1000 };
            var response = new WalletResponse(10, userId, "Test User", "test@example.com", 1000, "VND", DateTime.UtcNow);

            _walletRepoMock.Setup(r => r.GetWalletByUserIdAsync(userId)).ReturnsAsync(wallet);
            _mapperMock.Setup(m => m.Map<WalletResponse>(wallet)).Returns(response);

            // Act
            var result = await _service.GetWalletByUserIdAsync(userId);

            // Assert
            result.Should().NotBeNull();
            result.Balance.Should().Be(1000);
        }
    }
}
