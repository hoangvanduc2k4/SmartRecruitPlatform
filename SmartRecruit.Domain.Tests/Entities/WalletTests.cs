using FluentAssertions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Tests.Helpers;
using Xunit;

namespace SmartRecruit.Domain.Tests.Entities
{
    public class WalletTests
    {
        [Fact]
        public void Wallet_Should_Initialize_With_Default_Values()
        {
            // Act
            var wallet = new Wallet();

            // Assert
            wallet.Balance.Should().Be(0);
            wallet.Currency.Should().Be("VND");
            wallet.Transactions.Should().NotBeNull();
        }

        [Theory]
        [InlineData(100.50)]
        [InlineData(5000000.00)]
        public void Wallet_Should_Correctly_Set_Balance(decimal balance)
        {
            // Arrange
            var wallet = TestHelper.CreateWallet();

            // Act
            wallet.Balance = balance;

            // Assert
            wallet.Balance.Should().Be(balance);
        }
    }
}
