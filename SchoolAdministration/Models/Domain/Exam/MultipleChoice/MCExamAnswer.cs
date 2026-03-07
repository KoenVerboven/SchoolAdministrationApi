namespace SchoolAdministration.Models.Domain.Exam.MultipleChoice
{
    public class MCExamAnswer
    {
        public int Id { get; set; }
        public int ExamQuestionMultipleId { get; set; } //FK
        public required string Answer { get; set; }
        public  bool IsCorrect { get; set; }
    }
}
