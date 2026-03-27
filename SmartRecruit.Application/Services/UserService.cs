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

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
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
    }
}
