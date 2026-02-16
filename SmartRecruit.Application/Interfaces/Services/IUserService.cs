using SmartRecruit.Application.DTO.Auth;

namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
