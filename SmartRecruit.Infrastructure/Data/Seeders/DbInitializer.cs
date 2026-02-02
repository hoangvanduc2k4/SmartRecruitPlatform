using Bogus;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;

namespace SmartRecruit.Infrastructure.Data.Seeders
{
    public static class DbInitializer
    {
        // Helper tránh lỗi MaxLength trong Database
        private static string Limit(this string text, int max) =>
            string.IsNullOrEmpty(text) ? text : (text.Length <= max ? text : text.Substring(0, max));

        public static void SeedSmartRecruitData(this ModelBuilder modelBuilder)
        {
            // 1. Cấu hình Seed cố định
            var seedValue = 999;
            Randomizer.Seed = new Random(seedValue);
            var rnd = new Random(seedValue);
            var createdAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // 2. Hash mật khẩu MỘT LẦN DUY NHẤT để tối ưu tốc độ sinh Migration
            // Tất cả user seed sẽ có pass là "password123"
            var commonHash = PasswordUtil.HashPassword("password123");

            // --- 3. CATEGORIES (10) ---
            var categoryNames = new[] { "IT", "Marketing", "Finance", "HR", "Design", "Sales", "Legal", "Education", "Healthcare", "Engineering" };
            var categories = categoryNames.Select((name, i) => new Category
            {
                Id = i + 1,
                Name = name,
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<Category>().HasData(categories);

            // --- 4. USERS (251) ---
            var users = new List<User>();
            // Admin (ID 1)
            users.Add(new User
            {
                Id = 1,
                Email = "admin@smartrecruit.com",
                FullName = "Admin System",
                Role = UserRole.ADMIN,
                PasswordHash = commonHash,
                CreatedAt = createdAt
            });

            int userIdCounter = 2;
            // Recruiters (50: ID 2 - 51)
            for (int i = 0; i < 50; i++)
                users.Add(new Faker<User>().CustomInstantiator(f => new User
                {
                    Id = userIdCounter++,
                    Email = f.Internet.Email().ToLower().Limit(100),
                    FullName = f.Name.FullName().Limit(100),
                    Role = UserRole.RECRUITER,
                    PasswordHash = commonHash,
                    CreatedAt = createdAt
                }));

            // Candidates (200: ID 52 - 251)
            var candidateIds = new List<long>();
            for (int i = 0; i < 200; i++)
            {
                var cId = userIdCounter++;
                candidateIds.Add(cId);
                users.Add(new Faker<User>().CustomInstantiator(f => new User
                {
                    Id = cId,
                    Email = f.Internet.Email().ToLower().Limit(100),
                    FullName = f.Name.FullName().Limit(100),
                    Role = UserRole.CANDIDATE,
                    PasswordHash = commonHash,
                    CreatedAt = createdAt
                }));
            }
            modelBuilder.Entity<User>().HasData(users);

            // --- 5. WALLETS (251 - 1:1 với User) ---
            var wallets = users.Select(u => new Wallet
            {
                Id = u.Id,
                UserId = u.Id,
                Balance = u.Role == UserRole.RECRUITER ? 10000000 : 0,
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<Wallet>().HasData(wallets);

            // --- 6. CANDIDATE PROFILES (200 - 1:1 với Candidates) ---
            int profileId = 1;
            var profiles = candidateIds.Select(cid => new CandidateProfile
            {
                Id = profileId++,
                UserId = cid,
                ExperienceYears = rnd.Next(1, 15),
                Skills = ".NET, SQL, React, Docker, Azure".Limit(200),
                CVText = "Experienced software engineer with expertise in building scalable cloud-native applications.",
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<CandidateProfile>().HasData(profiles);

            // --- 7. JOBS (200) ---
            int jobIdCounter = 1;
            var recruiterIds = users.Where(u => u.Role == UserRole.RECRUITER).Select(u => u.Id).ToList();
            var jobs = new Faker<Job>().CustomInstantiator(f => new Job
            {
                Id = jobIdCounter++,
                RecruiterId = f.PickRandom(recruiterIds),
                CategoryId = f.PickRandom(categories).Id,
                Title = f.Name.JobTitle().Limit(100),
                Company = f.Company.CompanyName().Limit(100),
                Benefits = f.Lorem.Sentence(5).Limit(200),
                Description = f.Lorem.Sentence(12).Limit(500),
                Requirement = f.Lorem.Sentence(8).Limit(500),
                SkillsRequired = ".NET Core, C#, EF Core",
                Status = JobStatus.APPROVED,
                CreatedAt = createdAt
            }).Generate(200);
            modelBuilder.Entity<Job>().HasData(jobs);

            // --- 8. APPLICATIONS (300 - Unique JobId-CandidateId Pair) ---
            var applications = new List<Applications>();
            var usedPairs = new HashSet<(long, long)>();
            var appFaker = new Faker();
            int appId = 1;
            while (applications.Count < 300)
            {
                var jId = appFaker.PickRandom(jobs).Id;
                var cId = appFaker.PickRandom(candidateIds);
                if (usedPairs.Add((jId, cId)))
                {
                    applications.Add(new Applications
                    {
                        Id = appId++,
                        JobId = jId,
                        CandidateId = cId,
                        MatchScore = (decimal)(rnd.NextDouble() * 100),
                        Status = ApplicationStatus.REVIEWING,
                        CreatedAt = createdAt
                    });
                }
            }
            modelBuilder.Entity<Applications>().HasData(applications);

            // --- 9. TRANSACTIONS (200) ---
            modelBuilder.Entity<Transaction>().HasData(Enumerable.Range(1, 200).Select(i => new Transaction
            {
                Id = i,
                UserId = recruiterIds[i % recruiterIds.Count],
                WalletId = recruiterIds[i % recruiterIds.Count],
                Amount = 20000,
                Type = TransactionType.BOOST,
                Status = TransactionStatus.SUCCESS,
                CreatedAt = createdAt
            }));

            // --- 10. NOTIFICATIONS (200) ---
            modelBuilder.Entity<Notification>().HasData(Enumerable.Range(1, 200).Select(i => new Notification
            {
                Id = i,
                UserId = users[i % users.Count].Id,
                Title = "Hệ thống".Limit(50),
                Message = "Tài khoản của bạn vừa có cập nhật mới.".Limit(255),
                CreatedAt = createdAt
            }));

            // --- 11. REPORTS (50) ---
            modelBuilder.Entity<Report>().HasData(Enumerable.Range(1, 50).Select(i => new Report
            {
                Id = i,
                JobId = jobs[i % jobs.Count].Id,
                ReporterId = candidateIds[i % candidateIds.Count],
                Reason = "Nội dung vi phạm chính sách cộng đồng.".Limit(200),
                CreatedAt = createdAt
            }));

            // --- 12. REFRESH TOKENS (50) ---
            modelBuilder.Entity<RefreshToken>().HasData(Enumerable.Range(1, 50).Select(i => new RefreshToken
            {
                Id = i,
                UserId = users[i % users.Count].Id,
                Token = $"seed-token-{i}",
                ExpiryDate = createdAt.AddDays(7),
                CreatedAt = createdAt
            }));
        }
    }
}