
using Microsoft.Extensions.Logging;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Domain.Constants;

namespace SmartRecruit.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProfileService> _logger;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICvService _cvService;
        private readonly ITokenService _tokenService;

        public ProfileService(
            IUnitOfWork unitOfWork,
            ILogger<ProfileService> logger,
            ICloudinaryService cloudinaryService,
            ICvService cvService,
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cloudinaryService = cloudinaryService;
            _cvService = cvService;
            _tokenService = tokenService;
        }

        private async Task<string> GenerateNewTokenAsync(long userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return string.Empty;
            return _tokenService.GenerateJwtToken(user);
        }

        public async Task<UserProfileResponse> GetCurrentUserProfileAsync(long userId)
        {
            _logger.LogInformation("GetCurrentUserProfile use-case: Fetching profile for User {UserId}", userId);
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var response = new UserProfileResponse
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                AvatarUrl = user.AvatarUrl,
                Role = user.Role.ToString(),
                CreatedAt = user.CreatedAt
            };

            if (user.Role == Domain.Enums.UserRole.CANDIDATE)
            {
                var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == userId);
                if (candidateProfile != null)
                {
                    response.CandidateProfile = new CandidateProfileDto
                    {
                        Skills = candidateProfile.Skills,
                        ExperienceYears = candidateProfile.ExperienceYears,
                        CVUrl = candidateProfile.CVUrl,
                        CVText = candidateProfile.CVText,
                        ExpectedSalary = candidateProfile.ExpectedSalary
                    };
                }
            }
            else if (user.Role == Domain.Enums.UserRole.RECRUITER)
            {
                var companyProfile = await _unitOfWork.CompanyProfiles.FindAsync(c => c.UserId == userId);
                if (companyProfile != null)
                {
                    response.CompanyProfile = new CompanyProfileDto
                    {
                        CompanyName = companyProfile.CompanyName,
                        CompanyDescription = companyProfile.CompanyDescription,
                        WebsiteUrl = companyProfile.WebsiteUrl,
                        Address = companyProfile.Address,
                        LogoUrl = companyProfile.LogoUrl
                    };
                }
            }

            return response;
        }

        public async Task<UserProfileResponse> UpdateUserProfileAsync(long userId, UpdateProfileRequest request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Update generic User details
            user.FullName = string.IsNullOrWhiteSpace(request.FullName) ? user.FullName : request.FullName;
            _unitOfWork.Users.Update(user);

            if (user.Role == Domain.Enums.UserRole.CANDIDATE)
            {
                var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == userId);
                if (candidateProfile == null)
                {
                    candidateProfile = new CandidateProfile
                    {
                        UserId = userId,
                        Skills = request.Skills,
                        ExperienceYears = request.ExperienceYears ?? 0,
                        ExpectedSalary = request.ExpectedSalary
                    };
                    await _unitOfWork.CandidateProfiles.AddAsync(candidateProfile);
                }
                else
                {
                    candidateProfile.Skills = request.Skills ?? candidateProfile.Skills;
                    if (request.ExperienceYears.HasValue) candidateProfile.ExperienceYears = request.ExperienceYears.Value;
                    if (request.ExpectedSalary.HasValue) candidateProfile.ExpectedSalary = request.ExpectedSalary.Value;
                    _unitOfWork.CandidateProfiles.Update(candidateProfile);
                }
            }
            else if (user.Role == Domain.Enums.UserRole.RECRUITER)
            {
                var companyProfile = await _unitOfWork.CompanyProfiles.FindAsync(c => c.UserId == userId);
                if (companyProfile == null)
                {
                    companyProfile = new CompanyProfile
                    {
                        UserId = userId,
                        CompanyName = request.CompanyName,
                        CompanyDescription = request.CompanyDescription,
                        WebsiteUrl = request.WebsiteUrl,
                        Address = request.Address
                    };
                    await _unitOfWork.CompanyProfiles.AddAsync(companyProfile);
                }
                else
                {
                    companyProfile.CompanyName = request.CompanyName ?? companyProfile.CompanyName;
                    companyProfile.CompanyDescription = request.CompanyDescription ?? companyProfile.CompanyDescription;
                    companyProfile.WebsiteUrl = request.WebsiteUrl ?? companyProfile.WebsiteUrl;
                    companyProfile.Address = request.Address ?? companyProfile.Address;
                    _unitOfWork.CompanyProfiles.Update(companyProfile);
                }
            }

            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("Profile updated successfully for user {UserId}", userId);

            // Fetch updated profile
            var response = await GetCurrentUserProfileAsync(userId);

            // Inject new token after profile update (in case FullName changed and is in claims)
            response.NewToken = await GenerateNewTokenAsync(userId);

            return response;
        }

        public async Task<UserProfileResponse> UploadCvAsync(long userId, Stream fileStream, string fileName)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            if (user.Role != Domain.Enums.UserRole.CANDIDATE)
            {
                throw new InvalidOperationException("Only candidates can upload CVs.");
            }

            // Validation: Size
            if (fileStream.Length == 0)
            {
                throw new ArgumentException("Uploaded CV file is empty.");
            }
            if (fileStream.Length > Policies.MaxCvFileSize)
            {
                throw new ArgumentException($"CV file size must be <= {Policies.MaxCvFileSize / (1024 * 1024)}MB.");
            }

            // Validation: Extension
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if (ext != ".pdf")
            {
                throw new ArgumentException("Only PDF format is supported for CV upload.");
            }

            var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == userId);
            string? oldUrl = candidateProfile?.CVUrl;

            // Buffer stream
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                if (fileStream.CanSeek) fileStream.Position = 0;
                await fileStream.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            _logger.LogInformation("CV data buffered for user {UserId}, size: {Size} bytes", userId, fileBytes.Length);

            // 1. Extract Text
            string cvText;
            using (var extractStream = new MemoryStream(fileBytes))
            {
                cvText = await _cvService.ExtractTextAsync(extractStream);
            }

            // 2. Upload to Cloudinary
            string cvUrl;
            using (var uploadStream = new MemoryStream(fileBytes))
            {
                cvUrl = await _cloudinaryService.ManageFileAsync(uploadStream, fileName, oldUrl);
            }

            // 3. Update Profile
            if (candidateProfile == null)
            {
                candidateProfile = new CandidateProfile
                {
                    UserId = userId,
                    CVUrl = cvUrl,
                    CVText = cvText
                };
                await _unitOfWork.CandidateProfiles.AddAsync(candidateProfile);
            }
            else
            {
                candidateProfile.CVUrl = cvUrl;
                candidateProfile.CVText = cvText;
                _unitOfWork.CandidateProfiles.Update(candidateProfile);
            }

            await _unitOfWork.CompleteAsync();
            _logger.LogInformation("CV uploaded and text extracted for user {UserId}", userId);

            return await GetCurrentUserProfileAsync(userId);
        }

        public async Task<UserProfileResponse> UploadAvatarAsync(long userId, Stream fileStream, string fileName)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Validation: Size
            if (fileStream == null || fileStream.Length == 0)
            {
                throw new ArgumentException("Uploaded avatar file is empty.");
            }
            if (fileStream.Length > Policies.MaxAvatarFileSize)
            {
                throw new ArgumentException($"Avatar file size must be <= {Policies.MaxAvatarFileSize / (1024 * 1024)}MB.");
            }

            // Validation: Extension
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            if (!allowed.Contains(ext))
            {
                throw new ArgumentException("Only JPG, PNG, or WEBP images are supported for avatar upload.");
            }

            if (fileStream.CanSeek) fileStream.Position = 0;

            var oldUrl = IsCloudinaryAvatarUrl(user.AvatarUrl) ? user.AvatarUrl : null;
            var avatarUrl = await _cloudinaryService.ManageFileAsync(fileStream, fileName, oldUrl);

            user.AvatarUrl = avatarUrl;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Avatar uploaded for user {UserId}", userId);

            var response = await GetCurrentUserProfileAsync(userId);
            response.NewToken = await GenerateNewTokenAsync(userId);

            return response;
        }

        private static bool IsCloudinaryAvatarUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            return url.Contains("res.cloudinary.com", StringComparison.OrdinalIgnoreCase)
                && url.Contains("/SmartRecruit/Avatars/", StringComparison.OrdinalIgnoreCase);
        }
    }
}