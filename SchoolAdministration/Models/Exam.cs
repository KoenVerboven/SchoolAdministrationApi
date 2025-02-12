using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; } // doto Foreign key
        public int TeacherId { get; set; } // exam is prepared by teacher
        public string ExamTitle { get; set; }
        public string Description { get; set; }
        public DateTime ExamenDate { get; set; }
        public int MaxScore { get; set; }
        public int MinScoreToPassExam { get; set; }
        public ICollection<ExamQuestion>? ExamQuestions { get; set; }

    }
}
