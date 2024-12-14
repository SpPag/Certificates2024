using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Certificates2024.Models
{
    public class CandidateCertificate
    {
        [Key]
        public int CandidateCertificateId { get; set; }
        public int CandidateId { get; set; }
        [ForeignKey("CandidateId")]
        public Candidate Candidate { get; set; }
        public int CertificateTopicId { get; set; }
        [ForeignKey("CertificateTopicId")]
        public CertificateTopic CertificateTopic { get; set; }
        public DateTime ExaminationDate { get; set; }
        public int CandidateScore { get; set; }
        public int MaximumScore { get; set; }
        public bool ResultLabel { get; set; }
    


    }
}
