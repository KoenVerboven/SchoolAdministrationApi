using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Dtos
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Grade { get; set; }
        public int SchoolId { get; set; }
        public int? TeacherId { get; set; }
        public int? DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public int AcademicYear { get; set; }
        public string? Descripton { get; set; } //todo :rename Descripton to  Description
        public string? RoomNumber { get; set; }
        //shedule
    }
}
