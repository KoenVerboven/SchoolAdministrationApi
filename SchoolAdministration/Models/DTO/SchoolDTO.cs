using SchoolAdministration.Models;

namespace SchoolAdministration.Models.DTO
{
    public class SchoolDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string StreetAndNumber { get; set; }
        public int ZipCode { get; set; }
        public int CountryId { get; set; }
        public string? ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public string? Description { get; set; }
        public string? SchoolType { get; set; }
        public int? NumberOfStudents { get; set; }
        public int? NumberOfTeachers { get; set; }
        public DateTime EstablishedYear { get; set; }
        public string[]? Facilities { get; set; }
        public string[]? SocialMedia { get; set; }
    }
}
