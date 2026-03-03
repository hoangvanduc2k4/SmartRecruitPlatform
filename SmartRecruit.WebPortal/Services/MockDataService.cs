using WebPortal.Models;

namespace WebPortal.Services
{
    public interface IMockDataService
    {
        List<User> Users { get; }
        List<Job> Jobs { get; }
        List<Application> Applications { get; }
        List<Notification> Notifications { get; }
        List<Transaction> Transactions { get; }
    }

    public class MockDataService : IMockDataService
    {
        public List<User> Users { get; private set; } = new List<User>();
        public List<Job> Jobs { get; private set; } = new List<Job>();
        public List<Application> Applications { get; private set; } = new List<Application>();
        public List<Notification> Notifications { get; private set; } = new List<Notification>();
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public MockDataService()
        {
            GenerateMockData();
        }

        private void GenerateMockData()
        {
            var random = new Random();
            var firstNames = new[] { "An", "Binh", "Chi", "Dung", "Giang", "Hieu", "Khanh", "Linh", "Minh", "Nam", "Phuc", "Quan", "Son", "Thao", "Tuan", "Vy", "Yen" };
            var lastNames = new[] { "Nguyen", "Tran", "Le", "Pham", "Hoang", "Huynh", "Phan", "Vu", "Vo", "Dang", "Bui", "Do" };

            // Generate Users
            for (int i = 0; i < 100; i++)
            {
                var role = i < 5 ? UserRole.ADMIN : (i < 30 ? UserRole.RECRUITER : UserRole.CANDIDATE);
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];

                Users.Add(new User
                {
                    Id = $"user-{i}",
                    Email = $"{firstName.ToLower()}.{lastName.ToLower()}{i}@example.com",
                    FullName = $"{lastName} {firstName}",
                    Role = role,
                    WalletBalance = role == UserRole.RECRUITER ? random.Next(1000, 50000) * 1000 : 0,
                    AvatarUrl = $"https://i.pravatar.cc/150?u={i}",
                    IsVip = role == UserRole.RECRUITER && random.NextDouble() < 0.3,
                    IsLocked = random.NextDouble() < 0.05
                });
            }

            // Generate Jobs
            var recruiters = Users.Where(u => u.Role == UserRole.RECRUITER).ToList();
            var jobTitles = new[] { "Senior React Developer", "Backend Engineer (Node.js)", "Fullstack Developer", "DevOps Engineer", "Product Manager", "UI/UX Designer" };
            var skillsPool = new[] { "React", "Node.js", "TypeScript", "Java", "Python", "AWS", "Docker", "Kubernetes", "Figma", "SQL", "MongoDB" };
            var locations = new[] { "Ho Chi Minh", "Hanoi", "Danang", "Can Tho", "Remote", "Haiphong" };
            var categories = new[] { "Software Development", "Product Management", "Design", "Marketing", "Data Science", "Operations" };

            for (int i = 0; i < 500; i++)
            {
                var recruiter = recruiters[random.Next(recruiters.Count)];
                var title = jobTitles[random.Next(jobTitles.Length)];
                var salaryMin = random.Next(500, 3000);
                var statuses = Enum.GetValues<JobStatus>();
                var status = statuses[random.Next(statuses.Length)];

                var requiredSkills = new List<string>();
                int numSkills = random.Next(3, 6);
                for (int j = 0; j < numSkills; j++) requiredSkills.Add(skillsPool[random.Next(skillsPool.Length)]);

                var jobTypes = Enum.GetValues<JobType>();

                Jobs.Add(new Job
                {
                    Id = $"job-{i}",
                    RecruiterId = recruiter.Id,
                    Title = title,
                    Description = $"We are hiring a {title} to join our amazing team. Great benefits and culture.",
                    Requirement = $"At least {random.Next(1, 5)} years of experience with {skillsPool[random.Next(skillsPool.Length)]}.",
                    SkillsRequired = requiredSkills,
                    SalaryMin = salaryMin,
                    SalaryMax = salaryMin + random.Next(500, 2000),
                    JobType = jobTypes[random.Next(jobTypes.Length)],
                    Status = status,
                    ViewCount = random.Next(0, 1000),
                    CreatedAt = DateTime.Now.AddDays(-random.Next(1, 1000)),
                    Location = locations[random.Next(locations.Length)],
                    Category = categories[random.Next(categories.Length)],
                    IsBoosted = random.NextDouble() < 0.2,
                    BlockReason = status == JobStatus.BLOCKED ? "Suspicious content detected by AI" : null
                });
            }

            // Generate Applications
            var candidates = Users.Where(u => u.Role == UserRole.CANDIDATE).ToList();
            var activeJobs = Jobs.Where(j => j.Status == JobStatus.PUBLISHED).ToList();

            for (int i = 0; i < 2000; i++)
            {
                var job = activeJobs[random.Next(activeJobs.Count)];
                var candidate = candidates[random.Next(candidates.Count)];
                var appStatuses = Enum.GetValues<ApplicationStatus>();

                Applications.Add(new Application
                {
                    Id = $"app-{i}",
                    JobId = job.Id,
                    CandidateId = candidate.Id,
                    CandidateName = candidate.FullName,
                    MatchScore = random.Next(40, 100),
                    Status = appStatuses[random.Next(appStatuses.Length)],
                    AppliedAt = job.CreatedAt.AddDays(random.Next(1, 30)),
                    Notes = random.NextDouble() < 0.3 ? "Promising candidate" : null
                });
            }
        }
    }
}
