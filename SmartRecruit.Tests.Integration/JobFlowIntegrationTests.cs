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
    public class JobFlowIntegrationTests : IntegrationTestBase
    {
        public JobFlowIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password = "password123")
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        [Fact]
        public async Task ToggleSaveJob_ShouldWorkCorrectly()
        {
            // Arrange
            string email = "candidate_save@app.com";
            long jobId = 1; // Seeded Job
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "Save Job User",
                        Role = UserRole.CANDIDATE,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                }
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act - Save Job
            var saveResponse = await _client.PostAsync($"/api/jobs/{jobId}/save", null);
            saveResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Act - Check if saved
            var getSavedResponse = await _client.GetAsync("/api/jobs/saved");
            getSavedResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await getSavedResponse.Content.ReadAsStringAsync();
            body.Should().Contain("\"totalCount\":1");

            // Act - Unsave
            await _client.PostAsync($"/api/jobs/{jobId}/save", null);
            
            // Assert
            var finalSavedResponse = await _client.GetAsync("/api/jobs/saved");
            var finalBody = await finalSavedResponse.Content.ReadAsStringAsync();
            finalBody.Should().Contain("\"totalCount\":0");
        }

        [Fact]
        public async Task AppealJob_ShouldSetAppealedFlag()
        {
            // Arrange
            long jobId = 1; // Seeded Job
            var message = "I believe this job was blocked unfairly.";

            // Act
            var response = await _client.PostAsJsonAsync($"/api/jobs/{jobId}/appeal", message);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var job = await context.Jobs.FindAsync(jobId);
                job!.IsAppealed.Should().BeTrue();
                job.AppealMessage.Should().Be(message);
            }
        }
    }
}
