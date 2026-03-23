using SmartRecruit.Application.DTO.Category;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
    }
}