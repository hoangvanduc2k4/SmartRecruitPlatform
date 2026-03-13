using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.DTO.Application;
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
    public class ApplicationIntegrationTests : IntegrationTestBase
    {
        public ApplicationIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password = "password123")
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        private async Task<(long JobId, string RecruiterEmail, string CandidateEmail, long CandidateId)> GetSeededDataAsync()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                // Use IDs from DbInitializer: Job=1, Recruiter=2, Candidate=52
                var job = await context.Jobs.Include(j => j.Recruiter).FirstOrDefaultAsync(j => j.Id == 1);
                var candidate = await context.Users.FirstOrDefaultAsync(u => u.Id == 52);

                return (job!.Id, job.Recruiter.Email, candidate!.Email, candidate.Id);
            }
        }

        [Fact]
        public async Task ApplyJob_ShouldSucceed_WhenRequestIsValid()
        {
            // Arrange
            var (jobId, _, candidateEmail, candidateId) = await GetSeededDataAsync();
            
            // Cleanup existing application for this pair to ensure test independence
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var existing = await context.Applications.FirstOrDefaultAsync(a => a.JobId == jobId && a.CandidateId == candidateId);
                if (existing != null)
                {
                    context.Applications.Remove(existing);
                    await context.SaveChangesAsync();
                }
            }

            var token = await LoginAsAsync(candidateEmail);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new ApplyJobRequest(jobId, candidateId);

            // Act
            var response = await _client.PostAsJsonAsync("/api/applications", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Application submitted successfully");
        }

        [Fact]
        public async Task UpdateStatus_ShouldTransitionStatus_WhenInvokedByRecruiter()
        {
            // Arrange
            var (jobId, recruiterEmail, _, candidateId) = await GetSeededDataAsync();
            long appId;

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                // Ensure no existing app for this pair
                var existing = await context.Applications.FirstOrDefaultAsync(a => a.JobId == jobId && a.CandidateId == candidateId);
                if (existing != null) context.Applications.Remove(existing);

                var app = new Applications 
                { 
                    JobId = jobId, 
                    CandidateId = candidateId, 
                    Status = ApplicationStatus.REVIEWING,
                    CreatedAt = DateTime.UtcNow 
                };
                context.Applications.Add(app);
                await context.SaveChangesAsync();
                appId = app.Id;
            }

            var token = await LoginAsAsync(recruiterEmail);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new UpdateApplicationStatusRequest 
            { 
                Status = ApplicationStatus.INTERVIEWING,
                InterviewDate = DateTime.UtcNow.AddDays(1)
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/applications/{appId}/status", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var updatedApp = await context.Applications.FindAsync(appId);
                updatedApp!.Status.Should().Be(ApplicationStatus.INTERVIEWING);
            }
        }

        [Fact]
        public async Task BulkUpdateStatus_ShouldUpdateMultiple_WhenInvokedByRecruiter()
        {
            // Arrange
            var (jobId, recruiterEmail, _, _) = await GetSeededDataAsync();
            List<long> appIds = new();

            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                // Use a range of candidate IDs from seeded data (53, 54, 55) to avoid unique constraint
                for (int i = 0; i < 3; i++)
                {
                    long cid = 53 + i;
                    var app = await context.Applications.FirstOrDefaultAsync(a => a.JobId == jobId && a.CandidateId == cid);
                    if (app == null)
                    {
                        app = new Applications { JobId = jobId, CandidateId = cid, Status = ApplicationStatus.REVIEWING, CreatedAt = DateTime.UtcNow };
                        context.Applications.Add(app);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        app.Status = ApplicationStatus.REVIEWING;
                        await context.SaveChangesAsync();
                    }
                    appIds.Add(app.Id);
                }
            }

            var token = await LoginAsAsync(recruiterEmail);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new BulkUpdateApplicationStatusRequest
            {
                ApplicationIds = appIds,
                Status = ApplicationStatus.REJECTED,
                RejectionReason = "Bulk rejection"
            };

            // Act
            var response = await _client.PutAsJsonAsync("/api/applications/bulk-status", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                foreach (var id in appIds)
                {
                    var app = await context.Applications.FindAsync(id);
                    app!.Status.Should().Be(ApplicationStatus.REJECTED);
                }
            }
        }

        [Fact]
        public async Task GetByJob_ShouldReturnApplications_WhenHRViewsOwnJob()
        {
            // Arrange
            var (jobId, recruiterEmail, _, _) = await GetSeededDataAsync();
            var token = await LoginAsAsync(recruiterEmail);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync($"/api/applications/job/{jobId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.Content.ReadAsStringAsync();
            body.Should().Contain("\"success\":true");
        }
    }
}
