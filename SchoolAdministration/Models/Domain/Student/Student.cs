using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.General;
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
        public ICollection<Course.Course>? Courses { get; set; } 
        public ICollection<StudyPlan>? StudyPlans { get; set; }
        public ICollection<ExamResult>? ExamResults { get; set; }
        public ICollection<StudentPresence>? StudentPresences { get; set; }
        public ICollection<Parent>? Parents { get; set; }
        public StudentImage? StudentImage { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<StudentClassRegistration>? StudentClassRegistrations { get; set; }
        public ICollection<Invoice.Invoice>? Invoices { get; set; }
        public  ICollection<HomeWork.HomeWork>? HomeWorks { get; set; }
        public ICollection<Address>? Addresses { get; set; }

        //todo add audit fields
        //public int CreatedByUserId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int UpdatedByUserUd { get; set; }
        //public DateTime UpdateDate { get; set; }
    }

}
