using Moq;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Application.DTO.Job;
using System.Linq.Expressions;

namespace SmartRecruit.Application.Tests.Extensions
{
    public static class MockExtensions
    {
        public static Mock<IApplicationRepository> SetupMockApplicationRepository(this Mock<IApplicationRepository> mock)
        {
            // Default setups can go here if needed
            return mock;
        }

        public static Mock<IUnitOfWork> SetupMockUnitOfWork(this Mock<IUnitOfWork> mock)
        {
            mock.Setup(x => x.CompleteAsync()).ReturnsAsync(1);
            return mock;
        }

        public static Mock<IGeminiService> SetupMockGeminiService(this Mock<IGeminiService> mock)
        {
            mock.Setup(x => x.ScoreCvAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new CvScreeningResponse
                {
                    MatchScore = 85,
                    SkillMatch = 90,
                    ExperienceMatch = 80,
                    AI_Summary = "Good candidate",
                    MissingSkills = new List<string>(),
                    Recommendation = "Interview"
                });

            mock.Setup(x => x.CheckJobContentAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new JobScreeningResponse
                {
                    IsSafe = true,
                    RiskLevel = "Low",
                    ViolationType = "None",
                    Analysis = "Safe content"
                });

            return mock;
        }

        public static Mock<IGenericRepository<T>> SetupMockRepository<T>(this Mock<IGenericRepository<T>> mock, T? entity = null) where T : class
        {
            if (entity != null)
            {
                mock.Setup(x => x.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(entity);
                mock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<T, bool>>>())).ReturnsAsync(entity);
            }
            return mock;
        }
    }
}
