using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudyPlanPart
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public required string GoalDescription { get; set; }
        public string? Remarks { get; set; }
        public int? StudyObjectiveArchievedInProcent { get; set; }
        public int StudyPlanId { get; set; }
        public int? CourseId { get; set; }
    }
}
