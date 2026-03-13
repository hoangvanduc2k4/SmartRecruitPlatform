using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Payment;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Infrastructure.Data;
using Xunit;

namespace SmartRecruit.Tests.Integration
{
    public class PaymentControllerIntegrationTests : IntegrationTestBase
    {
        public PaymentControllerIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Webhook_ShouldUpdateWallet_WhenPaymentIsSuccessful()
        {
            // Arrange
            var orderCode = 123456789L;
            var amount = 50000m;
            long userId;

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                // Create a user and a wallet
                var user = new User { Email = "pay@test.com", FullName = "Pay Test", Role = UserRole.RECRUITER, IsActive = true, EmailVerified = true, PasswordHash = "hash" };
                context.Users.Add(user);
                await context.SaveChangesAsync();
                userId = user.Id;

                var wallet = new Wallet { UserId = user.Id, Balance = 0 };
                context.Wallets.Add(wallet);
                await context.SaveChangesAsync();

                // Create a pending transaction
                var transaction = new Transaction
                {
                    UserId = user.Id,
                    WalletId = wallet.Id,
                    Amount = amount,
                    OrderCode = orderCode,
                    Type = TransactionType.TOPUP,
                    Status = TransactionStatus.PENDING
                };
                context.Transactions.Add(transaction);
                await context.SaveChangesAsync();
            }

            var webhookBody = new PayOSWebhookBody
            {
                Code = "00",
                Success = true,
                Data = new PayOSWebhookData
                {
                    OrderCode = orderCode,
                    Amount = (int)amount,
                    Description = "Topup 50k"
                }
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/payment/webhook", webhookBody);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var dbTransaction = await context.Transactions.FirstOrDefaultAsync(t => t.OrderCode == orderCode);
                dbTransaction.Should().NotBeNull();
                dbTransaction!.Status.Should().Be(TransactionStatus.SUCCESS);

                var dbWallet = await context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
                dbWallet.Should().NotBeNull();
                dbWallet!.Balance.Should().Be(amount);
            }
        }

        [Fact]
        public async Task PaymentSuccess_ShouldConfirmPayment_WhenOrderIsPaidOnPayOS()
        {
            // Arrange
            var orderCode = 987654321L;
            var amount = 100000m;
            long userId;

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = new User { Email = "confirm@test.com", FullName = "Confirm Test", Role = UserRole.RECRUITER, IsActive = true, EmailVerified = true, PasswordHash = "hash" };
                context.Users.Add(user);
                await context.SaveChangesAsync();
                userId = user.Id;

                var wallet = new Wallet { UserId = userId, Balance = 0 };
                context.Wallets.Add(wallet);
                await context.SaveChangesAsync();

                var transaction = new Transaction
                {
                    UserId = userId,
                    WalletId = wallet.Id,
                    Amount = amount,
                    OrderCode = orderCode,
                    Type = TransactionType.TOPUP,
                    Status = TransactionStatus.PENDING
                };
                context.Transactions.Add(transaction);
                await context.SaveChangesAsync();
            }

            // Act
            var response = await _client.GetAsync($"/api/payment/success?orderCode={orderCode}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Payment confirmed");

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var dbTransaction = await context.Transactions.FirstOrDefaultAsync(t => t.OrderCode == orderCode);
                dbTransaction!.Status.Should().Be(TransactionStatus.SUCCESS);

                var dbWallet = await context.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
                dbWallet!.Balance.Should().Be(amount);
            }
        }
    }
}
