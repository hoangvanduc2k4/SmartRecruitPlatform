
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

            // 2. Status & Visibility Filter
            if (request.recruiterId.HasValue)
            {
                // RECRUITER VIEW: Show their own jobs with many statuses, but respect explicit status filter if provided
                query = query.Where(x => x.RecruiterId == request.recruiterId.Value);
                if (request.status.HasValue)
                {
                    query = query.Where(x => (int)x.Status == request.status.Value);
                }
            }
            else if (request.status.HasValue)
            {
                // ADMIN OR SPECIFIC PUBLIC VIEW: Filter by specific status
                query = query.Where(x => (int)x.Status == request.status.Value);
            }
            else
            {
                // PUBLIC SEARCH: Only APPROVED or EXPIRING_SOON
                query = query.Where(x => x.Status == JobStatus.APPROVED || x.Status == JobStatus.EXPIRING_SOON);
            }

            // Exclude Hidden/Blocked unless explicitly requested (for Admin/Recruiter)
            if (!request.showHidden && !request.recruiterId.HasValue && !request.status.HasValue)
            {
                query = query.Where(x => x.Status != JobStatus.HIDDEN);
            }
            if (!request.showBlocked && !request.recruiterId.HasValue && !request.status.HasValue)
            {
                query = query.Where(x => x.Status != JobStatus.BLOCKED);
            }

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
                query = query.Where(x => x.SalaryMax >= request.minSalary.Value);
            }

            if (request.maxSalary.HasValue && request.maxSalary > 0)
            {
                // Standard logic: The job's MAX salary should not exceed the user's requested max.
                query = query.Where(x => x.SalaryMin <= request.maxSalary.Value);
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

            if (request.status.HasValue)
            {
                query = query.Where(x => (int)x.Status == request.status.Value);
            }

            // 6. Sorting
            var now = DateTime.UtcNow;
            IOrderedQueryable<Job> orderedQuery;

            if (request.recruiterId.HasValue)
            {
                orderedQuery = query.OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt);
            }
            else
            {
                bool isDesc = !string.Equals(request.sortOrder, "asc", StringComparison.OrdinalIgnoreCase);

                if (!string.IsNullOrEmpty(request.sortBy))
                {
                    // User Sort is PRIMARY
                    switch (request.sortBy.ToLower())
                    {
                        case "salary":
                            orderedQuery = isDesc ? query.OrderByDescending(x => x.SalaryMax) : query.OrderBy(x => x.SalaryMin);
                            break;
                        case "date":
                            orderedQuery = isDesc ? query.OrderByDescending(x => x.UpdatedAt ?? x.CreatedAt) : query.OrderBy(x => x.UpdatedAt ?? x.CreatedAt);
                            break;
                        case "views":
                            orderedQuery = isDesc ? query.OrderByDescending(x => x.ViewCount) : query.OrderBy(x => x.ViewCount);
                            break;
                        default:
                            orderedQuery = query.OrderByDescending(x => x.ViewCount);
                            break;
                    }

                    // Boosted status as SECONDARY priority
                    orderedQuery = orderedQuery.ThenByDescending(x => x.BoostExpiryTime.HasValue && x.BoostExpiryTime.Value > now)
                                                .ThenByDescending(x => x.BoostExpiryTime);
                }
                else
                {
                    // Default View: Boosted is PRIMARY
                    orderedQuery = query.OrderByDescending(x => x.BoostExpiryTime.HasValue && x.BoostExpiryTime.Value > now)
                                        .ThenByDescending(x => x.BoostExpiryTime)
                                        .ThenByDescending(x => x.ViewCount)
                                        .ThenByDescending(x => x.UpdatedAt ?? x.CreatedAt);
                }

                // Final Tie-breaker
                orderedQuery = orderedQuery.ThenByDescending(x => x.Id);
            }

            return await PagedList<Job>.CreateAsync(orderedQuery, request.page, request.pageSize);
        }


        public new async Task<Job?> GetByIdAsync(long id)
        {
            return await _context.Set<Job>()
                .Include(x => x.Category)
                .Include(x => x.Recruiter)
                    .ThenInclude(r => r.CompanyProfile)
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
                .Where(j => !string.IsNullOrEmpty(j.Location) && !j.IsDeleted)
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
                    Applications = j.Applications.Count(),
                    SavedAndApplied = j.SavedJobs.Where(s => j.Applications.Any(a => a.CandidateId == s.UserId)).Count()
                })
                .ToListAsync();

            int totalViews = jobStats.Sum(s => s.Views);
            int totalSaves = jobStats.Sum(s => s.Saves);
            int totalApplications = jobStats.Sum(s => s.Applications);
            int totalSavedAndApplied = jobStats.Sum(s => s.SavedAndApplied);
            double ratio = totalSaves > 0 ? (double)totalSavedAndApplied / totalSaves : 0;

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
                .Where(j => !j.IsDeleted && (j.Status == JobStatus.APPROVED || j.Status == JobStatus.EXPIRING_SOON) && !appliedJobIds.Contains(j.Id))
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
