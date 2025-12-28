using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Models.Domain.School;

namespace SchoolAdministration.Models.Domain.Student
{
    [PrimaryKey(nameof(StudentId), nameof(SchoolClassId))]
    public class StudentClassRegistration
    {
        public int StudentId { get; set; }
        public int SchoolClassId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegisteredByUserId { get; set; }
        public Student Student { get; set; } = null!;
        public SchoolClass SchoolClass  {  get; set; } = null!;
    }
}
