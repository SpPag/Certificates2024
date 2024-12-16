using Certificates2024.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class Candidate : IEntityBase
    {
        [Key]
        public int CandidateId { get; set; }
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Identification Number")]
        public string? PhotoIdNumber { get; set; }
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        //Relationship with CandidateCertificates    
        public List<CandidateCertificate> CandidateCertificates { get; set; }

    }

}
