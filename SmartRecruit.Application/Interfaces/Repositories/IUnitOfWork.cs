using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<RefreshToken> RefreshTokens { get; }
        IGenericRepository<OtpToken> OtpTokens { get; }
        IGenericRepository<SavedJob> SavedJobs { get; }

        Task<int> CompleteAsync();
    }
}
