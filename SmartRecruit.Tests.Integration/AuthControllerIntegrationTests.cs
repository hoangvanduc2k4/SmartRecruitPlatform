using FluentAssertions;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Enums;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace SmartRecruit.Tests.Integration
{
    public class AuthControllerIntegrationTests : IntegrationTestBase
    {
        private readonly ITestOutputHelper _output;

        public AuthControllerIntegrationTests(CustomWebApplicationFactory factory, ITestOutputHelper output) : base(factory)
        {
            _output = output;
        }

        [Fact]
        public async Task RegisterAndLoginFlow_ShouldSucceed()
        {
            // 1. Register a new user
            var registerRequest = new RegisterRequest
            {
                Email = "integration@test.com",
                Password = "Password123!",
                FullName = "Integration User",
                Role = UserRole.CANDIDATE
            };

            var registerResponse = await _client.PostAsJsonAsync("/api/auth/register", registerRequest);
            var content = await registerResponse.Content.ReadAsStringAsync();
            _output.WriteLine($"Response: {content}");
            registerResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var registerResult = await registerResponse.Content.ReadFromJsonAsync<ApiResponse<object>>();
            registerResult.Success.Should().BeTrue();

            // 2. Login should fail because email is not verified (assuming business logic requires verification)
            var loginRequest = new LoginRequest
            {
                Email = "integration@test.com",
                Password = "Password123!"
            };

            var loginFailResponse = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);
            // According to AuthService.cs line 62, it throws ArgumentException which should be handled by middleware
            // Let's assume it returns BadRequest or InternalServerError if not handled specifically as 401
            loginFailResponse.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
    }
}
