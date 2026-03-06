namespace SchoolAdministration.Models.Domain.Exam.MultipleChoice
{
    public class ExamQuestionMultipleChoiceAnswer
    {
        public int Id { get; set; }
        public int ExamQuestionMultipleId { get; set; } //FK
        public required string Answer { get; set; }
        public  bool IsCorrect { get; set; }
    }
}
