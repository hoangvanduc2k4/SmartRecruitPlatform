using Bogus;
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using System.Linq;
using System.Collections.Generic;

namespace SmartRecruit.Infrastructure.Data.Seeders
{
    public static class DbInitializer
    {
        private static string Limit(this string text, int max) =>
            string.IsNullOrEmpty(text) ? text : (text.Length <= max ? text : text.Substring(0, max));

        public static void SeedSmartRecruitData(this ModelBuilder modelBuilder)
        {
            var seedValue = 999;
            var rnd = new Random(seedValue);
            var createdAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var commonHash = PasswordUtil.HashPassword("password123");

            // --- 3. CATEGORIES ---
            var categoryNames = new[] { "Công nghệ thông tin", "Marketing", "Tài chính", "Nhân sự", "Thiết kế", "Bán hàng", "Pháp lý", "Giáo dục", "Y tế", "Kỹ thuật" };
            var categories = categoryNames.Select((name, i) => new Category
            {
                Id = i + 1,
                Name = name,
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<Category>().HasData(categories);

            // --- 4. USERS ---
            var users = new List<User>();
            users.Add(new User
            {
                Id = 1,
                Email = "admin@smartrecruit.com",
                FullName = "Hệ thống Quản trị",
                Role = UserRole.ADMIN,
                PasswordHash = commonHash,
                CreatedAt = createdAt,
                EmailVerified = true
            });

            int userIdCounter = 2;
            var userFaker = new Faker("vi");
            for (int i = 0; i < 50; i++)
                users.Add(new User
                {
                    Id = userIdCounter++,
                    Email = userFaker.Internet.Email().ToLower().Limit(100),
                    FullName = userFaker.Name.FullName().Limit(100),
                    Role = UserRole.RECRUITER,
                    PasswordHash = commonHash,
                    CreatedAt = createdAt,
                    EmailVerified = true
                });

            var candidateIds = new List<long>();
            for (int i = 0; i < 200; i++)
            {
                var cId = userIdCounter++;
                candidateIds.Add(cId);
                users.Add(new User
                {
                    Id = cId,
                    Email = userFaker.Internet.Email().ToLower().Limit(100),
                    FullName = userFaker.Name.FullName().Limit(100),
                    Role = UserRole.CANDIDATE,
                    PasswordHash = commonHash,
                    CreatedAt = createdAt,
                    EmailVerified = true
                });
            }
            modelBuilder.Entity<User>().HasData(users);

            // --- 5. WALLETS ---
            var wallets = users.Select(u => new Wallet
            {
                Id = u.Id,
                UserId = u.Id,
                Balance = u.Role == UserRole.RECRUITER ? 10000000 : 0,
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<Wallet>().HasData(wallets);

            // --- 6. CANDIDATE PROFILES ---
            int profileId = 1;
            var profiles = candidateIds.Select(cid => new CandidateProfile
            {
                Id = profileId++,
                UserId = cid,
                ExperienceYears = rnd.Next(1, 15),
                Skills = ".NET, SQL, React, Docker, Azure, Tiếng Anh giao tiếp".Limit(200),
                CVText = "Kỹ sư phần mềm giàu kinh nghiệm với chuyên môn xây dựng các ứng dụng có khả năng mở rộng.",
                ExpectedSalary = (decimal)(rnd.Next(15, 60) * 1000000), // 15 - 60 triệu VND
                CreatedAt = createdAt
            }).ToList();
            modelBuilder.Entity<CandidateProfile>().HasData(profiles);

            // --- 7. JOBS ---
            int jobIdCounter = 1;
            var recruiterIds = users.Where(u => u.Role == UserRole.RECRUITER).Select(u => u.Id).ToList();
            var jobTitles = new[] { "Lập trình viên .NET", "Chuyên viên Marketing", "Kế toán trưởng", "Nhân viên nhân sự", "Thiết kế đồ họa", "Nhân viên kinh doanh", "Kỹ sư phần mềm", "Quản lý dự án", "Chuyên viên tư vấn", "Lập trình viên Frontend" };
            var locations = new[] { "Hà Nội", "TP. Hồ Chí Minh", "Đà Nẵng", "Cần Thơ", "Hải Phòng", "Bình Dương", "Đồng Nai" };
            var jobs = Enumerable.Range(1, 200).Select(i => {
                var sMin = (decimal)(rnd.Next(10, 40) * 1000000);
                return new Job
                {
                    Id = jobIdCounter++,
                    RecruiterId = recruiterIds[rnd.Next(recruiterIds.Count)],
                    CategoryId = categories[rnd.Next(categories.Count)].Id,
                    Title = jobTitles[rnd.Next(jobTitles.Length)],
                    Company = userFaker.Company.CompanyName().Limit(100),
                    Benefits = "Bảo hiểm đầy đủ, Thưởng tháng 13, Du lịch hàng năm".Limit(200),
                    Description = "Mô tả công việc chi tiết sẽ được trao đổi khi phỏng vấn.".Limit(500),
                    Requirement = "Có kinh nghiệm tương đương, nhiệt huyết với công việc.".Limit(500),
                    SkillsRequired = ".NET Core, SQL Server",
                    SalaryMin = sMin,
                    SalaryMax = sMin + (decimal)(rnd.Next(5, 40) * 1000000),
                    Location = locations[rnd.Next(locations.Length)],
                    Status = JobStatus.APPROVED,
                    ExpireDate = DateTime.UtcNow.AddDays(rnd.Next(-5, 30)),
                    CreatedAt = createdAt
                };
            }).ToList();
            modelBuilder.Entity<Job>().HasData(jobs);

            // --- 8. APPLICATIONS ---
            var applications = new List<Applications>();
            var usedPairs = new HashSet<(long, long)>();
            int appId = 1;
            while (applications.Count < 300)
            {
                var jId = jobs[rnd.Next(jobs.Count)].Id;
                var cId = candidateIds[rnd.Next(candidateIds.Count)];
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

            // --- 9. TRANSACTIONS ---
            modelBuilder.Entity<Transaction>().HasData(Enumerable.Range(1, 200).Select(i => new Transaction
            {
                Id = i,
                UserId = recruiterIds[i % recruiterIds.Count],
                WalletId = recruiterIds[i % recruiterIds.Count],
                Amount = -20000,
                Type = TransactionType.BOOST,
                Status = TransactionStatus.SUCCESS,
                CreatedAt = createdAt
            }));

            // --- 10. NOTIFICATIONS ---
            modelBuilder.Entity<Notification>().HasData(Enumerable.Range(1, 200).Select(i => new Notification
            {
                Id = i,
                UserId = users[i % users.Count].Id,
                Title = "Hệ thống".Limit(50),
                Message = "Tài khoản của bạn vừa có cập nhật mới.".Limit(255),
                CreatedAt = createdAt
            }));

            // --- 12. REFRESH TOKENS ---
            modelBuilder.Entity<RefreshToken>().HasData(Enumerable.Range(1, 50).Select(i => new RefreshToken
            {
                Id = i,
                UserId = users[i % users.Count].Id,
                Token = $"seed-token-{i}",
                ExpiryDate = createdAt.AddDays(7),
                CreatedAt = createdAt
            }));

            // --- 13. AI LOGS ---
            modelBuilder.Entity<AILog>().HasData(Enumerable.Range(1, 20).Select(i => new AILog
            {
                Id = i,
                JobId = jobs[i % jobs.Count].Id,
                AIType = AIType.JOB_MODERATION,
                InputText = "Yêu cầu cung cấp thông tin tài khoản ngân hàng trong mô tả công việc...",
                OutputResult = "BLOCK",
                Decision = "BLOCK",
                Reason = "Phát hiện dấu hiệu lừa đảo: Yêu cầu thông tin nhạy cảm.",
                CreatedAt = createdAt.AddHours(i)
            }));
        }
    }
}