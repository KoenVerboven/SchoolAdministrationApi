using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.Invoice;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Models.Domain.Student
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
        public required DateTime DateOfBirth { get; set; }

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
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public required string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string? Picture { get; set; }

        // Navigation properties
        public ICollection<Course.Course>? Courses { get; set; } //todo remove many to many relationship between student and course and add a hulp table 'Register' with the fields registerdate and registeredby between the 2 tables
        public ICollection<StudyPlan>? StudyPlans { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
        public ICollection<StudentPresence>? StudentPresences { get; set; }
        public ICollection<Parent>? Parents { get; set; }
        public StudentImage? StudentImage { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<StudentClassRegistration>? StudentClassRegistrations { get; set; }

        //public int CreatedByUserId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int UpdatedByUserUd { get; set; }
        //public DateTime UpdateDate { get; set; }
    }

}
