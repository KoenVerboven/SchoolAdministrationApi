using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministrationTests.Data
{
    internal class ExamResultMockData
    {
        internal static IEnumerable<ExamResult> ExamResultList()
        {
            IEnumerable<ExamResult> examResultList = [
                new ExamResult()
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    QAExamId = 1,
                    ExamenResultScore = 10,
                    ExamenResultComment = "VeryGood",
                    CheckedByTeacherId = 1,
                    Student = new Student()
                    {
                        Id = 1,
                        FirstName = "Koen",
                        LastName = "Verboven",
                        DateOfBirth = DateTime.Now.AddYears(-30),
                        Gender = 1,
                        Email="koen@test.be",
                        Phone = "448389639",
                        Courses = null,
                        StudyPlans = null
                    }
                },
                new ExamResult()
                {
                    Id = 2,
                    StudentId = 2,
                    CourseId = 2,
                    QAExamId = 2,
                    ExamenResultScore = 8,
                    ExamenResultComment = "Good",
                    CheckedByTeacherId = 2,
                    Student = new Student()
                    {
                        Id = 2,
                        FirstName = "Mark",
                        LastName = "Peeters",
                        DateOfBirth = DateTime.Now.AddYears(-34),
                        Gender = 1,
                        Email="mark@test.be",
                        Phone = "44994989",
                        Courses = null,
                        StudyPlans = null
                    }
                }];

            return examResultList;
        }
    }
}
