using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public  int QAExamId { get; set; } //FK to QAExam
        public double?  ExamenResultScore { get; set; }
        public string? ExamenResultComment { get; set; }
        public int CheckedByTeacherId { get; set; }
    }
}
