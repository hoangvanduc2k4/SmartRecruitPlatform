using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<PagedList<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter);
        Task<CategoryResponse> CreateCategoryAsync(CreateCategoryDTO request);
        Task<CategoryResponse> UpdateCategoryAsync(long id, UpdateCategoryDTO request);
        Task<bool> DeleteCategoryAsync(long id);
    }
}