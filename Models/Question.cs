using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public int CertificateTopicId { get; set; }
        public string? ImageSource { get; set; }
        public bool BooleanA { get; set; }
        public string? AnswerA { get; set; }
        public bool BooleanB { get; set; }
        public string? AnswerB { get; set; }
        public bool BooleanC { get; set; }
        public string? AnswerC { get; set; }
        public bool BooleanD { get; set; }
        public string? AnswerD { get; set; }

    }
}
