using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public interface ICandidatesService : IEntityBaseRepository<Candidate>
    {
        Task<Candidate> GetCandidateByApplicationUserIdAsync(string applicationUserId);
        Task<Candidate?> GetByIdAsync(int id, string userId, bool isAdmin); // New method
    }
}
