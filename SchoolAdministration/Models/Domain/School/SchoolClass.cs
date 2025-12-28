using SchoolAdministration.Models.Domain.Student;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.School
{
    public class SchoolClass
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Grade { get; set; }
        public int SchoolId { get; set; }
        public int? TeacherId { get; set; }
        public int? DepartmentId { get; set; } 
        public bool IsActive { get; set; }
        public int AcademicYear { get; set; }
        public string? Descripton { get; set; }
        public string? RoomNumber { get; set; }

        // Navigation properties
         //public ICollection<StudentClassRegistration>? StudentClassRegistrations { get; set; }

        // courses list / course shedule
    }
}
