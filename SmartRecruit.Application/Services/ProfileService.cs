using Microsoft.Extensions.Logging;
using SmartRecruit.Application.DTO.Profile;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProfileService> _logger;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICvService _cvService;

        public ProfileService(IUnitOfWork unitOfWork, ILogger<ProfileService> logger, ICloudinaryService cloudinaryService, ICvService cvService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cloudinaryService = cloudinaryService;
            _cvService = cvService;
        }

        public async Task<UserProfileResponse> GetCurrentUserProfileAsync(long userId)
        {
            // Note: Since IGenericRepository might not support eager loading multiple includes easily,
            // we will fetch the user and then explicitly fetch candidate/company profile if needed.
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

            // Fetch and return the updated profile
            return await GetCurrentUserProfileAsync(userId);
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

            var candidateProfile = await _unitOfWork.CandidateProfiles.FindAsync(c => c.UserId == userId);
            string? oldUrl = candidateProfile?.CVUrl;

            // Read entire stream to buffer to ensure multiple services can consume it without interference
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                if (fileStream.CanSeek) fileStream.Position = 0;
                await fileStream.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            if (fileBytes.Length == 0)
            {
                throw new InvalidOperationException("Uploaded CV file is empty.");
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
    }
}
