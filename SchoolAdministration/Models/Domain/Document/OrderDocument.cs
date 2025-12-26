namespace SchoolAdministration.Models.Domain.Document
{
    public class OrderDocument
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required string FilePath { get; set; }
    }
}
