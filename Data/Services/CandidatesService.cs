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

        public async Task<Candidate?> GetByIdAsync(int id, string userId, bool isAdmin)
        {
            // Fetch the candidate along with the associated ApplicationUser
            var candidate = await _context.Candidates
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(c => c.Id == id);

            // If the candidate does not exist, return null
            if (candidate == null)
            {
                return null;
            }

            // If the user is not an admin, ensure they own the candidate record
            if (!isAdmin && candidate.ApplicationUserId != userId)
            {
                return null; // Restrict access
            }

            // Return the candidate if the access check passes
            return candidate;
        }

    }
}
