using Certificates2024.Data.Base;
using Certificates2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Data.Services
{
    public class CandidateCertificatesService : EntityBaseRepository<CandidateCertificate>, ICandidateCertificatesService
    {
        private readonly AppDbContext _context;
        public CandidateCertificatesService(AppDbContext context) : base(context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DbContext was not injected properly.");
        }

        //Implement method to get all candidates
        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        // Implement method to get all certificate topics
        public async Task<IEnumerable<CertificateTopic>> GetAllCertificateTopicsAsync()
        {
            return await _context.CertificateTopics.ToListAsync();
        }
        public async Task<List<CandidateCertificate>> GetCertificatesByUserIdAndRoleAsync(string userId, string userRole)
        {
            var certificates = await _context.CandidateCertificates.Include(n => n.CertificateTopic).Include(n => n.Candidate).ToListAsync();

            if (userRole != "Admin")
            {
                certificates = certificates.Where(n => n.Candidate.ApplicationUserId == userId).ToList();
            }

            return certificates;
        }
        public async Task<Candidate> GetCandidateByUserIdAsync(string userId)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);
        }

    }
}
