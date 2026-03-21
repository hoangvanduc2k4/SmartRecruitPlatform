using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<Wallet> Wallets { get; }
        IGenericRepository<RefreshToken> RefreshTokens { get; }
        IGenericRepository<OtpToken> OtpTokens { get; }
        IGenericRepository<CandidateProfile> CandidateProfiles { get; }
        IGenericRepository<CompanyProfile> CompanyProfiles { get; }
        IGenericRepository<SavedJob> SavedJobs { get; }
        INotificationRepository Notifications { get; }

        Task<int> CompleteAsync();
    }
}
