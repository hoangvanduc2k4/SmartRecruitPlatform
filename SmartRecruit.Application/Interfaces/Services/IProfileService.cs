using SmartRecruit.Application.DTO.Profile;
using Microsoft.AspNetCore.Http;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IProfileService
    {
        Task<UserProfileResponse> GetCurrentUserProfileAsync(long userId);
        Task<UserProfileResponse> UpdateUserProfileAsync(long userId, UpdateProfileRequest request);
        Task<UserProfileResponse> UploadCvAsync(long userId, IFormFile file);
        Task<UserProfileResponse> UploadAvatarAsync(long userId, IFormFile file);
    }
}
