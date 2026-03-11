using SmartRecruit.Application.Interfaces.Repositories;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data;

namespace SmartRecruit.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; private set; }
        public IGenericRepository<Job> Jobs { get; private set; }
        public IGenericRepository<Wallet> Wallets { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokens { get; private set; }
        public IGenericRepository<OtpToken> OtpTokens { get; private set; }
        public IGenericRepository<CandidateProfile> CandidateProfiles { get; private set; }
        public IGenericRepository<CompanyProfile> CompanyProfiles { get; private set; }
        public IGenericRepository<SavedJob> SavedJobs { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IGenericRepository<Report> Reports { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Jobs = new GenericRepository<Job>(_context);
            Wallets = new GenericRepository<Wallet>(_context);
            RefreshTokens = new GenericRepository<RefreshToken>(_context);
            OtpTokens = new GenericRepository<OtpToken>(_context);
            CandidateProfiles = new GenericRepository<CandidateProfile>(_context);
            CompanyProfiles = new GenericRepository<CompanyProfile>(_context);
            SavedJobs = new GenericRepository<SavedJob>(_context);
            Notifications = new NotificationRepository(_context);
            Reports = new GenericRepository<Report>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}