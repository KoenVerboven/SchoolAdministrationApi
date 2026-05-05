using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.Domain.Invoice;

namespace SchoolAdministration.Models.Domain.Student
{
    public class Student : Person
    {
        
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
        public ICollection<StudentAddress>? StudentAddresses { get; set; }
        public ICollection<Invoice.Invoice>? Invoices { get; set; }
        public  ICollection<HomeWork.HomeWork>? HomeWorks { get; set; }
 
        //todo add audit fields
        //public int CreatedByUserId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int UpdatedByUserUd { get; set; }
        //public DateTime UpdateDate { get; set; }
    }

}

//SELECT TOP(200) AspNetUsers.Id, AspNetUsers.Name, AspNetUsers.UserName, AspNetUsers.NormalizedUserName, AspNetUsers.Email, AspNetUsers.NormalizedEmail, AspNetUsers.EmailConfirmed, AspNetUsers.PasswordHash, 
//                  AspNetUsers.SecurityStamp, AspNetUsers.ConcurrencyStamp, AspNetUsers.PhoneNumber, AspNetUsers.PhoneNumberConfirmed, AspNetUsers.TwoFactorEnabled, AspNetUsers.LockoutEnd, AspNetUsers.LockoutEnabled, 
//                  AspNetUsers.AccessFailedCount, AspNetUsers.DateOfBirth, Students.FirstName, Students.LastName, Students.DateOfBirth AS Expr1
//FROM     AspNetUsers INNER JOIN
//                  Students ON AspNetUsers.Id = Students.ApplicationUserId