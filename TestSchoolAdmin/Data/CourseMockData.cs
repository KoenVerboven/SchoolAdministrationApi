using SchoolAdministration.Models.Domain.Course;

namespace SchoolAdministrationTests.Data
{
    internal class CourseMockData
    {
        internal static IEnumerable<Course> CourseList()
        {
            IEnumerable<Course> courseList = [
                new Course()
                {
                    Id = 1,
                   CourseName = "Electronica A2",
                   CourseCode= "E2," ,
                   StartDate= DateTime.Now,
                   EndDate= DateTime.Now,
                   CoursePrice= 10.99M
                },
                new Course()
                {
                    Id = 2,
                   CourseName = "Mathemtics M2",
                   CourseCode= "E2," ,
                   StartDate= DateTime.Now,
                   EndDate= DateTime.Now,
                   CoursePrice= 15.99M
                }
                ]; ;
            return courseList;
        }
    }
}
