using Certificates2024.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class Candidate : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name can only contain letters and spaces.")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name can only contain letters and spaces.")]
        public string? LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Identification Number")]
        [Required(ErrorMessage = "Identification Number is required")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Identification number cannot be zero and must be a positive number.")]
        public string? PhotoIdNumber { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required")]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@]+$", ErrorMessage = "Email must contain exactly one '@' and a valid domain.")]
        public string? Email { get; set; }

        //Relationship with CandidateCertificates    
        public List<CandidateCertificate>? CandidateCertificates { get; set; }
    }
}
