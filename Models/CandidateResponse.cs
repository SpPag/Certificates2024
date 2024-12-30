using Certificates2024.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Certificates2024.Models
{
    public class CandidateResponse
    {
        [Key]
        public int Id { get; set; }

        public int CandidateTestId { get; set; }
        [ForeignKey("CandidateTestId")]
        public CandidateTest CandidateTest { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        public string SelectedAnswer { get; set; } // Candidate's selected answer
    }
}