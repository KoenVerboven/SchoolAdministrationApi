using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsyn();
        Task<IEnumerable<Teacher>> GetAllAsynSort(string sort);
        Task<Teacher?> GetAsynById(int id);
        Task AddTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
        bool TeacherExist(Teacher teacher);
        Task<int>CountAsync();
    }
}
