using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Models.DTO
{
    public class ExamResultDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int QAExamId { get; set; } 
        public double? ExamenResultScore { get; set; }
        public string? ExamenResultComment { get; set; }
        public int CheckedByTeacherId { get; set; }
        public required Student Student { get; set; }
    }
}
