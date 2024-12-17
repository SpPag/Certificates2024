using Certificates2024.Data.Base;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Certificates2024.Models
{
    public class Question : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Question")]
        public string? QuestionText { get; set; }
        [Display(Name = "Certificate Topic ID")]
        public int CertificateTopicId { get; set; }
        [ForeignKey("CertificateTopicId")]
        public CertificateTopic? CertificateTopic { get; set; }
        [Display(Name = "Image URL")]
        public string? ImageSource { get; set; }
        [Display(Name = "Correct")]
        public bool BooleanA { get; set; }
        [Display(Name = "Option A")]
        public string? AnswerA { get; set; }
        [Display(Name = "Correct")]
        public bool BooleanB { get; set; }
        [Display(Name = "Option B")]
        public string? AnswerB { get; set; }
        [Display(Name = "Correct")]
        public bool BooleanC { get; set; }
        [Display(Name = "Option C")]
        public string? AnswerC { get; set; }
        [Display(Name = "Correct")]
        public bool BooleanD { get; set; }
        [Display(Name = "Option D")]
        public string? AnswerD { get; set; }
    }
}
