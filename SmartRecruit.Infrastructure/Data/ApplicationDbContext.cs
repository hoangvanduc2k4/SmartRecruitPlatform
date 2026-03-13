using Microsoft.EntityFrameworkCore;
using SmartRecruit.Domain.Entities;
using SmartRecruit.Infrastructure.Data.Seeders;

namespace SmartRecruit.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpToken> OtpTokens { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AILog> AILogs { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. Global Query Filters (Soft Delete) ---
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Job>().HasQueryFilter(j => !j.IsDeleted);
            modelBuilder.Entity<Applications>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Report>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<SavedJob>().HasQueryFilter(sj => !sj.IsDeleted);
            modelBuilder.Entity<Wallet>().HasQueryFilter(w => !w.IsDeleted);
            modelBuilder.Entity<Transaction>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<Notification>().HasQueryFilter(n => !n.IsDeleted);

            // --- 2. Relationships & Cascade Fixes ---
            modelBuilder.Entity<Job>()
         .HasOne(j => j.Category)
         .WithMany(c => c.Jobs)
         .HasForeignKey(j => j.CategoryId)
         .OnDelete(DeleteBehavior.Restrict);
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

            // Fix: Multiple cascade paths for SavedJobs
            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.User)
                .WithMany(u => u.SavedJobs)
                .HasForeignKey(sj => sj.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Fix: Transactions
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CompanyProfile)
                .WithOne(cp => cp.User)
                .HasForeignKey<CompanyProfile>(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CandidateProfile)
                .WithOne(cp => cp.User)
                .HasForeignKey<CandidateProfile>(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- 3. Decimal Precision (Avoid warnings) ---
            modelBuilder.Entity<Job>().Property(j => j.SalaryMin).HasPrecision(18, 2);
            modelBuilder.Entity<Job>().Property(j => j.SalaryMax).HasPrecision(18, 2);
            modelBuilder.Entity<Wallet>().Property(w => w.Balance).HasPrecision(18, 2);
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Applications>().Property(a => a.MatchScore).HasPrecision(5, 2);
            modelBuilder.Entity<Applications>().Property(a => a.ExperienceMatch).HasPrecision(5, 2);
            modelBuilder.Entity<Applications>().Property(a => a.SkillMatch).HasPrecision(5, 2);
            modelBuilder.Entity<CandidateProfile>().Property(cp => cp.ExpectedSalary).HasPrecision(18, 2);

            // Unique Application constraint (Filtered for soft-delete)
            modelBuilder.Entity<Applications>()
                .HasIndex(a => new { a.JobId, a.CandidateId })
                .HasFilter("[IsDeleted] = 0")
                .IsUnique();

            // Unique SavedJob constraint (Filtered for soft-delete)
            modelBuilder.Entity<SavedJob>()
                .HasIndex(sj => new { sj.UserId, sj.JobId })
                .HasFilter("[IsDeleted] = 0")
                .IsUnique();

            modelBuilder.SeedSmartRecruitData();
        }
    }
}