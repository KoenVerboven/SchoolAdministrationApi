namespace SchoolAdministration.Models.Domain.Document
{
    public abstract class Document
    {
        public int Id { get; set; }
        public required string FilePath { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
