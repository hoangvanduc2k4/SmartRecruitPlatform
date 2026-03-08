using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Job;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SmartRecruit.Domain.Enums;

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
            if (!request.ShowHidden)
            {
                query = query.Where(x => x.Status != JobStatus.HIDDEN);
            }

            // If NOT showing blocked, exclude BLOCKED status
            if (!request.ShowBlocked)
            {
                query = query.Where(x => x.Status != JobStatus.BLOCKED);
            }

            // Note: If both are false (default), it shows everything else (CHECKING, APPROVED, REJECTED, EXPIRED, CLOSED). 
            // Often "Public" implies only APPROVED. 
            // However, sticking to the explicit "ShowHidden/ShowBlocked" toggles requested.

            // 3. Keyword Search (Title, Description, Requirement, SkillsRequired)
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                var keyword = request.Keyword.Trim();
                query = query.Where(x =>
                    x.Title.Contains(keyword) ||
                    x.Company.Contains(keyword) ||
                    x.Description.Contains(keyword) ||
                    x.Requirement.Contains(keyword) ||
                    x.SkillsRequired.Contains(keyword));
            }

            // 4. Salary Range
            if (request.MinSalary.HasValue)
            {
                query = query.Where(x => x.SalaryMin >= request.MinSalary.Value);
            }

            if (request.MaxSalary.HasValue)
            {
                query = query.Where(x => x.SalaryMax <= request.MaxSalary.Value);
            }

            // 5. Specific Filters
            if (!string.IsNullOrEmpty(request.Location))
            {
                query = query.Where(x => x.Location.Contains(request.Location));
            }

            if (request.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == request.CategoryId.Value);
            }

            if (request.RecruiterId.HasValue)
            {
                query = query.Where(x => x.RecruiterId == request.RecruiterId.Value);
            }

            if (request.JobType.HasValue)
            {
                query = query.Where(x => (int)x.JobType == request.JobType.Value);
            }

            // 6. Sorting
            var now = DateTime.UtcNow;

            // Priority 1: Boosted jobs (BoostExpiryTime > Now)
            // Priority 2: Tie-breaking for boosted jobs (ViewCount DESC, SalaryMax DESC, CreatedAt ASC)
            // Priority 3: Normal jobs (SortBy/SortOrder or Default)

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
            bool isDesc = !string.Equals(request.SortOrder, "asc", StringComparison.OrdinalIgnoreCase);

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy.ToLower())
                {
                    case "salary":
                        orderedQuery = isDesc ? orderedQuery.ThenByDescending(x => x.SalaryMin) : orderedQuery.ThenBy(x => x.SalaryMin);
                        break;
                    case "date":
                        orderedQuery = isDesc ? orderedQuery.ThenByDescending(x => x.CreatedAt) : orderedQuery.ThenBy(x => x.CreatedAt);
                        break;
                    default:
                        orderedQuery = isDesc ? orderedQuery.ThenByDescending(x => x.CreatedAt) : orderedQuery.ThenBy(x => x.CreatedAt);
                        break;
                }
            }
            else
            {
                orderedQuery = orderedQuery.ThenByDescending(x => x.CreatedAt);
            }

            return await PagedList<Job>.CreateAsync(orderedQuery, request.Page, request.PageSize);
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
    }
}
