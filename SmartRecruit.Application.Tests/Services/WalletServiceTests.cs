using AutoMapper;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Services;
using SmartRecruit.Domain.Entities;
using Xunit;

namespace SmartRecruit.Application.Tests.Services
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
            _service = new WalletService(_walletRepoMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetWalletByUserIdAsync_WhenExists_ShouldReturnWallet()
        {
            // Arrange
            var wallet = new Wallet { Id = 1, UserId = 1, Balance = 1000 };
            _walletRepoMock.Setup(x => x.GetWalletByUserIdAsync(1)).ReturnsAsync(wallet);
            _mapperMock.Setup(x => x.Map<WalletResponse>(wallet))
                .Returns(new WalletResponse(1, 1, "Test User", "test@example.com", 1000m, "VND", DateTime.UtcNow));

            // Act
            var result = await _service.GetWalletByUserIdAsync(1);

            // Assert
            result.Balance.Should().Be(1000);
            _walletRepoMock.Verify(x => x.GetWalletByUserIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task GetWalletByUserIdAsync_WhenNotExists_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _walletRepoMock.Setup(x => x.GetWalletByUserIdAsync(1)).ReturnsAsync((Wallet?)null);

            // Act
            Func<Task> act = async () => await _service.GetWalletByUserIdAsync(1);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
