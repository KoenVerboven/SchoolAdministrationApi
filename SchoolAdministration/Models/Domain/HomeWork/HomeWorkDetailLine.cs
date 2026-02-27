using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.HomeWork
{
    public class HomeWorkDetailLine
    {
        [Key]
        public int Id { get; set; }
        public required string HomeWorkAssignment { get; set; }
        public int HomeWorkId { get; set; } // Foreign key to HomeWork
        public int StudentId { get; set; } // Foreign key to Student
        public ICollection<HomeWorkDetailLineStudentAnswer>? HomeWorkDetailLineStudentAnswer { get; set; }
        public HomeWorkDetailLineCorrectAnswer? HomeWorkDetailLineCorrectAnswer { get; set; }
    }
}
