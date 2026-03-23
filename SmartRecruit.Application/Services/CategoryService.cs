using AutoMapper;
using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        public async Task<PagedResponse<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter)
        {
            var pagedCategories = await _categoryRepository.GetCategoriesPagedAsync(filter);
            var categoryResponses = _mapper.Map<IEnumerable<CategoryResponse>>(pagedCategories);
            
            return PagedResponse<CategoryResponse>.Create(
                categoryResponses,
                pagedCategories.CurrentPage,
                pagedCategories.PageSize,
                pagedCategories.TotalCount);
        }

        public async Task<CategoryResponse> CreateCategoryAsync(CreateCategoryDTO request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CategoryResponse>(category);
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(long id, UpdateCategoryDTO request)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null || category.IsDeleted)
                throw new KeyNotFoundException("Category not found");

            category.Name = request.Name;
            category.UpdatedAt = DateTime.UtcNow;

            _categoryRepository.Update(category);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CategoryResponse>(category);
        }

        public async Task<bool> DeleteCategoryAsync(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null || category.IsDeleted)
                return false;

            category.IsDeleted = true;
            category.UpdatedAt = DateTime.UtcNow;

            _categoryRepository.Update(category);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
