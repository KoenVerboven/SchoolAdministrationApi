using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain
{
    public class StudentClassRegistration
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SchoolClassId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredBy { get; set; } = null!;

        // Navigation properties
        public Student Student { get; set; } = null!;
        public SchoolClass SchoolClass  {  get; set; } = null!;
    }
}
