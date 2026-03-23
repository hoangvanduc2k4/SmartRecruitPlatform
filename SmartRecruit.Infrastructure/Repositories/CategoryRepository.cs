
using Microsoft.EntityFrameworkCore;
using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<PagedList<Category>> GetCategoriesPagedAsync(CategoryFilter filter)
        {
            var query = _context.Categories.Where(c => !c.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var lowerSearchTerm = filter.SearchTerm.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(lowerSearchTerm));
            }

            query = query.OrderBy(c => c.Name);

            return await PagedList<Category>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}