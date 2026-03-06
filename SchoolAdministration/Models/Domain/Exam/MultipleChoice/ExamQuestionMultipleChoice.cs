namespace SchoolAdministration.Models.Domain.Exam.MultipleChoice
{
    public class ExamQuestionMultipleChoice
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionText { get; set; }
        public ICollection<ExamQuestionMultipleChoiceAnswer>? ExamQuestionMultipleChoiceAnswers { get; set; }
    }
}
