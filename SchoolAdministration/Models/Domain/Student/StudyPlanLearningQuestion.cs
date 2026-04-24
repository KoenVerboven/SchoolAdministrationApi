using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudyPlanLearningQuestion //summary: Represents a learning question associated with a study plan, including details such as the question text, answer, and related metadata.
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudyPlans")]
        public int StudyPlanId { get; set; }
        public required string QuestionText { get; set; }
        public string? Answer { get; set; }
        public string? AnswerFilePath { get; set; } 
        public string? Remarks { get; set; }
        public int CreatedBy  { get; set; }
        public  int CreateDate { get; set; }
    }
}
