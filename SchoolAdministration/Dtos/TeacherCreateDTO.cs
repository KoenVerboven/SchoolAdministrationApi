using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Dtos
{
    public class TeacherCreateDTO
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Street and number")]
        [StringLength(30, ErrorMessage = "Street and number cannot longer than 30 characters")]
        public string? StreetAndNumber { get; set; }

        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Belgium zipcode must be 4 digits long.")]
        public int? Zipcode { get; set; }

        public int Gender { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public required string Phone { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        [Display(Name = "Marital status")]
        public byte MaritalStatusId { get; set; }
    }
}
