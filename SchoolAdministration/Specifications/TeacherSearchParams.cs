namespace SchoolAdministration.Specifications
{
    public record TeacherSearchParams
    (
        string? Name,
        string? Email,
        DateOnly? DateOfBirth,
        int gender, //todo : enum type
        string Sort,
        int PageSize,
        int PageNumber
    );
}
