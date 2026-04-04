namespace SchoolAdministration.Models.Domain.Exam.MultipleChoice
{
    public class MCExamOption
    {
        public int Id { get; set; }
        public int MCExamQuestionId { get; set; } // FK  
        public required string Option { get; set; }
        public  bool IsCorrectAnswer { get; set; }
    }
}
