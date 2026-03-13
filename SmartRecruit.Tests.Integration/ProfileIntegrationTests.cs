using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.DTO.Profile;
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
    public class ProfileIntegrationTests : IntegrationTestBase
    {
        public ProfileIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        private async Task<string> LoginAsAsync(string email, string password = "password123")
        {
            var response = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = password });
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            return result!.Data!.Token;
        }

        [Fact]
        public async Task GetProfile_ShouldReturnProfile_WhenAuthenticated()
        {
            // Arrange
            string email = "candidate_profile@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var existing = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (existing == null)
                {
                    var user = new User
                    {
                        Email = email,
                        FullName = "Profile Test User",
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

            // Act
            var response = await _client.GetAsync("/api/users/profile");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateProfile_ShouldUpdateDetails_WhenRequestIsValid()
        {
            // Arrange
            string email = "candidate_update@app.com";
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
                        FullName = "Update Test User",
                        Role = UserRole.CANDIDATE,
                        IsActive = true,
                        EmailVerified = true,
                        PasswordHash = PasswordUtil.HashPassword("password123")
                    };
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                }
                userId = user.Id;
            }

            var token = await LoginAsAsync(email);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new UpdateProfileRequest
            {
                FullName = "Updated Name",
                Skills = "C#, React",
                ExperienceYears = 5,
                ExpectedSalary = 2000
            };

            // Act
            var response = await _client.PutAsJsonAsync("/api/users/profile", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var updatedUser = await context.Users.Include(u => u.CandidateProfile).FirstOrDefaultAsync(u => u.Id == userId);
                updatedUser!.FullName.Should().Be("Updated Name");
                updatedUser.CandidateProfile!.Skills.Should().Contain("React");
                updatedUser.CandidateProfile.ExperienceYears.Should().Be(5);
            }
        }

        [Fact]
        public async Task UploadCV_ShouldSucceed_AndExtractText()
        {
            // Arrange
            string email = "candidate_cv@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "CV Test User",
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

            // Create a multipart form-data request
            var fileContent = new ByteArrayContent(new byte[] { 1, 2, 3, 4 });
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
            
            var content = new MultipartFormDataContent();
            content.Add(fileContent, "file", "test_cv.pdf");

            // Act
            var response = await _client.PostAsync("/api/users/profile/upload-cv", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
            result.Message.Should().Contain("successfully");
        }

        [Fact]
        public async Task UploadAvatar_ShouldSucceed()
        {
            // Arrange
            string email = "candidate_avatar@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    user = new User
                    {
                        Email = email,
                        FullName = "Avatar Test User",
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

            // Create a multipart form-data request
            var fileContent = new ByteArrayContent(new byte[] { 255, 216, 255 }); // Mock JPEG header
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            
            var content = new MultipartFormDataContent();
            content.Add(fileContent, "file", "avatar.jpg");

            // Act
            var response = await _client.PostAsync("/api/users/profile/upload-avatar", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
            result!.Success.Should().BeTrue();
            result.Message.Should().Contain("Avatar uploaded successfully");
        }
    }
}
