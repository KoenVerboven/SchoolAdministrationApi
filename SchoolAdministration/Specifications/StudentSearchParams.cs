namespace SchoolAdministration.Specifications
{
    public record StudentSearchParams
    (
        string? Name,
        string? Email,
        int CourseId,
        int ZipCode,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
