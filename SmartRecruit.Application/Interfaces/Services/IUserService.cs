using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<PagedList<AdminUserResponse>> GetUsersAsync(UserSearchRequest request);
        Task<bool> UpdateUserStatusAsync(long userId, UpdateUserStatusRequest request);
        Task<AdminUserStatsResponse> GetAdminUserStatsAsync();
    }
}
