using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class ApplicationRepository : GenericRepository<Applications>, IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationRepository> _logger;

        public ApplicationRepository(ApplicationDbContext context, ILogger<ApplicationRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<Applications>> GetApplicationsAsync(ApplicationSearchRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch applications with parameters: {@Request}", request);
            var query = _context.Set<Applications>()
                .Include(a => a.Job)
                .Include(a => a.Candidate)
                .AsNoTracking()
                .AsQueryable();

            // Filter by CandidateId
            if (request.CandidateId.HasValue)
            {
                query = query.Where(a => a.CandidateId == request.CandidateId.Value);
            }

            // Filter by JobId
            if (request.JobId.HasValue)
            {
                query = query.Where(a => a.JobId == request.JobId.Value);
            }

            // Filter by RecruiterId (Job Owner)
            if (request.RecruiterId.HasValue)
            {
                query = query.Where(a => a.Job.RecruiterId == request.RecruiterId.Value);
            }

            // Filter by Status
            if (request.Status.HasValue)
            {
                query = query.Where(a => (int)a.Status == request.Status.Value);
            }

            // Default sort: newest first, or by AI score if requested
            if (request.SortByScore)
            {
                query = query.OrderByDescending(a => a.MatchScore);
            }
            else
            {
                query = query.OrderByDescending(a => a.CreatedAt);
            }

            return await PagedList<Applications>.CreateAsync(query, request.Page, request.PageSize);
        }

        public async Task<bool> IsAlreadyAppliedAsync(long jobId, long candidateId)
        {
            return await _context.Set<Applications>()
                .AnyAsync(a => a.JobId == jobId && a.CandidateId == candidateId);
        }

        public async Task<Applications?> GetApplicationByJobAndCandidateAsync(long jobId, long candidateId)
        {
            return await _context.Set<Applications>()
                .Include(a => a.Candidate)
                    .ThenInclude(u => u.CandidateProfile)
                .Include(a => a.Job)
                .FirstOrDefaultAsync(a => a.JobId == jobId && a.CandidateId == candidateId);
        }

        public async Task<Applications?> GetApplicationWithDetailsAsync(long id)
        {
            return await _context.Set<Applications>()
                .Include(a => a.Job)
                .Include(a => a.Candidate)
                    .ThenInclude(u => u.CandidateProfile)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
