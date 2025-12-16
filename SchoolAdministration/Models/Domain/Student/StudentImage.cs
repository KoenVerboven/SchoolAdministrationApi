using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Student
{
    public class StudentImage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FileName is required.")]
        public required string FileName { get; set; }
        [Required(ErrorMessage = "File extension is required.")]
        public required string FileExtension { get; set; }
        [Required(ErrorMessage = "Url is required.")]
        public required string Url { get; set; }
        public int StudentId { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    }
}
