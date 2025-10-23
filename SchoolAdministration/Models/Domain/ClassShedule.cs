using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain
{
    public class ClassShedule
    {
        [Key]
        public int Id { get; set; }
        public int SchoolClassId { get; set; } //FK
        public int ClassRoomId { get; set; } //FK
        public int CourseId { get; set; } //FK
        public int TeacherId { get; set; } //FK
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public byte Status { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
