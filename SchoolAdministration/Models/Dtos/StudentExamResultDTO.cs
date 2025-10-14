namespace SchoolAdministration.Models.Dtos
{
    public class StudentExamsResultDTO
    {
        public int Id { get; set; }
        public required string StudentLastName { get; set; }
        public required string StudentFirstName { get; set; }
        public string StudentEmail { get; set; }
        public required string ExamName { get; set; }
        public double ExamenResult { get; set; }
        public int MaxScore { get; set; }
        public int MinScoreToPassExam { get; set; }
    }
}
