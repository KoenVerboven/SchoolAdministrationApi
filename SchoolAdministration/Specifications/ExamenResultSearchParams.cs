namespace SchoolAdministration.Specifications
{
    public record ExamenResultSearchParams
    (
        int StudentId,
        int CourseId,
        int ExamId,
        int TeacherId,
        string Sort,
        int PageSize,
        int PageNumber
    );
    
}
