using SchoolAdministration.Models.Domain.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain.General
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public required DateTime DateOfBirth { get; set; }

        [NotMapped]
        public string FullName { get => LastName + " " + FirstName; }

        [NotMapped]
        public int Age { get; set; }

        public int Gender { get; set; }

        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Length(5, 30)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public required string Phone { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

    }
}
