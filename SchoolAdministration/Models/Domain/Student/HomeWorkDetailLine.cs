using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class HomeWorkDetailLine
    {
        [Key]
        public int Id { get; set; }
        public required string HomeWorkAssignment { get; set; }
        public int HomeWorkId { get; set; } // Foreign key to HomeWork
        public int StudentId { get; set; } // Foreign key to Student
        public required HomeWorkDetailLineStudentAnswer HomeWorkDetailLineStudentAnswer { get; set; }
    }
}
