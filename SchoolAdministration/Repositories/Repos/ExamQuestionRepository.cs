using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ExamQuestionRepository : IExamQuestionRepository
    {
        public Task AddExamQuestionAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExamQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamQuestion>> GetAllExamQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExamQuestion?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExamQuestionAsync(ExamQuestion examQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
