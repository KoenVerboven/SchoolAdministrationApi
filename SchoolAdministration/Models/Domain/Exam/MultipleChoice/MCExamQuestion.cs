namespace SchoolAdministration.Models.Domain.Exam.MultipleChoice
{
    public class MCExamQuestion
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionText { get; set; }
        public ICollection<MCExamOption>? MCExamAnswers { get; set; }
    }
}
