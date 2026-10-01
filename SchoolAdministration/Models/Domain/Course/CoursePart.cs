using SchoolAdministration.Models.Domain.Document;

namespace SchoolAdministration.Models.Domain.Course
{
    public class CoursePart
    {
        public int Id { get; set; }
        public int PartNumber { get; set; }
        public int CourseId { get; set; }// Foreign key to the Course entity
        public  required string CoursePartTitle { get; set; }
        public  string? CoursePartText { get; set; }
        public ICollection<CourseDocument>? Documents { get; set; } //verwijzing naar de documenten die bij deze course part horen
    }
}
    