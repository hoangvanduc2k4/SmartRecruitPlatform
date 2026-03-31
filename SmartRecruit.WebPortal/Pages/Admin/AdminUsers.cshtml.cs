using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPortal.Models;
using WebPortal.Models.Api.Admin;
using WebPortal.Services.Api;

namespace WebPortal.Pages
{
    public class AdminUsersModel : PageModel
    {
        private readonly IAdminApiService _adminApiService;

        public AdminUsersModel(IAdminApiService adminApiService)
        {
            _adminApiService = adminApiService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalUsers { get; set; }

        public System.Collections.Generic.IList<AdminUserResponse> Users { get; set; } = new System.Collections.Generic.List<AdminUserResponse>();

        public async Task OnGetAsync()
        {
            var request = new UserSearchRequest
            {
                SearchHeader = SearchTerm,
                Page = CurrentPage,
                PageSize = PageSize
            };

            var pagedResponse = await _adminApiService.GetUsersAsync(request);
            if (pagedResponse.Success)
            {
                Users = pagedResponse.Data?.ToList() ?? new List<AdminUserResponse>();
                TotalUsers = pagedResponse.TotalCount;
                TotalPages = pagedResponse.TotalPages;
            }
        }

        public async Task<IActionResult> OnGetExportAsync()
        {
            var request = new UserSearchRequest
            {
                SearchHeader = SearchTerm,
                Page = 1,
                PageSize = 1000000
            };

            var response = await _adminApiService.ExportUsersAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Users_Export_{DateTime.Now:yyyyMMdd}.xlsx");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleStatusAsync(long userId, bool isActive, string? lockReason)
        {
            var request = new UpdateUserStatusRequest
            {
                IsActive = !isActive, // Toggle the actual status
                LockReason = lockReason
            };

            var success = await _adminApiService.UpdateUserStatusAsync(userId, request);
            return new JsonResult(new { success });
        }
    }
}
