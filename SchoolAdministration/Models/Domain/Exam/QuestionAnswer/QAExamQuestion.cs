using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam.QuestionAnswer
{
    public class QAExamQuestion
    {
        [Key]
        public int Id { get; set; }
        public int QAExamId { get; set; } //FK to QAExam
        public int QuestionNumber { get; set; }
        public required string QuestionText { get; set; }
        public double QuestionGrade { get; set; }
        public QAExamAnswer? QAExamAnswer { get; set; }
    }
}
