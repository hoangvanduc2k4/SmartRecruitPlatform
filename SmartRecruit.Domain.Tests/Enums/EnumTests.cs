using FluentAssertions;
using SmartRecruit.Domain.Enums;
using Xunit;

namespace SmartRecruit.Domain.Tests.Enums
{
    public class EnumTests
    {
        [Theory]
        [InlineData(JobStatus.CHECKING, 0)]
        [InlineData(JobStatus.APPROVED, 1)]
        [InlineData(JobStatus.BLOCKED, 2)]
        [InlineData(JobStatus.HIDDEN, 3)]
        [InlineData(JobStatus.DRAFT, 4)]
        public void JobStatus_Should_Have_Correct_Values(JobStatus status, int expectedValue)
        {
            ((int)status).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(ApplicationStatus.REVIEWING, 0)]
        [InlineData(ApplicationStatus.INTERVIEWING, 1)]
        [InlineData(ApplicationStatus.OFFERED, 2)]
        [InlineData(ApplicationStatus.REJECTED, 3)]
        public void ApplicationStatus_Should_Have_Correct_Values(ApplicationStatus status, int expectedValue)
        {
            ((int)status).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(UserRole.CANDIDATE, 0)]
        [InlineData(UserRole.RECRUITER, 1)]
        [InlineData(UserRole.ADMIN, 2)]
        public void UserRole_Should_Have_Correct_Values(UserRole role, int expectedValue)
        {
            ((int)role).Should().Be(expectedValue);
        }
    }
}
