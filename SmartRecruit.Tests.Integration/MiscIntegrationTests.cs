using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
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
    public class MiscIntegrationTests : IntegrationTestBase
    {
        public MiscIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password = "password123")
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        [Fact]
        public async Task GetCategories_ShouldReturnCategories_WhenCalled()
        {
            // Act
            var response = await _client.GetAsync("/api/categories");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<Category>>>();
            result!.Data.Should().NotBeEmpty();
            result.Data.Any(c => c.Name == "IT").Should().BeTrue();
        }

        [Fact]
        public async Task GetNotifications_ShouldReturnNotifications_WhenUserHasThem()
        {
            // Arrange
            string email = "user_notif@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "Notif User",
                        Role = UserRole.CANDIDATE,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                    context.Notifications.Add(new Notification
                    {
                        UserId = user.Id,
                        Title = "Test Notif",
                        Message = "Integration test notification",
                        IsRead = false,
                        CreatedAt = DateTime.UtcNow
                    });
                    await context.SaveChangesAsync();
                }
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/notifications");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            body.Should().Contain("Test Notif");
        }

        [Fact]
        public async Task MarkAsRead_ShouldUpdateStatus_WhenRequested()
        {
            // Arrange
            string email = "user_read@app.com";
            long notifId;
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
                        FullName = "Read User",
                        Role = UserRole.CANDIDATE,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                }
                userId = user.Id;

                var notif = new Notification
                {
                    UserId = userId,
                    Title = "To Read",
                    Message = "Mark me",
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };
                context.Notifications.Add(notif);
                await context.SaveChangesAsync();
                notifId = notif.Id;
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.PatchAsync($"/api/notifications/{notifId}/read", null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var updated = await context.Notifications.FindAsync(notifId);
                updated!.IsRead.Should().BeTrue();
            }
        }
    }
}
