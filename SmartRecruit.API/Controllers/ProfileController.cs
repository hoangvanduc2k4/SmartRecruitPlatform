using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using System.Security.Claims;

namespace SmartRecruit.API.Controllers
{
    [Route("api/users/profile")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        private long GetUserIdFromClaims()
        {
            var userIdClaim = User.FindFirst("id")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !long.TryParse(userIdClaim, out var userId))
            {
                throw new UnauthorizedAccessException("Invalid token user ID.");
            }
            return userId;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = GetUserIdFromClaims();
            var profile = await _profileService.GetCurrentUserProfileAsync(userId);
            return Ok(profile.Wrap("Profile retrieved successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var userId = GetUserIdFromClaims();
            var updatedProfile = await _profileService.UpdateUserProfileAsync(userId, request);
            return Ok(updatedProfile.Wrap("Profile updated successfully"));
        }
    }
}
