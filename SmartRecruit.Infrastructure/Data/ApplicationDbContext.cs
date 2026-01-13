using Microsoft.EntityFrameworkCore;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. Global Query Filters (Soft Delete) ---
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Job>().HasQueryFilter(j => !j.IsDeleted);
            modelBuilder.Entity<Applications>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Report>().HasQueryFilter(r => !r.IsDeleted);

            // --- 2. Relationships & Cascade Fixes ---

            // Fix: Multiple cascade paths for Applications
            modelBuilder.Entity<Applications>()
                .HasOne(a => a.Candidate)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            // Fix: Multiple cascade paths for Reports
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Reporter)
                .WithMany()
                .HasForeignKey(r => r.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Job)
                .WithMany()
                .HasForeignKey(r => r.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            // Fix: Transactions
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- 3. Decimal Precision (Avoid warnings) ---
            modelBuilder.Entity<Job>().Property(j => j.SalaryMin).HasPrecision(18, 2);
            modelBuilder.Entity<Job>().Property(j => j.SalaryMax).HasPrecision(18, 2);
            modelBuilder.Entity<Wallet>().Property(w => w.Balance).HasPrecision(18, 2);
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Applications>().Property(a => a.MatchScore).HasPrecision(5, 2);
            modelBuilder.Entity<CandidateProfile>().Property(cp => cp.ExpectedSalary).HasPrecision(18, 2);

            // Unique Application constraint
            modelBuilder.Entity<Applications>()
                .HasIndex(a => new { a.JobId, a.CandidateId }).IsUnique();
        }
    }
}