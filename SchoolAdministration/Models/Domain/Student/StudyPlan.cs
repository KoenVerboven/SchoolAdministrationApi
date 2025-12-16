using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudyPlan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int StudentId { get; set; }
        public ICollection<StudyPlanPart>? StudyPlanParts { get; set; }
    }
}

