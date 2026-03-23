using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Wrappers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<PagedResponse<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter);
        Task<CategoryResponse> CreateCategoryAsync(CreateCategoryDTO request);
        Task<CategoryResponse> UpdateCategoryAsync(long id, UpdateCategoryDTO request);
        Task<bool> DeleteCategoryAsync(long id);
    }
}
