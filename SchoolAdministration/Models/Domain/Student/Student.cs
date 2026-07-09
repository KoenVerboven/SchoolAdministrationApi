using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.Domain.Invoice;

namespace SchoolAdministration.Models.Domain.Student
{
    public class Student : Person
    {
        
        public DateTime RegistrationDate { get; set; }

        public string? Picture { get; set; }

        // navigation properties
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

        // audit fields
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

}

