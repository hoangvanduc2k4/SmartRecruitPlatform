using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Domain.Enums;
using Xunit;

namespace SmartRecruit.Tests.Integration
{
    [Trait("Category", "Integration")]
    public class AuthFlowIntegrationTests : IntegrationTestBase
    {
        public AuthFlowIntegrationTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task RegistrationAndEmailVerification_ShouldSucceed()
        {
            // Arrange
            var email = "verify_test@app.com";
            var registerRequest = new RegisterRequest
            {
                Email = email,
                Password = "Password123!",
                FullName = "Verify User",
                Role = UserRole.CANDIDATE
            };

            // Act - Register
            var regResponse = await _client.PostAsJsonAsync("/api/auth/register", registerRequest);
            regResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Find OTP in DB
            string code;
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var otp = await context.OtpTokens
                    .Where(o => o.Email == email && o.Type == "VerifyEmail")
                    .OrderByDescending(o => o.CreatedAt)
                    .FirstOrDefaultAsync();
                otp.Should().NotBeNull();
                code = otp!.Code;
            }

            // Act - Verify Email
            var verifyRequest = new VerifyEmailRequest { Email = email, Code = code };
            var verifyResponse = await _client.PostAsJsonAsync("/api/auth/verify-email", verifyRequest);
            verifyResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Act - Login
            var loginRequest = new LoginRequest { Email = email, Password = "Password123!" };
            var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);
            
            // Assert
            loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await loginResponse.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            result!.Data!.Token.Should().NotBeNullOrEmpty();
            result.Data.Email.Should().Be(email);
        }

        [Fact]
        public async Task PasswordResetFlow_ShouldSucceed()
        {
            // Arrange
            var email = "reset_test@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = new User
                {
                    Email = email,
                    FullName = "Reset User",
                    PasswordHash = SmartRecruit.Application.Utils.PasswordUtil.HashPassword("OldPass123!"),
                    Role = UserRole.CANDIDATE,
                    EmailVerified = true,
                    IsActive = true
                };
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            // Act - Forgot Password
            var forgotRequest = new ForgotPasswordRequest { Email = email };
            var forgotResponse = await _client.PostAsJsonAsync("/api/auth/forgot-password", forgotRequest);
            forgotResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Find Code
            string code;
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var otp = await context.OtpTokens
                    .Where(o => o.Email == email && o.Type == "ForgotPassword")
                   .OrderByDescending(o => o.CreatedAt)
                    .FirstOrDefaultAsync();
                code = otp!.Code;
            }

            // Act - Reset Password
            var resetRequest = new ResetPasswordRequest 
            { 
                Email = email, 
                Code = code, 
                NewPassword = "NewPassword123!" 
            };
            var resetResponse = await _client.PostAsJsonAsync("/api/auth/reset-password", resetRequest);
            resetResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            // Act - Login with New Pass
            var loginRequest = new LoginRequest { Email = email, Password = "NewPassword123!" };
            var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

            // Assert
            loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task RefreshToken_ShouldIssueNewAccessToken()
        {
            // Arrange
            var email = "refresh_test@app.com";
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = new User
                {
                    Email = email,
                    FullName = "Refresh User",
                    PasswordHash = SmartRecruit.Application.Utils.PasswordUtil.HashPassword("Password123!"),
                    Role = UserRole.CANDIDATE,
                    EmailVerified = true,
                    IsActive = true
                };
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", new LoginRequest { Email = email, Password = "Password123!" });
            var loginResult = await loginResponse.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            var refreshToken = loginResult!.Data!.RefreshToken;

            // Act
            var refreshRequest = new RefreshTokenRequest { RefreshToken = refreshToken };
            var refreshResponse = await _client.PostAsJsonAsync("/api/auth/refresh-token", refreshRequest);

            // Assert
            refreshResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var refreshResult = await refreshResponse.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
            refreshResult!.Data!.Token.Should().NotBeNullOrEmpty();
            refreshResult.Data.Token.Should().NotBe(loginResult.Data.Token);
            refreshResult.Data.RefreshToken.Should().NotBe(refreshToken);
        }
    }
}
