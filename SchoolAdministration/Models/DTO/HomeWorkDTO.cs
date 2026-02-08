using SchoolAdministration.Models.Domain.HomeWork;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.DTO
{
    public class HomeWorkDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Homework Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "DueDate is required.")]
        public required DateTime DueDate { get; set; }
        public int TeacherId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required HomeWorkDetailLine[] HomeWorkDetailLines { get; set; }
    }
}
