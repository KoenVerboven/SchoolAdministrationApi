namespace SchoolAdministration.Models.Domain.Document
{
    public class InvoiceDocument
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int InvoiceID { get; set; }
        public required string FilePath { get; set; }
    }
}
