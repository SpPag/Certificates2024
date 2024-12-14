using Certificates2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateCertificate>().HasKey(cc => cc.CandidateCertificateId);

            modelBuilder.Entity<CandidateCertificate>().HasOne(c => c.Candidate).WithMany(cc => cc.CandidateCertificates).HasForeignKey(c => c.CandidateId);

            modelBuilder.Entity<CandidateCertificate>().HasOne(ct=>ct.CertificateTopic).WithMany(cc=>cc.CandidateCertificates).HasForeignKey(ct=>ct.CertificateTopicId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CertificateTopic> CertificateTopics { get; set; }
        public DbSet<CandidateCertificate> CandidateCertificates { get; set; }
        public DbSet<Question> Questions { get; set; } 
    }
}
