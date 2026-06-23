namespace SchoolAdministration.Specifications
{
    public record StudentSearchParams
    (
        string? Name,
        string? Email,
        DateOnly? DateOfBirth,
        int gender,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
