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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. CONFIG USER & SOFT DELETE (Giữ nguyên) ---
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.FullName).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Job>().HasQueryFilter(j => !j.IsDeleted);
            modelBuilder.Entity<Applications>().HasQueryFilter(a => !a.IsDeleted);

            // --- 2. FIX MULTIPLE CASCADE PATHS (PHẦN QUAN TRỌNG) ---

            // Fix lỗi bảng Applications (Bạn đã làm)
            modelBuilder.Entity<Applications>()
                .HasOne(a => a.Candidate)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.CandidateId)
                .OnDelete(DeleteBehavior.Restrict); // Chặn đường User -> Application

            // Fix lỗi bảng Transactions (BUG MỚI CỦA BẠN)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict); // Chặn đường User -> Wallet -> Transaction

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Recruiter)
                .WithMany(u => u.JobsPosted)
                .HasForeignKey(j => j.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- 3. FIX DECIMAL PRECISION (Dọn sạch cảnh báo Validation 30000) ---
            modelBuilder.Entity<Job>().Property(j => j.SalaryMin).HasPrecision(18, 2);
            modelBuilder.Entity<Job>().Property(j => j.SalaryMax).HasPrecision(18, 2);
            modelBuilder.Entity<Wallet>().Property(w => w.Balance).HasPrecision(18, 2);
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);

            modelBuilder.Entity<Applications>().Property(a => a.MatchScore).HasPrecision(5, 2);
            modelBuilder.Entity<Applications>().Property(a => a.SkillMatch).HasPrecision(5, 2);
            modelBuilder.Entity<Applications>().Property(a => a.ExperienceMatch).HasPrecision(5, 2);

            modelBuilder.Entity<CandidateProfile>().Property(cp => cp.ExpectedSalary).HasPrecision(18, 2);

            // --- 4. CẤU HÌNH KHÁC ---
            modelBuilder.Entity<Applications>()
                .HasIndex(a => new { a.JobId, a.CandidateId }).IsUnique();

            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserId);
        }
    }
}