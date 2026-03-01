using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.General;
using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Models.Domain.Invoice;
using SchoolAdministration.Models.Domain.Qualification;
using SchoolAdministration.Models.Domain.School;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.Domain.Teacher;

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
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanPart> StudyPlanParts { get; set; }
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
            var address1 = new Address { Id = 1, StreetAndNumber = "Hoofdweg 1",Zipcode = 2300, City = "Turnhout", CountryCode = "BEL" };
            var address2 = new Address { Id = 1, StreetAndNumber = "Molenstraat 10", Zipcode = 2350, City = "Vosselaar", CountryCode = "BEL" };
            var address3 = new Address { Id = 1, StreetAndNumber = "Kerkstraat 13", Zipcode = 2350, City = "Vosselaar", CountryCode = "BEL" };
            var address4 = new Address { Id = 1, StreetAndNumber = "Pelikaanstraat 188", Zipcode = 2000, City = "Antwerpen", CountryCode = "BEL" };
            //modelBuilder.Entity<School>().HasData(school1,school2,school3, school4);

            var school1 = new School { Id = 1, Name = "Vrije Technische School", StreetAndNumber = "Hoofdweg 1", ZipCode = 2300, CountryId = 0, ContactEmail = "VTechnischool@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            var school2 = new School { Id = 2, Name = "Basisschool Turnhout", StreetAndNumber = "Kerkstraat 23", ZipCode = 2300, CountryId = 0, ContactEmail = "BSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            var school3 = new School { Id = 3, Name = "Kleuterschool Turnhout", StreetAndNumber = "Hoofdbaan 213", ZipCode = 2300, CountryId = 0, ContactEmail = "KSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            var school4 = new School { Id = 4, Name = "Privateschool Turnhout", StreetAndNumber = "steenweg 88", ZipCode = 2300, CountryId = 0, ContactEmail = "PSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            var school5 = new School { Id = 5, Name = "Avondonderwijs Turnhout", StreetAndNumber = "Hoofdweg 1", ZipCode = 2300, CountryId = 0, ContactEmail = "ASchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            //modelBuilder.Entity<School>().HasData(school1,school2,school3, school4);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
