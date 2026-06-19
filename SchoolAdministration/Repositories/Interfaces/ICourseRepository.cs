using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetSearchAsync(CourseSearchParams courseSearchParameters);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        bool CourseExist(Course course);
        Task<int> CountAsync();

    }
}
