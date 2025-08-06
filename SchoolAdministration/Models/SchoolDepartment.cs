using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class SchoolDepartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? LocationWithinTheSchool { get; set; }
    }
}
