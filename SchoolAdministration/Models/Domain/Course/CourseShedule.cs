using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Course
{
    public class CourseShedule
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DayOfWeek { get; set; }
        public int WeekNumber { get; set; }
        public int SchoolClassId { get; set; } //FK
        public int ClassRoomId { get; set; } //FK
        public int TeacherId { get; set; } //FK
        public byte Status { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
