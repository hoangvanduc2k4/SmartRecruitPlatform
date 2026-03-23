
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.API.Controllers;

namespace SmartRecruit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories.Wrap());
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] CategoryFilter filter)
        {
            var pagedCategories = await _categoryService.GetCategoriesPagedAsync(filter);
            return Ok(pagedCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO request)
        {
            var category = await _categoryService.CreateCategoryAsync(request);
            return Ok(category.Wrap("Tạo danh mục thành công."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCategoryDTO request)
        {
            try
            {
                var category = await _categoryService.UpdateCategoryAsync(id, request);
                return Ok(category.Wrap("Cập nhật danh mục thành công."));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
                return NotFound(new { Success = false, Message = "Không tìm thấy danh mục hoặc đã bị xóa." });

            return Ok(new { Success = true, Message = "Xóa danh mục thành công." });
        }
    }
}