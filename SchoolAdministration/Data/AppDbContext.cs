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
            string superAdminRoleId = "f570f646-3f00-477f-a9cf-5053f03f0eaf";
            string adminRoleId = "7cc42937-7905-486c-bfcc-7c9319994565";
            string schoolEmployeeRoleId = "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90";
            string teacherRoleId = "906572c2-a601-4286-8e0f-8c03e0395e85";
            string studentRoleId = "c09ca4e9-4fb1-4599-8213-4385b5ba9e68";
            string parentRoleId = "4de15cdf-c009-4a7c-9134-245106e8ed02";
            string testerRoleId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";

            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = superAdminRoleId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = schoolEmployeeRoleId, Name = "SchoolEmployee", NormalizedName = "SCHOOLEMPLOYEE" },
                new IdentityRole { Id = teacherRoleId, Name = "Teacher", NormalizedName = "TEACHER" },
                new IdentityRole { Id = studentRoleId, Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Id = parentRoleId, Name = "Parent", NormalizedName = "PARENT" },
                new IdentityRole { Id = testerRoleId, Name = "Tester", NormalizedName = "TESTER" }
            );

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
                new IdentityRoleClaim<string>
                {
                    Id = 1, // Explicit integer primary key required
                    RoleId = adminRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Users.Create"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 2,
                    RoleId = adminRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Users.Update"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 3,
                    RoleId = adminRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Users.Delete"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 4,
                    RoleId = schoolEmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Users.Create"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 5,
                    RoleId = schoolEmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Users.Update"
                },
                 new IdentityRoleClaim<string>
                 {
                     Id = 6,
                     RoleId = schoolEmployeeRoleId,
                     ClaimType = "Permission",
                     ClaimValue = "Students.Create"
                 },
                new IdentityRoleClaim<string>
                {
                    Id = 7,
                    RoleId = schoolEmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Students.Update"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 8,
                    RoleId = schoolEmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Teachers.Create"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 9,
                    RoleId = schoolEmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "Teachers.Update"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 10,
                    RoleId = teacherRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "HomeWorks.Create"
                },
                new IdentityRoleClaim<string>
                {
                    Id = 11,
                    RoleId = teacherRoleId,
                    ClaimType = "Permission",
                    ClaimValue = "HomeWorks.Update"
                }
              
            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
