using Certificates2024.Data.Base;
using Certificates2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Certificates2024.Data.Services
{
    public class CandidatesService : EntityBaseRepository<Candidate>, ICandidatesService
    {
        private readonly AppDbContext _context;
        public CandidatesService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Candidate> GetCandidateByApplicationUserIdAsync(string applicationUserId)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.ApplicationUserId == applicationUserId);
        }
    }
}
