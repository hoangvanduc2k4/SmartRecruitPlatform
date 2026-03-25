using AutoMapper;
using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Exceptions;
using SmartRecruit.Domain.Constants;

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

        public async Task<PagedList<CategoryResponse>> GetCategoriesPagedAsync(CategoryFilter filter)
        {
            var pagedCategories = await _categoryRepository.GetCategoriesPagedAsync(filter);
            var categoryResponses = _mapper.Map<List<CategoryResponse>>(pagedCategories);

            return new PagedList<CategoryResponse>(
                categoryResponses,
                pagedCategories.TotalCount,
                pagedCategories.CurrentPage,
                pagedCategories.PageSize);
        }

        public async Task<CategoryResponse> CreateCategoryAsync(CreateCategoryDTO request)
        {
            // Check for duplicate name (case-insensitive)
            var existing = await _categoryRepository.FindAsync(c => c.Name.ToLower() == request.Name.ToLower() && !c.IsDeleted);
            if (existing != null)
            {
                throw new BadRequestException(Messages.CategoryMsg.ALREADY_EXISTS);
            }

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
                throw new NotFoundException(Messages.CategoryMsg.NOT_FOUND);

            // Check for duplicate name (excluding itself)
            var existing = await _categoryRepository.FindAsync(c => c.Name.ToLower() == request.Name.ToLower() && c.Id != id && !c.IsDeleted);
            if (existing != null)
            {
                throw new InvalidOperationException("Tên danh mục đã tồn tại.");
            }

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
                throw new NotFoundException(Messages.CategoryMsg.NOT_FOUND);

            category.IsDeleted = true;
            category.UpdatedAt = DateTime.UtcNow;

            _categoryRepository.Update(category);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}