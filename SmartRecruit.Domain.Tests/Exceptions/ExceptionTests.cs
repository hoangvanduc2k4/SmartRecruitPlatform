using FluentAssertions;
using SmartRecruit.Domain.Exceptions;
using System;
using Xunit;

namespace SmartRecruit.Domain.Tests.Exceptions
{
    public class ExceptionTests
    {
        [Fact]
        public void NotFoundException_Should_Create_Correct_Message_With_Key()
        {
            // Arrange
            var entityName = "User";
            var key = 123;

            // Act
            var exception = new NotFoundException(entityName, key);

            // Assert
            exception.Message.Should().Be($"Entity \"{entityName}\" ({key}) was not found.");
        }

        [Fact]
        public void NotFoundException_Should_Create_Correct_Message_With_Direct_Message()
        {
            // Arrange
            var message = "Custom not found message";

            // Act
            var exception = new NotFoundException(message);

            // Assert
            exception.Message.Should().Be(message);
        }

        [Fact]
        public void BadRequestException_Should_Store_Message()
        {
            // Arrange
            var message = "Bad request occurred";

            // Act
            var exception = new BadRequestException(message);

            // Assert
            exception.Message.Should().Be(message);
        }

        [Fact]
        public void InsufficientFundException_Should_Have_Correct_Default_Message()
        {
            // Act
            var exception = new InsufficientFundException();

            // Assert
            exception.Message.Should().Be("Your wallet balance is insufficient for this transaction.");
        }
    }
}
