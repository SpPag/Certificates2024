using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public class CadidatesService:EntityBaseRepository<Candidate>, ICandidatesService
    {
        private readonly AppDbContext _context;
        public CandidatesService(AppDbContext context) : base(context) { }
    }
}
