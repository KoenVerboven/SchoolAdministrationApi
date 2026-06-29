
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Models.Domain.Exam
{
    public class ExamResult
    {
        //todo in database : MCExamId ??
        //todo : both fields can be filed in : QAExamId and MCExamId -> no a good solution
        //todo : make a extra table Exam?

        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public  int QAExamId { get; set; }  //todo : change to nullable
        public double?  ExamenResultScore { get; set; }
        public string? ExamenResultComment { get; set; }
        public int CheckedByTeacherId { get; set; }
        public required Student.Student Student { get; set; }


       //A possible object cycle was detected.This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32. Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.Path: $.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Student.ExamResults.Id.",
       //todo : this error is not written to the log??!!
    }
}
