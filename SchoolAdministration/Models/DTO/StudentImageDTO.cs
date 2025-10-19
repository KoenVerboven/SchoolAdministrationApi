namespace SchoolAdministration.Models.DTO
{
    public class StudentImageDTO
    {
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required string FileExtension { get; set; }
        public required string Url { get; set; }
        public int StudentId { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    }
}
