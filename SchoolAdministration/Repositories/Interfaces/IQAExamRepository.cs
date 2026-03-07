using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IQAExamRepository
    {
        Task<IEnumerable<QAExam>> GetAllAsync();
        Task<QAExam?> GetByIdAsync(int id);
        Task AddExamAsync(QAExam QAExam);
        Task UpdateExam(QAExam QAExam);
        Task DeleteExamAsync(int id);
        Task<int> CountAsync();
    }
}
