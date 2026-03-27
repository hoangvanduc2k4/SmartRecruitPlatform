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
            var query = _context.Categories
                .Where(c => !c.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                query = query.Where(c => EF.Functions.Collate(c.Name, "Vietnamese_CI_AI").Contains(filter.SearchTerm));
            }

            query = query.OrderBy(c => c.Name);

            return await PagedList<Category>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

        public async Task<bool> ExistsByIdAsync(long? id)
        {
            if (id == null || id <= 0) return false;
            return await _context.Categories.AnyAsync(c => c.Id == id && !c.IsDeleted);
        }
    }
}