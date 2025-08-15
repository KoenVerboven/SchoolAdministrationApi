using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;

namespace SchoolAdministration.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StudentPresence>StudentsPresence { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var school1 = new School {Id=1, Name= "Vrije Technische School", StreetAndNumber= "Hoofdweg 1", ZipCode = 2300, CountryId = 0, ContactEmail = "VTechnischool@gmail.com", CreatedAt= DateTime.Now, EstablishedYear= DateTime.Now, CreatedBy = "system", UpdatedBy = ""};
            //var school2 = new School {Id=2, Name = "Basisschool Turnhout", StreetAndNumber = "Kerkstraat 23", ZipCode = 2300,CountryId = 0, ContactEmail = "BSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };
            //var school3 = new School {Id=3, Name = "Kleuterschool Turnhout", StreetAndNumber = "Hoofdbaan 213", ZipCode = 2300,CountryId = 0, ContactEmail = "KSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now ,CreatedBy = "system", UpdatedBy = "" };
            //var school4 = new School {Id=4, Name = "Privateschool Turnhout", StreetAndNumber = "steenweg 88", ZipCode = 2300,CountryId = 0, ContactEmail = "PSchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now ,CreatedBy = "system", UpdatedBy = "" };
            //var school5 = new School {Id=5, Name = "Avondonderwijs Turnhout", StreetAndNumber = "Hoofdweg 1", ZipCode = 2300, CountryId = 0, ContactEmail = "ASchoolTurnhout@gmail.com", CreatedAt = DateTime.Now, EstablishedYear = DateTime.Now, CreatedBy = "system", UpdatedBy = "" };

            //modelBuilder.Entity<School>().HasData(school1,school2,school3, school4);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
