using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Extensions;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Constants;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace SmartRecruit.API.Controllers
{
    [Route("api/users/profile")]
    [ApiController]
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileService profileService, ITokenService tokenService, IUnitOfWork unitOfWork, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        private async Task<string> GenerateNewTokenAsync(long userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return string.Empty;
            return _tokenService.GenerateJwtToken(user);
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
            updatedProfile.NewToken = await GenerateNewTokenAsync(userId);
            return Ok(updatedProfile.Wrap("Profile updated successfully"));
        }

        [HttpPost("upload-cv")]
        public async Task<IActionResult> UploadCv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var userId = CurrentUserId;
            _logger.LogInformation("API UploadCv called for User: {UserId}, FileName: {FileName}", userId, file.FileName);
            using var stream = file.OpenReadStream();
            var profile = await _profileService.UploadCvAsync(userId, stream, file.FileName);
            
            return Ok(profile.Wrap("CV uploaded and text extracted successfully"));
        }
        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (file.Length > Policies.MaxAvatarFileSize)
                return BadRequest($"Avatar file size must be <= {Policies.MaxAvatarFileSize / (1024 * 1024)}MB.");

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            if (!allowed.Contains(ext))
                return BadRequest("Only JPG, PNG, or WEBP images are supported for avatar upload.");

            var userId = CurrentUserId;
            _logger.LogInformation("API UploadAvatar called for User: {UserId}, FileName: {FileName}", userId, file.FileName);
            using var stream = file.OpenReadStream();
            var profile = await _profileService.UploadAvatarAsync(userId, stream, file.FileName);
            profile.NewToken = await GenerateNewTokenAsync(userId);

            return Ok(profile.Wrap("Avatar uploaded successfully"));
        }
    }
}