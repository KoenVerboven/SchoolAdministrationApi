using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class StudentPresence
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; } //FK
        public int CourseId { get; set; } //FK
        public bool Presence { get; set; }

        //courseDateTime toevoegen;
        public string? AbsenceReason { get; set; }// lijst van maken ipv string

        public string? Comment { get; set; }

        //createByTeacherId toevoegen;
    }
}
