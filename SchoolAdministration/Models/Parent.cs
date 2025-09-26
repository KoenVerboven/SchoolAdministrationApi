using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class Parent
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int SortOrder { get; set; } //most import : 1
        public int StudentId { get; set; } //FK
        public int RelationShipToStudent { get; set; } //father, mother, brother, sister, grandfather, grandmother,.....
        public bool AddressSameAsStudent { get; set; }
        public string? Occupation { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? WorkEmail { get; set; }
        public bool IsPrimaryContact { get; set; }
        public bool ReceivesInvoices { get; set; }
        public bool ReceivesReports { get; set; }
        public bool ReceivesMailings { get; set; }
        public bool ReceivesSms { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
