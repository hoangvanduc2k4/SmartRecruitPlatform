
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Enums;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<JobRepository> _logger;

        public JobRepository(ApplicationDbContext context, ILogger<JobRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<Job>> GetJobsAsync(JobSearchRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch jobs with parameters: {@Request}", request);
            var query = _context.Set<Job>()
                .Include(x => x.Category)
                .AsQueryable();

            // 1. Initial Filter: Always exclude deleted jobs
            query = query.Where(x => !x.IsDeleted);

            // 2. Visibility Filter
            // If NOT showing hidden, exclude HIDDEN status
            if (!request.showHidden)
            {
                query = query.Where(x => x.Status != JobStatus.HIDDEN);
            }

            // If NOT showing blocked, exclude BLOCKED status
            if (!request.showBlocked)
            {
                query = query.Where(x => x.Status != JobStatus.BLOCKED);
            }

            // Exclude DRAFT status unless it's a specific recruiter's view (Manage Jobs)
            if (!request.recruiterId.HasValue)
            {
                query = query.Where(x => x.Status != JobStatus.DRAFT);
                // Exclude expired jobs from public search
                query = query.Where(x => x.ExpireDate == null || x.ExpireDate.Value >= DateTime.UtcNow);
            }

            // Note: If both are false (default), it shows everything else (CHECKING, APPROVED, REJECTED, EXPIRED, CLOSED). 
            // Often "Public" implies only APPROVED. 
            // However, sticking to the explicit "ShowHidden/ShowBlocked" toggles requested.

            // 3. Keyword Search (Title, Description, Requirement, SkillsRequired)
            if (!string.IsNullOrEmpty(request.keyword))
            {
                var keyword = request.keyword.Trim();
                query = query.Where(x =>
                    EF.Functions.Collate(x.Title, "Vietnamese_CI_AI").Contains(keyword) ||
                    EF.Functions.Collate(x.Company, "Vietnamese_CI_AI").Contains(keyword) ||
                    EF.Functions.Collate(x.Description, "Vietnamese_CI_AI").Contains(keyword) ||
                    EF.Functions.Collate(x.Requirement, "Vietnamese_CI_AI").Contains(keyword) ||
                    EF.Functions.Collate(x.SkillsRequired, "Vietnamese_CI_AI").Contains(keyword) ||
                    EF.Functions.Collate(x.Location, "Vietnamese_CI_AI").Contains(keyword));
            }

            // 4. Salary Range Logic
            if (request.minSalary.HasValue && request.minSalary > 0)
            {
                // Standard logic: The job's MIN salary must be at least the user's requested min.
                query = query.Where(x => x.SalaryMin >= request.minSalary.Value);
            }

            if (request.maxSalary.HasValue && request.maxSalary > 0)
            {
                // Standard logic: The job's MAX salary should not exceed the user's requested max.
                query = query.Where(x => x.SalaryMax <= request.maxSalary.Value);
            }

            // 5. Specific Filters
            if (!string.IsNullOrEmpty(request.location))
            {
                query = query.Where(x => EF.Functions.Collate(x.Location, "Vietnamese_CI_AI").Contains(request.location));
            }

            if (request.categoryId.HasValue && request.categoryId.Value > 0)
            {
                query = query.Where(x => x.CategoryId == request.categoryId.Value);
            }

            if (request.recruiterId.HasValue)
            {
                query = query.Where(x => x.RecruiterId == request.recruiterId.Value);
            }

            if (request.jobType.HasValue)
            {
                query = query.Where(x => (int)x.JobType == request.jobType.Value);
            }

            // 6. Sorting
            var now = DateTime.UtcNow;

            IOrderedQueryable<Job> orderedQuery;

            // We always prioritize Boosted jobs regardless of the requested SortBy
            // But within those boosted jobs, we follow the requirements:
            // "Tin nào vừa được thanh toán Boost thành công sẽ ngay lập tức chiếm vị trí Top 1"
            // This means we should sort boosted jobs by BoostExpiryTime DESC (since boost duration is fixed at 20 mins, newest boost will have latest expiry)

            // 1. Boosted jobs first: we sort by BoostExpiryTime DESC.
            // If BoostExpiryTime is null or in the past, they will naturally be sorted after currently boosted jobs if we use a default value for nulls,
            // or we can sort by HasBoost first, then ExpiryTime.

            // To ensure "Boosted jobs appear on top, ordered by most recently boosted (which means latest expiry time)",
            // we first order by whether they are currently boosted:
            orderedQuery = query.OrderByDescending(x => x.BoostExpiryTime.HasValue && x.BoostExpiryTime.Value > now)
                                .ThenByDescending(x => x.BoostExpiryTime) // Within boosted, newest boost (latest expiry) first. For non-boosted, this puts previously boosted jobs higher.
                                .ThenByDescending(x => x.ViewCount)
                                .ThenByDescending(x => x.SalaryMax)
                                .ThenBy(x => x.CreatedAt); // Oldest created first as tie-breaker

            // After boosted jobs, apply the requested or default sorting for non-boosted jobs
            bool isDesc = !string.Equals(request.sortOrder, "asc", StringComparison.OrdinalIgnoreCase);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy.ToLower())
                {
                    case "salary":
                        orderedQuery = isDesc ? orderedQuery.ThenByDescending(x => x.SalaryMin) : orderedQuery.ThenBy(x => x.SalaryMin);
                        break;
                    case "date":
                        // Use UpdatedAt ?? CreatedAt for "date" sorting
                        orderedQuery = isDesc ? orderedQuery.ThenByDescending(x => x.UpdatedAt ?? x.CreatedAt) : orderedQuery.ThenBy(x => x.UpdatedAt ?? x.CreatedAt);
                        break;
                }
            }

            return await PagedList<Job>.CreateAsync(orderedQuery, request.page, request.pageSize);
        }


        public new async Task<Job?> GetByIdAsync(long id)
        {
            return await _context.Set<Job>()
                .Include(x => x.Category)
                .Include(x => x.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task UpdateVisibilityAsync(long id, bool isVisible)
        {
            var job = await GetByIdAsync(id);
            if (job != null)
            {
                if (isVisible && job.Status == JobStatus.HIDDEN)
                {
                    job.Status = JobStatus.APPROVED;
                    _logger.LogTrace("Executing SQL update to set Job {JobId} visibility to APPROVED (Visible)", id);
                }
                else if (!isVisible)
                {
                    job.Status = JobStatus.HIDDEN;
                    _logger.LogTrace("Executing SQL update to set Job {JobId} visibility to HIDDEN", id);
                }

                _context.Set<Job>().Update(job);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<string>> GetLocationsAsync()
        {
            return await _context.Set<Job>()
                .Where(j => !string.IsNullOrEmpty(j.Location))
                .Select(j => j.Location)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetTopLocationsAsync(int count)
        {
            return await _context.Set<Job>()
                .Where(j => !string.IsNullOrEmpty(j.Location) && !j.IsDeleted && j.Status == JobStatus.APPROVED)
                .GroupBy(j => j.Location)
                .OrderByDescending(g => g.Count())
                .Take(count)
                .Select(g => g.Key)
                .ToListAsync();
        }

        public async Task<PagedList<Job>> GetAppealedJobsAsync(int page, int pageSize)
        {
            var query = _context.Set<Job>()
                .Include(j => j.Recruiter)
                .Where(j => j.IsAppealed && !j.IsDeleted)
                .OrderByDescending(j => j.CreatedAt);

            return await PagedList<Job>.CreateAsync(query, page, pageSize);
        }
        public async Task<RecruiterStatsResponse> GetRecruiterStatsAsync(long recruiterId)
        {
            var jobStats = await _context.Set<Job>()
                .Where(j => j.RecruiterId == recruiterId && !j.IsDeleted)
                .Select(j => new
                {
                    Views = j.ViewCount,
                    Saves = j.SavedJobs.Count(),
                    Applications = j.Applications.Count()
                })
                .ToListAsync();

            int totalViews = jobStats.Sum(s => s.Views);
            int totalSaves = jobStats.Sum(s => s.Saves);
            int totalApplications = jobStats.Sum(s => s.Applications);

            double ratio = totalSaves > 0 ? (double)totalApplications / totalSaves : 0;

            return new RecruiterStatsResponse(totalViews, totalSaves, totalApplications, ratio);
        }
        public async Task<IEnumerable<Job>> GetRecommendedJobsAsync(long userId, int limit = 10)
        {
            _logger.LogTrace("Generating rule-based recommendations for User {UserId}", userId);

            // 1. Get Candidate Profile Skills
            var profile = await _context.Set<CandidateProfile>()
                .FirstOrDefaultAsync(p => p.UserId == userId);

            var userSkills = profile?.Skills?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                             ?? Array.Empty<string>();

            // 2. Get Past Application History (Categories and Skills from jobs applied to)
            var appliedJobIds = await _context.Set<Applications>()
                .Where(a => a.CandidateId == userId)
                .Select(a => a.JobId)
                .ToListAsync();

            var appliedJobs = await _context.Set<Job>()
                .Where(j => appliedJobIds.Contains(j.Id))
                .Select(j => new { j.CategoryId, j.SkillsRequired })
                .ToListAsync();

            var preferredCategoryIds = appliedJobs.Select(j => j.CategoryId).Distinct().ToList();
            var skillsFromPastJobs = appliedJobs
                .SelectMany(j => j.SkillsRequired.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                .Distinct()
                .ToList();

            // Combine all relevant skills
            var allRelevantSkills = userSkills.Concat(skillsFromPastJobs).Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            // 3. Fetch potentially matching jobs 
            // - Exclude already applied jobs
            // - Only APPROVED and NOT deleted/blocked/hidden
            // - Exclude expired jobs
            var candidateJobs = await _context.Set<Job>()
                .Include(j => j.Category)
                .Where(j => !j.IsDeleted && j.Status == JobStatus.APPROVED && !appliedJobIds.Contains(j.Id))
                .Where(j => j.ExpireDate == null || j.ExpireDate.Value >= DateTime.UtcNow)
                .ToListAsync();

            // 4. Score jobs based on rules
            var scoredJobs = candidateJobs.Select(j =>
            {
                int score = 0;

                // Rule 1: Category Match (+10 points)
                if (preferredCategoryIds.Contains(j.CategoryId))
                {
                    score += 10;
                }

                // Rule 2: Skill Match (+5 points per skill found in Job requirements)
                var jobSkills = j.SkillsRequired.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                foreach (var skill in allRelevantSkills)
                {
                    if (jobSkills.Any(s => s.Contains(skill, StringComparison.OrdinalIgnoreCase)))
                    {
                        score += 5;
                    }
                }

                // Rule 3: Boost Priority (+2 points if currently boosted, purely as a tie-breaker/nudge)
                if (j.BoostExpiryTime.HasValue && j.BoostExpiryTime.Value > DateTime.UtcNow)
                {
                    score += 2;
                }

                return new { Job = j, Score = score };
            })
            .Where(x => x.Score > 0) // Only recommend if there's at least some match
            .OrderByDescending(x => x.Score)
            .ThenByDescending(x => x.Job.BoostExpiryTime) // Boosted jobs still merit higher showing for same score
            .Take(limit)
            .Select(x => x.Job)
            .ToList();

            return scoredJobs;
        }
    }
}
