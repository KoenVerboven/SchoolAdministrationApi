using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IExamQuestionRepository
    {
        Task<IEnumerable<ExamQuestion>> GetAllExamQuestionsAsync();
        Task<ExamQuestion?> GetByIdAsync(int id);
        Task AddExamQuestionAsync(ExamQuestion examQuestion);
        Task UpdateExamQuestionAsync(ExamQuestion examQuestion);
        Task DeleteExamQuestionAsync(int id);
    }
}
