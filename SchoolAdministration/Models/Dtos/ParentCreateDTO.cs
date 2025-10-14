using SchoolAdministration.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Dtos
{
    public class ParentCreateDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public required DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required.")]
        public required string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int SortOrder { get; set; } //most import : 1
        public ICollection<Student>? Students { get; set; }
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
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
