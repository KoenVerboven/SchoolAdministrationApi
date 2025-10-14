namespace SchoolAdministration.Models.Dtos
{
    public class DepartmentCreateDTO
    {
        public required string Name { get; set; }
        public int SchoolId { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? LocationWithinTheSchool { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
