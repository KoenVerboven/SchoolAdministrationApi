namespace SchoolAdministration.Models.DTO
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public required string ExamTitle { get; set; }
        public string? Description { get; set; }
        public DateTime ExamenDate { get; set; }
        public DateTime ExamEndDateTime { get; set; }
        public int MaxScore { get; set; }
        public int MinScoreToPassExam { get; set; }
    }
}
