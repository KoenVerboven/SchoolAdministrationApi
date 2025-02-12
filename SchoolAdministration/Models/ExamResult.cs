using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class ExamResult
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; } 
        public double?  ExamenResultScore { get; set; }
        public string? ExamenResultComment { get; set; }
        public int CheckedByTeacherId { get; set; }

        //public virtual Student Student { get; set; }
        //public virtual Exam Exam { get; set; }
    }
}
