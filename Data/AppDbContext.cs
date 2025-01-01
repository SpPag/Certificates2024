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
            modelBuilder.Entity<CandidateResponse>()
                .HasOne(cr => cr.CandidateTest)
                .WithMany(ct => ct.Responses)
                .HasForeignKey(cr => cr.CandidateTestId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade for CandidateTest

            modelBuilder.Entity<CandidateResponse>()
                .HasOne(cr => cr.Question)
                .WithMany(q => q.Responses)
                .HasForeignKey(cr => cr.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict for Question

            modelBuilder.Entity<CandidateTest>()
                .HasOne(ct => ct.CandidateCertificate)
                .WithOne(cc => cc.CandidateTest)
                .HasForeignKey<CandidateTest>(cc => cc.CandidateCertificateId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CertificateTopic> CertificateTopics { get; set; }
        public DbSet<CandidateCertificate> CandidateCertificates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CandidateTest> CandidateTests { get; set; }
    }
}