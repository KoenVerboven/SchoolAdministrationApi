using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class QAExamRepository : IQAExamRepository
    {
        private readonly AppDbContext _context;

        public QAExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExamAsync(QAExam qAExam)
        {
            await _context.QAExams.AddAsync(qAExam);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return _context.QAExams.Count();
        }

        public async Task DeleteExamAsync(int id)
        {
            var ExamInDb = await _context.QAExams.FindAsync(id) ?? throw new KeyNotFoundException($"Exam with id {id} was not found.");
            _context.QAExams.Remove(ExamInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QAExam>> GetAllAsync()
        {
            return await _context.QAExams.ToListAsync();
        }

        public async Task<QAExam?> GetByIdAsync(int id)
        {
            return await _context.QAExams.FindAsync(id);
        }

        public async Task UpdateExam(QAExam qAExam)
        {
            _context.QAExams.Update(qAExam);
            await _context.SaveChangesAsync();
        }

    }
}
