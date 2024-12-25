namespace SchoolAdministration.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string ExamTitle { get; set; }
        public string Description { get; set; }
        public DateTime ExamenDate { get; set; }
        public int MaxScore { get; set; }
        public int MinScoreToPassExam { get; set; }

        //public virtual ICollection<Question> Questions { get; set; }
        //public virtual Course Course { get; set; }
        //// used to be ICollection of exam statuses, but that got moved to the
        //// ExamResult class
        //public virtual ICollection<ExamResult> Results { get; set; }
    }
}
