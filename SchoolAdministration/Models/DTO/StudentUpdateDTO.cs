using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.DTO
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
   
        public int Gender { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public required string Phone { get; set; }

        public string? ParentPhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Parent lastname cannot longer than 30 characters")]
        public string? ParentLastname { get; set; }

        [StringLength(30, ErrorMessage = "Parent first cannot longer than 30 characters")]
        public string? ParentFirstName { get; set; }
        public string? Picture { get; set; }
    }
}
