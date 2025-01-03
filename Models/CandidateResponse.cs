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
        public bool IsCorrect
        {
            get
            {
                if (Question == null) return false; // Ensure Question is not null
                if (SelectedAnswer == Question.AnswerA && Question.BooleanA) return true;
                if (SelectedAnswer == Question.AnswerB && Question.BooleanB) return true;
                if (SelectedAnswer == Question.AnswerC && Question.BooleanC) return true;
                if (SelectedAnswer == Question.AnswerD && Question.BooleanD) return true;
                return false;
            }
        }
    }
}
