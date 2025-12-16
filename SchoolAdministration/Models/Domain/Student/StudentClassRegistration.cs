using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Models.Domain.School;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    //[Keyless] // Uncomment if this entity does not have a primary key
    public class StudentClassRegistration
    {
        public int Id { get; set; } // Todo : remove if not needed
        public int StudentId { get; set; }
        public int SchoolClassId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public SchoolClass SchoolClass  {  get; set; } = null!;
    }
}
