using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Infrastructure.Data.Seeders
{
    public static class DbInitializer
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var random = new Random();
            var users = new List<User>();
            string hashedPass = PasswordUtil.HashPassword("password123");
            users.Add(new User { Email = "admin@gmail.com", PasswordHash = hashedPass, FullName = "System Admin", Role = UserRole.ADMIN });

            for (int i = 1; i <= 5; i++)
            {
                users.Add(new User
                {
                    Email = $"hr{i}@gmail.com",
                    PasswordHash = hashedPass,
                    FullName = $"HR Manager {i}",
                    Role = UserRole.RECRUITER,
                    IsVip = i % 2 == 0
                });
            }

            for (int i = 1; i <= 30; i++)
            {
                users.Add(new User
                {
                    Email = $"candidate{i}@gmail.com",
                    PasswordHash = hashedPass,
                    FullName = $"Candidate {i}",
                    Role = UserRole.CANDIDATE
                });
            }
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            var skillsPool = new[] { ".NET", "Java", "React", "Angular", "SQL", "Python", "Docker" };

            foreach (var user in users)
            {
                context.Wallets.Add(new Wallet { UserId = user.Id, Balance = random.Next(10, 50) * 100000 });

                if (user.Role == UserRole.CANDIDATE)
                {
                    context.CandidateProfiles.Add(new CandidateProfile
                    {
                        UserId = user.Id,
                        ExperienceYears = random.Next(1, 5),
                        Skills = "[\".NET\", \"SQL\"]",
                        ExpectedSalary = random.Next(10, 30) * 1000000
                    });
                }
            }
            await context.SaveChangesAsync();

            var recruiters = users.Where(u => u.Role == UserRole.RECRUITER).ToList();
            var jobs = new List<Job>();
            for (int i = 1; i <= 20; i++)
            {
                jobs.Add(new Job
                {
                    RecruiterId = recruiters[random.Next(recruiters.Count)].Id,
                    Title = $"Software Engineer {i}",
                    Description = "Job Description content",
                    Requirement = "Job Requirements",
                    SkillsRequired = "[\".NET\", \"C#\"]",
                    SalaryMin = 10000000,
                    SalaryMax = 20000000,
                    Location = "Hà Nội",
                    Category = "IT",
                    Status = JobStatus.PUBLISHED
                });
            }
            await context.Jobs.AddRangeAsync(jobs);
            await context.SaveChangesAsync();

            var candidates = users.Where(u => u.Role == UserRole.CANDIDATE).ToList();
            foreach (var job in jobs.Take(10))
            {
                for (int j = 0; j < 3; j++)
                {
                    context.Applications.Add(new Applications
                    {
                        JobId = job.Id,
                        CandidateId = candidates[random.Next(candidates.Count)].Id,
                        MatchScore = random.Next(60, 95),
                        SkillMatch = random.Next(50, 100),
                        ExperienceMatch = random.Next(50, 100),
                        Status = ApplicationStatus.APPLIED
                    });
                }
            }

            foreach (var user in users)
            {
                context.Notifications.Add(new Notification
                {
                    UserId = user.Id,
                    Title = "Welcome",
                    Message = "Welcome to SmartRecruit",
                    IsRead = false
                });

                if (user.Role == UserRole.RECRUITER)
                {
                    context.Transactions.Add(new Transaction
                    {
                        UserId = user.Id,
                        WalletId = context.Wallets.First(w => w.UserId == user.Id).Id,
                        Amount = 50000,
                        Type = TransactionType.JOB_POST,
                        Status = TransactionStatus.SUCCESS,
                        Description = "Post Job Fee"
                    });
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
