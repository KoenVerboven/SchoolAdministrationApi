using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.ManualMapper
{
    public static class CourseMappingExtensions
    {

        public static IEnumerable<CourseDTO> MapCoursesToCourseDtos(this IEnumerable<Course> courses)
        {
            List<CourseDTO> coursesDTO = new();
            foreach (var course in courses)
            {
                coursesDTO.Add(new CourseDTO
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseCode = course.CourseCode,
                    CourseDescription = course.CourseDescription,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate,
                    CoursePrice = course.CoursePrice,
                    MaxNumberOfStudents = course.MaxNumberOfStudents,
                    Students = course.Students
                });
            }
            return coursesDTO;  
        }

        public static Course MapCourseDtoToCourse(this CourseDTO dto)
        {
            return new Course
            {
                Id = dto.Id,
                CourseName = dto.CourseName,
                CourseCode = dto.CourseCode,
                CourseDescription = dto.CourseDescription,
                StartDate = dto.StartDate ?? DateTime.MinValue,
                EndDate = dto.EndDate ?? DateTime.MinValue,
                CoursePrice = dto.CoursePrice,
                MaxNumberOfStudents = dto.MaxNumberOfStudents,
                Students = dto.Students

                //todo : map other properties as needed
            };
        }

        public static CourseDTO MapCourseToCourseDto(this Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                CourseDescription = course.CourseDescription,
                StartDate = course.StartDate ,
                EndDate = course.EndDate,
                CoursePrice = course.CoursePrice,
                MaxNumberOfStudents = course.MaxNumberOfStudents,
                Students = course.Students

                //todo : map other properties as needed
            };
        }
    }
}


