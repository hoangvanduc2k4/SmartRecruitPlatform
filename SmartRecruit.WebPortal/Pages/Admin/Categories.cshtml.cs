
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models.Api.Category;
using WebPortal.Services.Api;

namespace WebPortal.Pages.Admin
{
    public class CategoriesModel : PageModel
    {
        private readonly ICategoryApiService _categoryApiService;

        public CategoriesModel(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public IList<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        [BindProperty]
        public CreateCategoryDTO CreateModel { get; set; } = new();

        [BindProperty]
        public UpdateCategoryDTO EditModel { get; set; } = new();

        [BindProperty]
        public long EditCategoryId { get; set; }

        [BindProperty]
        public long DeleteCategoryId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var filter = new CategoryFilter
            {
                PageNumber = CurrentPage,
                PageSize = 10,
                SearchTerm = SearchTerm
            };

            var response = await _categoryApiService.GetCategoriesPagedAsync(filter);
            if (response.Success)
            {
                Categories = response.Data?.ToList() ?? new List<CategoryResponse>();
                TotalPages = response.TotalPages;
                TotalCount = response.TotalCount;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            ModelState.Clear();
            if (!TryValidateModel(CreateModel, nameof(CreateModel)))
            {
                var errors = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                TempData["ErrorMessage"] = string.IsNullOrWhiteSpace(errors) ? "Vui lòng kiểm tra lại thông tin nhập vào." : errors;
                return RedirectToPage(new { CurrentPage, SearchTerm });
            }

            var result = await _categoryApiService.CreateCategoryAsync(CreateModel);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message ?? "Thêm danh mục mới thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message ?? "Có lỗi xảy ra khi thêm danh mục.";
            }

            return RedirectToPage(new { CurrentPage, SearchTerm });
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            ModelState.Clear();
            if (!TryValidateModel(EditModel, nameof(EditModel)) || EditCategoryId <= 0)
            {
                var errors = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                TempData["ErrorMessage"] = string.IsNullOrWhiteSpace(errors) ? "Thông tin cập nhật không hợp lệ." : errors;
                return RedirectToPage(new { CurrentPage, SearchTerm });
            }

            var result = await _categoryApiService.UpdateCategoryAsync(EditCategoryId, EditModel);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message ?? "Cập nhật danh mục thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = result.Message ?? "Có lỗi xảy ra khi cập nhật danh mục.";
            }

            return RedirectToPage(new { CurrentPage, SearchTerm });
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (DeleteCategoryId <= 0)
            {
                TempData["ErrorMessage"] = "ID không hợp lệ.";
                return RedirectToPage(new { CurrentPage, SearchTerm });
            }

            var result = await _categoryApiService.DeleteCategoryAsync(DeleteCategoryId);
            if (result)
            {
                TempData["SuccessMessage"] = "Xóa danh mục thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa danh mục.";
            }

            return RedirectToPage(new { CurrentPage, SearchTerm });
        }
    }
}