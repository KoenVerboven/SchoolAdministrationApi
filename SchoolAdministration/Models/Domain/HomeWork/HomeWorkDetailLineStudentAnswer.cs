namespace SchoolAdministration.Models.Domain.HomeWork
{
    public class HomeWorkDetailLineStudentAnswer
    {
        public int Id { get; set; }
        public required string Answer { get; set; }
        public int HomeWorkDetailLineId { get; set; } // Foreign key to HomeWorkDetailLine
        public int StudentId { get; set; } // Foreign key to Student
    }
}
