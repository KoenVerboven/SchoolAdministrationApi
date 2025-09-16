using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Dtos
{
    public class StudentCreateDTO
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public string FullName { get => LastName + " " + FirstName; }

        [NotMapped]
        public int Age { get; set; }

        [StringLength(30, ErrorMessage = "Street and number cannot longer than 30 characters")]
        public string? StreetAndNumber { get; set; }
        public int? Zipcode { get; set; }
        public int Gender { get; set; }

        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone Name is required.")]
        public required string Phone { get; set; }

        public string? ParentPhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Parent lastname cannot longer than 30 characters")]
        public string? ParentLastname { get; set; }

        [StringLength(30, ErrorMessage = "Parent first cannot longer than 30 characters")]
        public string? ParentFirstName { get; set; }
        public string? Picture { get; set; }
    }
}
