using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Specifications;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IExamResultRepository
    {
        Task<IEnumerable<ExamResult>> GetAllExamResultsAsync();
        Task<ExamResult?> GetByIdAsync(int id);
        Task<IEnumerable<ExamResult>> GetExamResultsByFilterAsync(ExamenResultSearchParams examResultSearchParameters);
        Task AddExamResultAsync(ExamResult examResult);
        Task UpdateExamResultAsync(ExamResult examResult);
        Task DeleteExamResultAsync(int id);
        Task<int> CountAsync();
    }
}
