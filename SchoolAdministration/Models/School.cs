using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string StreetAndNumber { get; set; }
        public int ZipCode { get; set; }
        public string? Description { get; set; }
        public int CountryId { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string[]? SocialMedia { get; set; }
        public ICollection<SchoolDepartment>? SchoolDepartments { get; set; }
    }
}
