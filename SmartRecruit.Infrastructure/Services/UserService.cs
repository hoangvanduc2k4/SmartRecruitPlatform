using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartRecruit.Application.DTO.Auth;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Application.Utils;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartRecruit.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .Include(u => u.CandidateProfile)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

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

            var token = GenerateJwtToken(user);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = "dummy-refresh-token", // Implement later
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Email = user.Email,
                AvatarUrl = user.AvatarUrl
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
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

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

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
