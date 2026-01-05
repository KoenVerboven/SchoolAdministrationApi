using SchoolAdministration.Models.Domain.Qualification;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudentDiploma
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DiplomaId { get; set; }
        public DateTime DiplomaDate { get; set; }
        public double? DiplomaScore { get; set; }


        public required Student Student { get; set; }
        public required Diploma Diploma { get; set; }
    }
}
