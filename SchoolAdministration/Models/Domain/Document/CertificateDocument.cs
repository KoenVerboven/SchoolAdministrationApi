namespace SchoolAdministration.Models.Domain.Document
{
    public class CertificateDocument
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CertificateId { get; set; }
        public required string FilePath { get; set; }
    }
}
