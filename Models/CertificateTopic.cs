using Certificates2024.Data.Base;
using Certificates2024.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class CertificateTopic: IEntityBase
    {
        [Key]
        public int CertificateTopicId { get; set; }
        [Display(Name = "Certificate Topic")]
        public TopicName TopicName { get; set; }
        //Relationship with CandidateCertificate
        public List<CandidateCertificate> CandidateCertificates { get; set; }
        //Relationship with Question
        public List<Question> Questions { get; set; }
        // Explicit implementation of IEntityBase.Id
        int IEntityBase.Id
        {
            get => CertificateTopicId;
            set => CertificateTopicId = value;
        }
    }
   
}
