using SmartRecruit.Application.DTO.Profile;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IProfileService
    {
        Task<UserProfileResponse> GetCurrentUserProfileAsync(long userId);
        Task<UserProfileResponse> UpdateUserProfileAsync(long userId, UpdateProfileRequest request);
        Task<UserProfileResponse> UploadCvAsync(long userId, Stream fileStream, string fileName);
        Task<UserProfileResponse> UploadAvatarAsync(long userId, Stream fileStream, string fileName);
    }
}
