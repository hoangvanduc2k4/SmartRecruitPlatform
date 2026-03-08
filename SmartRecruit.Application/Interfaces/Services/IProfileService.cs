using SmartRecruit.Application.DTO.Profile;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IProfileService
    {
        Task<UserProfileResponse> GetCurrentUserProfileAsync(long userId);
        Task<UserProfileResponse> UpdateUserProfileAsync(long userId, UpdateProfileRequest request);
    }
}
