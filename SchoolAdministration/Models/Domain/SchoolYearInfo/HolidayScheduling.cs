namespace SchoolAdministration.Models.Domain.Scheduling
{
    public class HolidayScheduling
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public  int SchoolYear { get; set; }
    }
}
