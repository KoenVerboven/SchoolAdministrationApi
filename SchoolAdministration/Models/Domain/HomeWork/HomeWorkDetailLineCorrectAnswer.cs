using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.HomeWork
{
    public class HomeWorkDetailLineCorrectAnswer
    {
        [Key]
        public int Id { get; set; }
        public required string Answer { get; set; }
        public int HomeWorkDetailLineId { get; set; } // Foreign key to HomeWorkDetailLine
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
