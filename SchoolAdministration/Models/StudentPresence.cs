using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class StudentPresence
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; } //FK
        public int CourseId { get; set; } //FK
        public bool Presence { get; set; }
        public string AbsenceReason { get; set; }
    }
}
