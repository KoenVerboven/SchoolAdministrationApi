namespace SchoolAdministration.Dtos
{
    public class StudentCourseDTO
    {
       public int StudentId { get; set; }
       public string? StudentLastName { get; set; }
       public string? StudentFirstName { get; set; }
       public int CourseId { get; set; }
       public string? CourseName { get; set; }
       public DateTime CourseStartDate { get; set; }
       public DateTime CourseEndDate { get; set; }
       public decimal? AmountPaid { get; set; }
       public decimal? TotalAmount { get; set; }
       public bool? FullyPaid { get; set; }
    }
}
