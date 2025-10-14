using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public  int ExamId { get; set; }
        public double?  ExamenResultScore { get; set; }
        public string? ExamenResultComment { get; set; }
        public int CheckedByTeacherId { get; set; }
    }
}
