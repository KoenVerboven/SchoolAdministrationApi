using SchoolAdministration.Models.Domain.Student;

namespace SchoolAdministrationTests.Data
{
    internal static class StudentMockData
    {
        internal static IEnumerable<Student> StudentList()
        {
            IEnumerable<Student> studentList = [
                new Student()
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
                },
                new Student()
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
                ];
            return studentList;
        }
    }
}
