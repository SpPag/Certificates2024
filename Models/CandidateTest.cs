using Certificates2024.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class CandidateTest
    {
        [Key]
        public int Id { get; set; }

        public int CandidateId { get; set; } // Replace with a reference to your Candidate model
        public int CertificateTopicId { get; set; }
        [ForeignKey("CertificateTopicId")]
        public CertificateTopic CertificateTopic { get; set; }

        public DateTime TestDate { get; set; }

        // Relationship with CandidateResponses
        public List<CandidateResponse>? Responses { get; set; }

        public double Score { get; set; } // Computed after test completion
    }
}