using Bogus;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using System;

namespace SmartRecruit.Domain.Tests.Helpers
{
    public static class TestHelper
    {
        private static readonly Faker _faker = new Faker();

        public static User CreateUser(long id = 0)
        {
            return new User
            {
                Id = id == 0 ? _faker.Random.Long(1, 10000) : id,
                Email = _faker.Internet.Email(),
                FullName = _faker.Name.FullName(),
                PasswordHash = "hashedpassword",
                Role = UserRole.CANDIDATE,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Job CreateJob(long id = 0, long recruiterId = 0)
        {
            return new Job
            {
                Id = id == 0 ? _faker.Random.Long(1, 10000) : id,
                RecruiterId = recruiterId == 0 ? _faker.Random.Long(1, 10000) : recruiterId,
                CategoryId = _faker.Random.Int(1, 10),
                Title = _faker.Name.JobTitle(),
                Company = _faker.Company.CompanyName(),
                Description = _faker.Lorem.Paragraph(),
                Requirement = _faker.Lorem.Paragraph(),
                Benefits = _faker.Lorem.Sentence(),
                SalaryMin = 1000,
                SalaryMax = 5000,
                Status = JobStatus.CHECKING,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Applications CreateApplication(long id = 0, long jobId = 0, long candidateId = 0)
        {
            return new Applications
            {
                Id = id == 0 ? _faker.Random.Long(1, 10000) : id,
                JobId = jobId == 0 ? _faker.Random.Long(1, 10000) : jobId,
                CandidateId = candidateId == 0 ? _faker.Random.Long(1, 10000) : candidateId,
                MatchScore = _faker.Random.Decimal(0, 100),
                Status = ApplicationStatus.REVIEWING,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Wallet CreateWallet(long id = 0, long userId = 0)
        {
            return new Wallet
            {
                Id = id == 0 ? _faker.Random.Long(1, 10000) : id,
                UserId = userId == 0 ? _faker.Random.Long(1, 10000) : userId,
                Balance = _faker.Random.Decimal(0, 10000),
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
