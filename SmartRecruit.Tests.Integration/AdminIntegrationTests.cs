using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Utils;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Infrastructure.Data;
using Xunit;

namespace SmartRecruit.Tests.Integration
{
    [Trait("Category", "Integration")]
    public class AdminIntegrationTests : IntegrationTestBase
    {
        public AdminIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password)
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        private async Task SeedUsersAsync()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                var admin = new User 
                { 
                    Email = "admin_test@admin.com", 
                    FullName = "Admin", 
                    Role = UserRole.ADMIN, 
                    IsActive = true, 
                    EmailVerified = true, 
                    PasswordHash = PasswordUtil.HashPassword("password") 
                };

                var recruiter = new User 
                { 
                    Email = "recruiter_test@admin.com", 
                    FullName = "Recruiter", 
                    Role = UserRole.RECRUITER, 
                    IsActive = true, 
                    EmailVerified = true, 
                    PasswordHash = PasswordUtil.HashPassword("password") 
                };

                if (!context.Users.Any(u => u.Email == admin.Email)) context.Users.Add(admin);
                if (!context.Users.Any(u => u.Email == recruiter.Email)) context.Users.Add(recruiter);
                
                await context.SaveChangesAsync();

                // Seed wallet for admin to prevent 500 in FinanceStats
                if (!context.Wallets.Any(w => w.UserId == admin.Id))
                {
                    context.Wallets.Add(new Wallet { UserId = admin.Id, Balance = 0m });
                    await context.SaveChangesAsync();
                }
            }
        }

        [Fact]
        public async Task AdminRoutes_ShouldReturnForbidden_WhenUserIsNotAdmin()
        {
            // Arrange
            await SeedUsersAsync();

            var token = await LoginAsAsync("recruiter_test@admin.com", "password");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act & Assert for multiple routes
            var routes = new[] { "/api/Admin/users", "/api/Admin/finance/stats", "/api/Admin/content/ai-logs" };
            foreach (var route in routes)
            {
                var response = await _client.GetAsync(route);
                response.StatusCode.Should().Be(HttpStatusCode.Forbidden, $"Route {route} should be protected for non-admins.");
            }
        }

        [Fact(Skip = "SQLite in-memory provider has issues with SumAsync on decimal fields in this environment.")]
        public async Task GetFinanceStats_ShouldReturnSuccess_WhenInvokedByAdmin()
        {
            // Arrange
            await SeedUsersAsync();

            var token = await LoginAsAsync("admin_test@admin.com", "password");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/Admin/finance/stats");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetUsers_ShouldReturnUsers_WhenInvokedByAdmin()
        {
            // Arrange
            await SeedUsersAsync();
            var token = await LoginAsAsync("admin_test@admin.com", "password");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/Admin/users?Page=1&PageSize=10");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateUserStatus_ShouldLockUser_WhenInvokedByAdmin()
        {
             // Arrange
            await SeedUsersAsync();
            long targetUserId;
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var victim = new User 
                { 
                    Email = "victim@test.com", 
                    FullName = "Victim", 
                    Role = UserRole.CANDIDATE, 
                    IsActive = true, 
                    EmailVerified = true, 
                    PasswordHash = PasswordUtil.HashPassword("password") 
                };
                context.Users.Add(victim);
                await context.SaveChangesAsync();
                targetUserId = victim.Id;
            }

            var token = await LoginAsAsync("admin_test@admin.com", "password");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new UpdateUserStatusRequest { IsActive = false, LockReason = "Lock Reason" };

            // Act
            var response = await _client.PatchAsJsonAsync($"/api/Admin/users/{targetUserId}/status", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var updatedUser = await context.Users.FindAsync(targetUserId);
                updatedUser!.IsActive.Should().BeFalse();
            }
        }
    }
}
