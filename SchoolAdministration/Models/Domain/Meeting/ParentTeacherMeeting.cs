using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministration.Models.Domain.Meeting
{
    public class ParentTeacherMeeting
    {
        public int Id { get; set; }
        public  int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime MeetingStartDate { get; set; }
        public DateTime MeetingEndDate { get; set; }
        public required string MeetingPlace { get; set; }
        string MeetingNotes { get; set; } = string.Empty;
        public int Status { get; set; }
        public required ICollection<Parent> Parents { get; set; }
    }
}
