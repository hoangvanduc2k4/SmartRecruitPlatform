using FluentAssertions;
using SmartRecruit.Application.Utils;
using Xunit;

namespace SmartRecruit.Tests.Unit.Utils
{
    public class PasswordUtilTests
    {
        [Fact]
        public void HashPassword_ShouldReturnHashedString()
        {
            // Arrange
            var password = "Password123!";

            // Act
            var hashedPassword = PasswordUtil.HashPassword(password);

            // Assert
            hashedPassword.Should().NotBeNullOrEmpty();
            hashedPassword.Should().NotBe(password);
        }

        [Fact]
        public void VerifyPassword_ShouldReturnTrue_WhenPasswordIsCorrect()
        {
            // Arrange
            var password = "Password123!";
            var hashedPassword = PasswordUtil.HashPassword(password);

            // Act
            var result = PasswordUtil.VerifyPassword(password, hashedPassword);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void VerifyPassword_ShouldReturnFalse_WhenPasswordIsIncorrect()
        {
            // Arrange
            var password = "Password123!";
            var hashedPassword = PasswordUtil.HashPassword(password);
            var wrongPassword = "WrongPassword!";

            // Act
            var result = PasswordUtil.VerifyPassword(wrongPassword, hashedPassword);

            // Assert
            result.Should().BeFalse();
        }
    }
}
