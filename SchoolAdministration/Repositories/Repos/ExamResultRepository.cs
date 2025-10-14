using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly AppDbContext _context;

        public ExamResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExamResultAsync(ExamResult examResult)
        {
            await _context.ExamResults.AddAsync(examResult);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.ExamResults.CountAsync();
        }

        public async Task DeleteExamResultAsync(int id)
        {
            var examResultInDb = await _context.ExamResults.FindAsync(id) ?? throw new KeyNotFoundException($"ExamResult with id {id} was not found.");
            _context.ExamResults.Remove(examResultInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResultsAsync()
        {
            return await _context.ExamResults.ToListAsync();
        }

        public async Task<ExamResult?> GetByIdAsync(int id)
        {
            return await _context.ExamResults.FindAsync(id);
        }

        public async Task UpdateExamResultAsync(ExamResult examResult)
        {
            _context.ExamResults.Update(examResult);
            await _context.SaveChangesAsync();
        }
    }
}
