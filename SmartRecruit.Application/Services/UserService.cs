using AutoMapper;
using SmartRecruit.Application.DTO.Admin;
using SmartRecruit.Application.Helpers;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<AdminUserResponse>> GetUsersAsync(UserSearchRequest request)
        {
            var users = await _unitOfWork.Users.GetUsersAsync(request);
            return users.MapToPagedList<User, AdminUserResponse>(_mapper);
        }

        public async Task<bool> UpdateUserStatusAsync(long userId, UpdateUserStatusRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.IsActive = request.IsActive;
            user.LockReason = request.IsActive ? null : request.LockReason;

            _unitOfWork.Users.Update(user);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
