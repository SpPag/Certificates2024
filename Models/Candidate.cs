using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhotoIdNumber { get; set; }
        public string? Email { get; set; }
        //Relationship with CandidateCertificates
        public List<CandidateCertificate> CandidateCertificates { get; set; } 
        public int penisSize { get; set; }
    }

}
