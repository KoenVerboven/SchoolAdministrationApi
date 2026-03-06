using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Exam.QuestionAnswer;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ExamQuestionRepository : IExamQuestionAnwerRepository
    {
        private readonly AppDbContext _context;

        public ExamQuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExamQuestionAsync(ExamQuestionAnwer exam)
        {
            await _context.ExamQuestionAnwers.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return _context.ExamQuestionAnwers.Count();
        }

        public async Task DeleteExamQuestionAsync(int id)
        {
            var ExamInDb = await _context.ExamQuestionAnwers.FindAsync(id) ?? throw new KeyNotFoundException($"Exam with id {id} was not found.");
            _context.ExamQuestionAnwers.Remove(ExamInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamQuestionAnwer>> GetAllAsync()
        {
            return await _context.ExamQuestionAnwers.ToListAsync();
        }

        public async Task<ExamQuestionAnwer?> GetByIdAsync(int id)
        {
            return await _context.ExamQuestionAnwers.FindAsync(id);
        }
     
        public async Task UpdateExamQuestionAsync(ExamQuestionAnwer examExamQuestionAnswer)
        {
            _context.ExamQuestionAnwers.Update(examExamQuestionAnswer);
            await _context.SaveChangesAsync();
        }
    
        
    }
}
