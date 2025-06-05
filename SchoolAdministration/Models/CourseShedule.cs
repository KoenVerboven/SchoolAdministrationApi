using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models
{
    public class CourseShedule
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Comment { get; set; }
    }
}
