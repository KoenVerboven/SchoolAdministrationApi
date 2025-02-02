namespace SchoolAdministration.Dtos
{
    public class StudentExamsResultDTO
    {
        public int Id { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentEmail { get; set; }
        public string ExamName { get; set; }
        public double ExamenResult { get; set; }

    }
}
