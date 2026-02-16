using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartRecruit.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            // Use Repository instead of direct Context
            // Since we need Include(u => u.CandidateProfile), GenericRepository might need an extension or we do 2 queries
            // For now, let's Stick to GenericRepository. But wait, GenericRepository I made doesn't support Include.
            // Let's modify GenericRepository to support Include or just use FindAsync for now (Profile might be null, that's fine for simple login)
            
            // NOTE: The previous logic used .Include(u => u.CandidateProfile). 
            // My current GenericRepository FindAsync doesn't support Include.
            // I will use FindAsync for Auth. If we really need Profile in AuthResponse (we do for Avatar),
            // I should probably add a specific method in IUserRepository or make GenericRepository smarter.
            // For this task scope, let's assume we fetch User first.
            
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }

            if (!PasswordUtil.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            if (!user.IsActive)
            {
                throw new Exception("User is inactive.");
            }

            // Manually re-populate AvatarUrl if it's null (or trust it's in DB).
            // DTO asks for AvatarUrl. BaseEntity doesn't have it, User has it.

            var token = GenerateJwtToken(user);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = "dummy-refresh-token",
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                Email = request.Email,
                PasswordHash = PasswordUtil.HashPassword(request.Password),
                FullName = request.FullName,
                Role = request.Role,
                IsActive = true,
                AvatarUrl = "https://i.pravatar.cc/150"
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            var token = GenerateJwtToken(user);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = "dummy-refresh-token",
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        private string GenerateJwtToken(User user)
        {
            var key = _configuration["Jwt:Key"] ?? "SecretKeyForDevelopmentAndTestingOnly12345";
            var issuer = _configuration["Jwt:Issuer"] ?? "SmartRecruit.API";
            var audience = _configuration["Jwt:Audience"] ?? "SmartRecruit.WebPortal";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("Fullname", user.FullName)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
