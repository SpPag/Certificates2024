using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public class CandidateCertificatesService:EntityBaseRepository<CandidateCertificate>, ICandidateCertificatesService
    {
        private readonly AppDbContext _context;
        public CandidateCertificatesService(AppDbContext context) : base(context) { }
    }
}
