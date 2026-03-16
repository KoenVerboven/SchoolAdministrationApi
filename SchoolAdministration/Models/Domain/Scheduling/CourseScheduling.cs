namespace SchoolAdministration.Models.Domain.Scheduling
{
    public class CourseScheduling
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateOnly SchoolYear { get; set; }
        public int Trimester { get; set; } // 1, 2, or 3
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
