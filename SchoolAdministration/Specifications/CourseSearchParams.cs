namespace SchoolAdministration.Specifications
{
    public record CourseSearchParams
    (
        string? CourseName,
        string? CourseCode,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
