using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; } // FK
        public int TeacherId { get; set; } // FK
        public required string ExamTitle { get; set; }
        public string? Description { get; set; }
        public DateTime ExamenDate { get; set; }
        public DateTime ExamEndDateTime { get; set; }
        public int MaxScore { get; set; }
        public int MinScoreToPassExam { get; set; }
        public ICollection<ExamQuestion>? ExamQuestions { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}
