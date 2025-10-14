using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class SchoolDepartment
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int SchoolId { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? LocationWithinTheSchool { get; set; }
        public ICollection<SchoolClass>? Classe { get; set; } //to nullable ??
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
