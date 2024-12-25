namespace SchoolAdministration.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public decimal?  Score { get; set; }
        public string? ExamenResultComment { get; set; }
        public int TeacherId { get; set; }

        //public virtual Student Student { get; set; }
        //public virtual Exam Exam { get; set; }
    }
}
