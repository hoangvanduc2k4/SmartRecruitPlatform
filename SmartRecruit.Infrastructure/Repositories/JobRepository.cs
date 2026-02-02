using Microsoft.EntityFrameworkCore;
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

        public JobRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Job>> GetJobsAsync(JobSearchRequest request)
        {
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
            bool isDesc = !string.Equals(request.SortOrder, "asc", StringComparison.OrdinalIgnoreCase); // Default to DESC
            
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                switch (request.SortBy.ToLower())
                {
                    case "salary":
                        query = isDesc ? query.OrderByDescending(x => x.SalaryMin) : query.OrderBy(x => x.SalaryMin);
                        break;
                    case "date":
                        query = isDesc ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                        break;
                    default:
                         query = isDesc ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                        break;
                }
            }
            else
            {
                // Default Sorting: Date Descending
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            return await PagedList<Job>.CreateAsync(query, request.Page, request.PageSize);
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
                }
                else if (!isVisible)
                {
                    job.Status = JobStatus.HIDDEN;
                }
                
                _context.Set<Job>().Update(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
