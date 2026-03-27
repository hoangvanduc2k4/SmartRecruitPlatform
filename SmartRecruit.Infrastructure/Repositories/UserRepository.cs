using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using Microsoft.Extensions.Logging;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PagedList<User>> GetUsersAsync(UserSearchRequest request)
        {
            _logger.LogTrace("Executing SQL query to fetch users with parameters: {@Request}", request);
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

        public async Task<AdminUserStatsResponse> GetAdminUserStatsAsync()
        {
            var now = DateTime.UtcNow.Date;
            var totalUsers = await _context.Users.CountAsync();
            var activeUsers = await _context.Users.CountAsync(u => u.IsActive);
            var usersToday = await _context.Users.CountAsync(u => u.CreatedAt >= now);

            return new AdminUserStatsResponse
            {
                TotalUsers = totalUsers,
                ActiveUsers = activeUsers,
                UsersRegisteredToday = usersToday
            };
        }
    }
}
