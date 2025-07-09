
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models
{
    public class Student // todo : add Person class ; Student and Teacher inherits Person
    {

        [Key]
        public int Id { get; set; }

        [Display(Name ="First name")]
        [Required(ErrorMessage ="First Name is required.")]
        [StringLength(30, ErrorMessage = "First Name cannot longer than 30 characters")]
        public required string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(30, ErrorMessage = "Last Name cannot longer than 30 characters")]
        public required string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public string FullName { get => LastName + " " + FirstName; }

        [NotMapped]
        public int Age { get; set; }

        [Display(Name = "Street and number")]
        [StringLength(30, ErrorMessage = "Street and number cannot longer than 30 characters")]
        public  string? StreetAndNumber { get; set; }
        public  int? Zipcode { get; set; }
        public int Gender { get; set; }

        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress(ErrorMessage ="Invalid email address.")]
        [Length(5,30)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Name is required.")]
        public string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Parent phone number")]
        public string? ParentPhoneNumber  { get; set; }

        [Display(Name = "Parent last name")]
        [StringLength(30,ErrorMessage = "Parent lastname cannot longer than 30 characters")]
        public string? ParentLastname { get; set; }

        [Display(Name = "Parent first name")]
        [StringLength(30, ErrorMessage = "Parent first cannot longer than 30 characters")]
        public string? ParentFirstName { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<StudyPlan>? StudyPlans { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }


        //public int CreatedByUserId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int UpdatedByUserUd { get; set; }
        //public DateTime UpdateDate { get; set; }
    }

}
