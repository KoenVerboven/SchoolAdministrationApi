using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class QAExamDetailRepository : IQAExamDetailRepository
    {
        private readonly AppDbContext _context;

        public QAExamDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExamAsync(QAExamDetail qAExamDetail)
        {
            await _context.QAExamDetails.AddAsync(qAExamDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return _context.QAExamDetails.Count();
        }

        public async Task DeleteExamAsync(int id)
        {
            var ExamInDb = await _context.QAExamDetails.FindAsync(id) ?? throw new KeyNotFoundException($"Exam with id {id} was not found.");
            _context.QAExamDetails.Remove(ExamInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QAExamDetail>> GetAllAsync()
        {
            return await _context.QAExamDetails.ToListAsync();
        }

        public async Task<QAExamDetail?> GetByIdAsync(int id)
        {
            return await _context.QAExamDetails.FindAsync(id);
        }

        public async Task UpdateExam(QAExamDetail qAExamDetail)
        {
            _context.QAExamDetails.Update(qAExamDetail);
            await _context.SaveChangesAsync();
        }

    }
}
