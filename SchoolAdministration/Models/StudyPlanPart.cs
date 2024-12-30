using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class StudyPlanPart
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string GoalDescription { get; set; }
        public string Remarks { get; set; }
        public int StudyObjectiveArchievedInProcent { get; set; }
        public int StudyPlanId { get; set; }
    }
}
