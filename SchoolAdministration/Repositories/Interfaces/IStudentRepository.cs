using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<StudentExamsResultDTO>> GetStudentExamResultsAsync();
        Task<IEnumerable<Student>> GetByNameStartWithAsync(string name);
        Task<IEnumerable<Student>> GetFilterAsync(StudentSpecParams studentSpecParams);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        bool StudentExist(Student student);
        Task <int>CountAsync();
    }
}
