using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetSearchAsync(CourseSearchParameters courseSearchParameters);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        bool CourseExist(Course course);
        Task<int> CountAsync();

    }
}
