using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ExamResultRepository : IExamRepository
    {
        public Task AddExamAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Exam>? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExamAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
