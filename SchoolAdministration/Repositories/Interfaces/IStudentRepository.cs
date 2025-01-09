using SchoolAdministration.Models;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetByNameStartWithAsync(string name);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<Student?> StudentExistsAsync(Student student);
    }
}
