using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam.QuestionAnswer
{
    public class QAExamAnswerByStudentId
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }//FK to Student who answered the question
        public int TeacherId { get; set; } // FK to Teacher WHO CHECKED THE EXAM ANSWER on correctness
        public int QAExamQuestionId { get; set; } //FK to QAExamQuestion
        public required string AnswerByStudent { get; set; }
        public int Score { get; set; } // Score given by the teacher for this answer
    }
}
