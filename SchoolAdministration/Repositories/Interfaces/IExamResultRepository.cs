using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IExamResultRepository
    {
        Task<IEnumerable<ExamResult>> GetAllExamResultsAsync();
        Task<ExamResult?> GetByIdAsync(int id);
        Task AddExamResultAsync(ExamResult examResult);
        Task UpdateExamResultAsync(ExamResult examResult);
        Task DeleteExamResultAsync(int id);

        Task<int> CountAsync();
    }
}
