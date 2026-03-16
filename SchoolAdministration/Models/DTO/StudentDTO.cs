using SchoolAdministration.Models.Domain.Student;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }
       
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; } 

        [NotMapped]
        public string FullName { get => LastName + " " + FirstName; }

        [NotMapped]
        public int Age { get; set; }
               
        public int Gender { get; set; }

        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone Name is required.")]
        public required string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }
      
        public string? Picture { get; set; }

        public ICollection<StudentAddress>? StudentAddresses { get; set; }

        public ICollection<Parent>? Parents { get; set; }

    }
}
