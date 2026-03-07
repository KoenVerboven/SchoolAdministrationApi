using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IQAExamDetailRepository
    {
        Task<IEnumerable<QAExamDetail>> GetAllAsync();
        Task<QAExamDetail?> GetByIdAsync(int id);
        Task AddExamAsync(QAExamDetail qAExamDetail);
        Task UpdateExam(QAExamDetail qAExamDetail);
        Task DeleteExamAsync(int id);
        Task<int> CountAsync();
    }
}
