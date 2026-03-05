using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
    }
}
