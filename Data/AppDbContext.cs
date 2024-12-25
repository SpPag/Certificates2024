using Certificates2024.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateCertificate>().HasKey(cc => cc.Id);

            modelBuilder.Entity<CandidateCertificate>().HasOne(c => c.Candidate).WithMany(cc => cc.CandidateCertificates).HasForeignKey(c => c.CandidateId);

            modelBuilder.Entity<CandidateCertificate>().HasOne(ct => ct.CertificateTopic).WithMany(cc => cc.CandidateCertificates).HasForeignKey(ct => ct.CertificateTopicId);
            modelBuilder.Entity<CertificateTopic>()
                .Property(ct => ct.TopicName)
                .HasConversion<string>(); // Store enum as a string in the database

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CertificateTopic> CertificateTopics { get; set; }
        public DbSet<CandidateCertificate> CandidateCertificates { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
