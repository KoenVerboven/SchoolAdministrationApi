namespace SchoolAdministration.Specifications
{
    public record TeacherSearchParams
    (
        string? Name,
        string? Email,
        DateOnly? DateOfBirth,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
