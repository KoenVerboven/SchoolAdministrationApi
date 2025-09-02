namespace SchoolAdministration.Dtos
{
    public class StudentPresenceDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public bool Presence { get; set; }
        public int? AbsenceReason { get; set; }
        public string? Comment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistratedByTeacherId { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherFirstName { get; set; }
    }
}
