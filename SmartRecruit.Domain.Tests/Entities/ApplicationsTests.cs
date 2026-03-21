using FluentAssertions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Domain.Tests.Helpers;
using Xunit;

namespace SmartRecruit.Domain.Tests.Entities
{
    public class ApplicationsTests
    {
        [Fact]
        public void Applications_Should_Initialize_With_Default_Values()
        {
            // Act
            var application = new Applications();

            // Assert
            application.Status.Should().Be(ApplicationStatus.REVIEWING);
            application.MatchScore.Should().Be(0);
            application.SkillMatch.Should().Be(0);
            application.ExperienceMatch.Should().Be(0);
        }

        [Theory]
        [InlineData(85.5, ApplicationStatus.INTERVIEWING)]
        [InlineData(10.0, ApplicationStatus.REJECTED)]
        public void Applications_Should_Correctly_Set_Properties(decimal matchScore, ApplicationStatus status)
        {
            // Arrange
            var application = TestHelper.CreateApplication();

            // Act
            application.MatchScore = matchScore;
            application.Status = status;

            // Assert
            application.MatchScore.Should().Be(matchScore);
            application.Status.Should().Be(status);
        }
    }
}
