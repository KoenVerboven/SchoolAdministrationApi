using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class SchoolClass
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Grade { get; set; }
        public int SchoolId { get; set; }
        public int TeacherId { get; set; }
        public int? DepartmentId { get; set; } 
        public bool IsActive { get; set; }
        public int AcademicYear { get; set; }
        public string? Descripton { get; set; }
        public string? RoomNumber { get; set; }

        // students list

        // courses list / course shedule
    }
}
