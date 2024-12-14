using Certificates2024.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class CertificateTopic
    {
        [Key]
        public int CertificateTopicID { get; set; }
        public TopicName TopicName { get; set; }
        //Relationship with CandidateCertificate
        public List<CandidateCertificate> CandidateCertificates { get; set; }
        //Relationship with Question
        public List<Question> Questions { get; set; } 
    }
   
}
