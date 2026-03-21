using FluentAssertions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Domain.Tests.Helpers;
using Xunit;

namespace SmartRecruit.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void User_Should_Initialize_With_Default_Values()
        {
            // Act
            var user = new User();

            // Assert
            user.AvatarUrl.Should().Be("https://i.pravatar.cc/150");
            user.Role.Should().Be(UserRole.CANDIDATE);
            user.IsActive.Should().BeTrue();
            user.EmailVerified.Should().BeFalse();
            user.RefreshTokens.Should().NotBeNull();
            user.JobsPosted.Should().NotBeNull();
            user.Applications.Should().NotBeNull();
            user.Transactions.Should().NotBeNull();
            user.Notifications.Should().NotBeNull();
            user.SavedJobs.Should().NotBeNull();
        }

        [Theory]
        [InlineData("test@example.com", "Full Name", UserRole.ADMIN)]
        [InlineData("admin@smartrecruit.com", "Admin User", UserRole.RECRUITER)]
        public void User_Should_Correctly_Set_Properties(string email, string fullName, UserRole role)
        {
            // Arrange
            var user = TestHelper.CreateUser();

            // Act
            user.Email = email;
            user.FullName = fullName;
            user.Role = role;

            // Assert
            user.Email.Should().Be(email);
            user.FullName.Should().Be(fullName);
            user.Role.Should().Be(role);
        }
    }
}
