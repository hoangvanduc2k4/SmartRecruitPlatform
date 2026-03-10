using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<User>> GetUsersAsync(UserSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchHeader))
            {
                var search = request.SearchHeader.ToLower();
                query = query.Where(u => u.FullName.ToLower().Contains(search) || u.Email.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                if (Enum.TryParse<SmartRecruit.Domain.Enums.UserRole>(request.Role.ToUpper(), out var role))
                {
                    query = query.Where(u => u.Role == role);
                }
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(u => u.IsActive == request.IsActive.Value);
            }

            query = query.OrderByDescending(u => u.CreatedAt);

            return await PagedList<User>.CreateAsync(query, request.Page, request.PageSize);
        }
    }
}
