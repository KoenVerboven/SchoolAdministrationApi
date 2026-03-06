using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IExamQuestionAnwerRepository
    {
        Task<IEnumerable<ExamQuestionAnwer>> GetAllAsync();
        Task<ExamQuestionAnwer?> GetByIdAsync(int id);
        Task AddExamQuestionAsync(ExamQuestionAnwer examQuestion);
        Task UpdateExamQuestionAsync(ExamQuestionAnwer examExamQuestionAnswer);
        Task DeleteExamQuestionAsync(int id);
        Task<int> CountAsync();
    }
}
