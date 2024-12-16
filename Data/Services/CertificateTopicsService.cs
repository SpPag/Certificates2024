using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public class CertificateTopicsService:EntityBaseRepository<CertificateTopic>, ICertificateTopicsService
    {
        private readonly AppDbContext _context;
        public CertificateTopicsService(AppDbContext context) : base(context) { }
    }
}
