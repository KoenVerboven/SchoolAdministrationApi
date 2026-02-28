using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.DTO
{
    public class TeacherDTO
    {
        [Key]
        public int Id { get; set; }

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

        public int Gender { get; set; }

        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Name is required.")]
        public string Phone { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }

        [Display(Name = "Marital status")]
        public byte MaritalStatusId { get; set; }
    }
}
