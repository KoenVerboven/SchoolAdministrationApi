namespace SchoolAdministration.Dtos
{
    public class StudentPresenceCreateDTO
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; } 
        public int? CourseId { get; set; }
        public bool Presence { get; set; }
        public int? AbsenceReason { get; set; }
        public string? Comment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistratedByTeacherId { get; set; }
    }
}
