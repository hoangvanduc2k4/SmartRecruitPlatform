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
            string hashedPass = PasswordUtil.HashPassword("password123");

            // --- Users Seeding ---
            var users = new List<User>();
            users.Add(new User { Email = "admin@smartrecruit.com", PasswordHash = hashedPass, FullName = "Admin User", Role = UserRole.ADMIN, IsActive = true });

            for (int i = 1; i <= 5; i++)
                users.Add(new User { Email = $"hr{i}@gmail.com", PasswordHash = hashedPass, FullName = $"HR Manager {i}", Role = UserRole.RECRUITER, IsActive = true });

            for (int i = 1; i <= 15; i++)
                users.Add(new User { Email = $"candidate{i}@gmail.com", PasswordHash = hashedPass, FullName = $"Candidate {i}", Role = UserRole.CANDIDATE, IsActive = true });

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            // --- Wallets & Candidate Profiles ---
            foreach (var user in users)
            {
                var wallet = new Wallet { UserId = user.Id, Balance = user.Role == UserRole.RECRUITER ? 1000000 : 0 };
                context.Wallets.Add(wallet);

                if (user.Role == UserRole.CANDIDATE)
                {
                    context.CandidateProfiles.Add(new CandidateProfile
                    {
                        UserId = user.Id,
                        Skills = ".NET, React, SQL",
                        ExperienceYears = random.Next(1, 5),
                        CVText = "Experienced software developer...",
                        ExpectedSalary = random.Next(1000, 3000) * 1000
                    });
                }
            }
            await context.SaveChangesAsync();

            // --- Jobs (with Boost & AI Status) ---
            var recruiters = users.Where(u => u.Role == UserRole.RECRUITER).ToList();
            var jobs = new List<Job>();
            for (int i = 1; i <= 10; i++)
            {
                var status = (JobStatus)(i % 3); // Cycle through CHECKING, APPROVED, BLOCKED
                var job = new Job
                {
                    RecruiterId = recruiters[random.Next(recruiters.Count)].Id,
                    Title = $"Software Engineer {i}",
                    Description = "Full job description in English...",
                    Requirement = "Technical requirements...",
                    SalaryMin = 1000,
                    SalaryMax = 2500,
                    Location = "Hanoi",
                    Category = "IT",
                    Status = status,
                    BoostExpiryTime = i == 1 ? DateTime.UtcNow.AddMinutes(20) : null, // Boost the first job
                    ModerationNote = status == JobStatus.BLOCKED ? "Contains restricted content." : null
                };
                jobs.Add(job);
            }
            await context.Jobs.AddRangeAsync(jobs);
            await context.SaveChangesAsync();

            // --- Applications (Kanban Columns) ---
            var candidates = users.Where(u => u.Role == UserRole.CANDIDATE).ToList();
            foreach (var job in jobs.Where(j => j.Status == JobStatus.APPROVED))
            {
                context.Applications.Add(new Applications
                {
                    JobId = job.Id,
                    CandidateId = candidates[random.Next(candidates.Count)].Id,
                    MatchScore = random.Next(70, 95),
                    Status = (ApplicationStatus)random.Next(0, 4) // Reviewing, Interviewing, Offered, Rejected
                });
            }

            // --- Reports & Transactions ---
            var targetJob = jobs.First();
            context.Reports.Add(new Report
            {
                JobId = targetJob.Id,
                ReporterId = candidates.First().Id,
                Reason = "Suspicious content reported by user.",
                IsProcessed = false
            });

            foreach (var hr in recruiters)
            {
                var hrWallet = context.Wallets.Local.First(w => w.UserId == hr.Id);
                context.Transactions.Add(new Transaction
                {
                    UserId = hr.Id,
                    WalletId = hrWallet.Id,
                    Amount = 20000,
                    Type = TransactionType.BOOST,
                    Status = TransactionStatus.SUCCESS,
                    Description = "Boost JD fee"
                });
            }

            await context.SaveChangesAsync();
        }
    }
}