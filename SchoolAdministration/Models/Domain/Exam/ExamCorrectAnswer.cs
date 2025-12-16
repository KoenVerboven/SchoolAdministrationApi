using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam
{
    public class ExamCorrectAnswer
    {
        [Key]
        public int Id { get; set; }
        public int ExamQuestionId { get; set; }
        public required string CorrectAnswer { get; set; }
        public int TeacherId { get; set; }
    }
}
