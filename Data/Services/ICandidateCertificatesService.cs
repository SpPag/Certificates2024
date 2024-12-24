using Certificates2024.Data.Base;
using Certificates2024.Models;

namespace Certificates2024.Data.Services
{
    public interface ICandidateCertificatesService : IEntityBaseRepository<CandidateCertificate>
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync(); // Method to get all candidates
        Task<IEnumerable<CertificateTopic>> GetAllCertificateTopicsAsync(); // Method to get all certificate topics
    }
}
