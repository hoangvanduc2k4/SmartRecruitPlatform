using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<PagedList<Category>> GetCategoriesPagedAsync(CategoryFilter filter);
        Task<bool> ExistsByIdAsync(long? id);  // ✅ Check if category exists (accepts nullable id)
    }
}