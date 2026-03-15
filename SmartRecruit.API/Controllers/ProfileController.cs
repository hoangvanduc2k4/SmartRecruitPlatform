using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;

namespace SmartRecruit.API.Controllers
{
    [Route("api/users/profile")]
    [ApiController]
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API GetProfile called for User: {UserId}", userId);
            var profile = await _profileService.GetCurrentUserProfileAsync(userId);
            return Ok(profile.Wrap("Profile retrieved successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API UpdateProfile called for User: {UserId}", userId);
            var updatedProfile = await _profileService.UpdateUserProfileAsync(userId, request);
            return Ok(updatedProfile.Wrap("Profile updated successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(long id)
        {
            var userId = id;
            _logger.LogInformation("API GetProfile called for User: {UserId}", userId);
            var profile = await _profileService.GetCurrentUserProfileAsync(userId);
            return Ok(profile.Wrap("Profile retrieved successfully"));
        }

        [HttpPost("upload-cv")]
        public async Task<IActionResult> UploadCv(IFormFile file)
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API UploadCv called for User: {UserId}, FileName: {FileName}", userId, file?.FileName);
            
            if (file == null) return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();
            var profile = await _profileService.UploadCvAsync(userId, stream, file.FileName);
            
            return Ok(profile.Wrap("CV uploaded and text extracted successfully"));
        }

        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            var userId = CurrentUserId;
            _logger.LogInformation("API UploadAvatar called for User: {UserId}, FileName: {FileName}", userId, file?.FileName);

            if (file == null) return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();
            var profile = await _profileService.UploadAvatarAsync(userId, stream, file.FileName);

            return Ok(profile.Wrap("Avatar uploaded successfully"));
        }
    }
}