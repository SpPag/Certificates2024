using Certificates2024.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Certificates2024.Models
{
    public class CandidateCertificate : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Candidate ID")]
        public int CandidateId { get; set; }
        [ForeignKey("CandidateId")]
        public Candidate? Candidate { get; set; }
        [Display(Name = "Certificate Topic ID")]
        public int CertificateTopicId { get; set; }
        [ForeignKey("CertificateTopicId")]
        public CertificateTopic? CertificateTopic { get; set; }
        [Display(Name = "Date of Examination")]
        public DateTime ExaminationDate { get; set; }
        [Display(Name = "Candidate's Score")]
        public int? CandidateScore { get; set; }
        [Display(Name = "Maximum Score")]
        public int? MaximumScore { get; set; }
        [Display(Name = "Test Result")]
        public bool ResultLabel { get; set; }
    }
}
