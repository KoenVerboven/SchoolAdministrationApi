namespace SchoolAdministration.Models.Domain.Document
{
    public class StudentClassRegitstrationDocument
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StudentClassRegistrationId { get; set; }
        public required string FilePath { get; set; }

    }
}
