using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExamAsync(Exam exam)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteExamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
