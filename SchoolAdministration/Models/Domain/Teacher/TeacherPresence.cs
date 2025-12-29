using SchoolAdministration.Models.Domain.Student;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Teacher
{
    public class TeacherPresence
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; } //FK
        public bool Presence { get; set; }
        public int? AbsenceReason { get; set; }
        public string? Comment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistratedByUSerId { get; set; } //FK

    }
}
