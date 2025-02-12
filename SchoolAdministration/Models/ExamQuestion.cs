using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class ExamQuestion
    {
        [Key]
        public int Id { get; set; }
        public int ExamId { get; set; } //FK
        public int QuestionNumber { get; set; }
        public required string QuestionText { get; set; }
        public double QuestionGrade { get; set; }
    }
}
