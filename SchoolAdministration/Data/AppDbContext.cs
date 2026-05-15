using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.Exam.MultipleChoice;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Models.Domain.Invoice;
using SchoolAdministration.Models.Domain.Qualification;
using SchoolAdministration.Models.Domain.School;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.Domain.Teacher;
using SchoolAdministration.Models.Domain.User;

namespace SchoolAdministration.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<TeacherAddress> TeacherAddresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseScheduling> CourseSchedulings { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<QAExam> QAExams { get; set; }
        public DbSet<QAExamQuestion> QAExamQuestions { get; set; }
        public DbSet<QAExamAnswer>  QAExamAnswers { get; set; }
        public DbSet<QAExamAnswerByStudentId> QAExamAnswerByStudentIds { get; set; }
        public DbSet<MCExam> MCExams { get; set; }  
        public DbSet<MCExamQuestion> MCExamQuestions { get; set; }
        public DbSet<MCExamOption> MCExamOptions { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanDetailLine> StudyPlanDetailLines { get; set; }
        public DbSet<StudyPlanLearningQuestion> StudyPlanLearningQuestions { get; set; }
        public DbSet<School>Schools { get; set; }
        public DbSet <SchoolDepartment>SchoolDepartments { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StudentPresence>StudentsPresence { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<StudentImage> StudentImages { get; set; } //Todo : change name StudentImages to StudentImage? // One-to-one relationship with Student : each student has one image
        public DbSet<StudentClassRegistration> StudentClassRegistrations { get; set; }
        public DbSet<TeacherPresence> TeacherPresences { get; set; }
        public DbSet<InvoiceDetailLine> InvoiceDetailLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<StudentCertificate> StudentCertificates { get; set; }
        public DbSet<StudentDiploma> StudentDiplomas { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<HomeWorkDetailLine> HomeWorkDetailLines { get; set; }
        public DbSet<HomeWorkDetailLineStudentAnswer> HomeWorkDetailLineStudentAnswers { get; set; }
        public DbSet<HomeWorkDetailLineCorrectAnswer> HomeWorkDetailLineCorrectAnswers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "f570f646-3f00-477f-a9cf-5053f03f0eaf", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = "7cc42937-7905-486c-bfcc-7c9319994565", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90", Name = "SchoolEmployee", NormalizedName = "SCHOOLEMPLOYEE" },
                new IdentityRole { Id = "906572c2-a601-4286-8e0f-8c03e0395e85", Name = "Teacher", NormalizedName = "TEACHER" },
                new IdentityRole { Id = "c09ca4e9-4fb1-4599-8213-4385b5ba9e68", Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Id = "4de15cdf-c009-4a7c-9134-245106e8ed02", Name = "Parent", NormalizedName = "PARENT" },
                new IdentityRole { Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890", Name = "Tester", NormalizedName = "TESTER" }
            );

            //https://stackoverflow.com/questions/34343599/how-to-seed-users-and-roles-with-code-first-migration-using-identity-asp-net-cor
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
