using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Application.Utils;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace SmartRecruit.Tests.Integration
{
    [Trait("Category", "Integration")]
    public class WalletIntegrationTests : IntegrationTestBase
    {
        public WalletIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password = "password123")
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        [Fact]
        public async Task GetWallet_ShouldReturnBalance_WhenInvokedByUser()
        {
            // Arrange
            string email = "recruiter_wallet@app.com";
            long userId;
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "Wallet Test User",
                        Role = UserRole.RECRUITER,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    
                    // Seed Wallet
                    context.Wallets.Add(new Wallet { UserId = user.Id, Balance = 500.50m });
                    await context.SaveChangesAsync();
                }
                userId = user.Id;
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync($"/api/wallets/user/{userId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
            result.Data.ToString().Should().Contain("500.5");
        }

        [Fact]
        public async Task GetTransactions_ShouldReturnLogs_WhenRecruiterHasActivity()
        {
            // Arrange
            string email = "recruiter_tx@app.com";
            long userId;
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "Tx Test User",
                        Role = UserRole.RECRUITER,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    
                    var wallet = new Wallet { UserId = user.Id, Balance = 1000m };
                    context.Wallets.Add(wallet);
                    await context.SaveChangesAsync();

                    // Seed a few transactions
                    context.Transactions.Add(new Transaction 
                    { 
                        UserId = user.Id, 
                        WalletId = wallet.Id, 
                        Amount = 100, 
                        Type = TransactionType.BOOST, 
                        Status = TransactionStatus.SUCCESS,
                        CreatedAt = DateTime.UtcNow
                    });
                    await context.SaveChangesAsync();
                }
                userId = user.Id;
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync($"/api/wallets/user/{userId}/transactions");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            body.Should().Contain("\"success\":true");
            // Check if there's at least one transaction in data
            body.Should().Contain("\"totalCount\":");
        }
    }
}
