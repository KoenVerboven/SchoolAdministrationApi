namespace SchoolAdministration.Dtos
{
    public class StudentCoursesDTO
    {
       public int StudentId { get; set; }
       public string? StudentLastName { get; set; }
       public string? StudentFirstName { get; set; }
       public int CourseId { get; set; }
       public string? CourseName { get; set; }
       public DateTime CourseStartDate { get; set; }
       public DateTime CourseEndDate { get; set; }
    }
}
