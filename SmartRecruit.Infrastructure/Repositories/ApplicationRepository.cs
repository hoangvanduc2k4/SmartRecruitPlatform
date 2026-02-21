using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Application;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class ApplicationRepository : GenericRepository<Applications>, IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Applications>> GetApplicationsAsync(ApplicationSearchRequest request)
        {
            var query = _context.Set<Applications>()
                .Include(a => a.Job)
                .Include(a => a.Candidate)
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

            // Filter by Status
            if (request.Status.HasValue)
            {
                query = query.Where(a => (int)a.Status == request.Status.Value);
            }

            // Default sort: newest first
            query = query.OrderByDescending(a => a.CreatedAt);

            return await PagedList<Applications>.CreateAsync(query, request.Page, request.PageSize);
        }
    }
}
