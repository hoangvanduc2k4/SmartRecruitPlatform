using FluentAssertions;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Domain.Tests.Helpers;
using Xunit;

namespace SmartRecruit.Domain.Tests.Entities
{
    public class JobTests
    {
        [Fact]
        public void Job_Should_Initialize_With_Default_Values()
        {
            // Act
            var job = new Job();

            // Assert
            job.Status.Should().Be(JobStatus.CHECKING);
            job.ViewCount.Should().Be(0);
            job.IsAppealed.Should().BeFalse();
            job.Applications.Should().NotBeNull();
            job.SavedJobs.Should().NotBeNull();
        }

        [Theory]
        [InlineData("Software Engineer", "SmartRecruit", JobStatus.APPROVED)]
        [InlineData("DevOps", "Cloud Solutions", JobStatus.BLOCKED)]
        public void Job_Should_Correctly_Set_Properties(string title, string company, JobStatus status)
        {
            // Arrange
            var job = TestHelper.CreateJob();

            // Act
            job.Title = title;
            job.Company = company;
            job.Status = status;

            // Assert
            job.Title.Should().Be(title);
            job.Company.Should().Be(company);
            job.Status.Should().Be(status);
        }

        [Fact]
        public void Job_Title_Should_Not_Be_Empty_Upon_Creation_Via_TestHelper()
        {
            // Act
            var job = TestHelper.CreateJob();

            // Assert
            job.Title.Should().NotBeNullOrEmpty();
            job.Company.Should().NotBeNullOrEmpty();
        }
    }
}
