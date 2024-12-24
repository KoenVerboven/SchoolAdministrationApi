using SchoolAdministration.Dtos;
using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetSearchAsync(CourseSearchParameters courseSearchParameters);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);

    }
}
