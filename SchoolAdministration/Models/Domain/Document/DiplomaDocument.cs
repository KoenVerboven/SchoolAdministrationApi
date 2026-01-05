namespace SchoolAdministration.Models.Domain.Document
{
    public class DiplomaDocument
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DiplomaId { get; set; }
        public required string FilePath { get; set; }
    }
}
