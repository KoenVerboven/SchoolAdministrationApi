using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam.QuestionAnswer
{
    public class QAExamAnswer
    {
        [Key]
        public int Id { get; set; }
        public int QAExamQuestionId { get; set; } //FK to QAExamQuestion
        public required string CorrectAnswer { get; set; }
        public int TeacherId { get; set; }
    }
}
