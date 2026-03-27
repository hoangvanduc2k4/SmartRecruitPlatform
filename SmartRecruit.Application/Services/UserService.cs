using AutoMapper;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace SmartRecruit.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IExcelService _excelService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger, IExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _excelService = excelService;
        }

        public async Task<PagedList<AdminUserResponse>> GetUsersAsync(UserSearchRequest request)
        {
            _logger.LogInformation("GetUsers use-case: Admin fetching users with Filter: {@Request}", request);
            var users = await _unitOfWork.Users.GetUsersAsync(request);
            return users.MapToPagedList<User, AdminUserResponse>(_mapper);
        }

        public async Task<bool> UpdateUserStatusAsync(long userId, UpdateUserStatusRequest request)
        {
            _logger.LogInformation("UpdateUserStatus use-case: Changing status for User {UserId} to IsActive={IsActive}, Reason={Reason}", userId, request.IsActive, request.LockReason);
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("UpdateUserStatus failed: User {UserId} not found", userId);
                throw new KeyNotFoundException("User not found.");
            }

            user.IsActive = request.IsActive;
            user.LockReason = request.IsActive ? null : request.LockReason;

            _unitOfWork.Users.Update(user);
            var result = await _unitOfWork.CompleteAsync() > 0;
            if (result) _logger.LogInformation("UpdateUserStatus success: User {UserId} status updated", userId);
            return result;
        }

        public async Task<AdminUserStatsResponse> GetAdminUserStatsAsync()
        {
            return await _unitOfWork.Users.GetAdminUserStatsAsync();
        }

        public async Task<byte[]> ExportUsersToExcelAsync(UserSearchRequest request)
        {
            _logger.LogInformation("ExportUsersToExcel use-case: Admin exporting users with Filter: {@Request}", request);
            
            // Create a new request for the export (all matching users)
            var exportRequest = request with { Page = 1, PageSize = 1000000 };
            var users = await _unitOfWork.Users.GetUsersAsync(exportRequest);

            var exportData = users.Select(u => new UserExportDto
            {
                HoTen = u.FullName,
                Email = u.Email,
                VaiTro = u.Role.ToString(),
                TrangThai = u.IsActive ? "Đang hoạt động" : "Bị khóa",
                NgayTao = u.CreatedAt.ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            return _excelService.ExportToExcel(exportData, "Danh sách người dùng");
        }
    }
}
