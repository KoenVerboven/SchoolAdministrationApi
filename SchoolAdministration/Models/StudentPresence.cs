using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class StudentPresence
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; } //FK
        public int StudentId { get; set; } //FK
        public int? CourseId { get; set; } //FK
        public bool Presence { get; set; }
        public int? AbsenceReason { get; set; }
        public string? Comment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistratedByTeacherId { get; set; } //FK
    }
}
