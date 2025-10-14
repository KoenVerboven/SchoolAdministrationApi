using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string StreetAndNumber { get; set; }
        public int ZipCode { get; set; }
        public int? CountryId { get; set; }
        public  string? ContactPhone { get; set; }
        public required string ContactEmail { get; set; }
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public string? Description { get; set; }
        public string? SchoolType { get; set; }
        public  int? NumberOfStudents { get; set; }
        public int? NumberOfTeachers { get; set; }
        public DateTime? EstablishedYear { get; set; }
        public string[]? Facilities { get; set; }
        public string[]? SocialMedia { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public ICollection<SchoolDepartment>? SchoolDepartments { get; set; }
    }
}
