using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;

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

        public async Task<IEnumerable<ExamResult>> GetExamResultsByFilterAsync(ExamenResultSearchParams examResultSearchParameters)
        {
            var pageSize = examResultSearchParameters.PageSize;
            IQueryable<ExamResult> examResults;

            examResults = _context.ExamResults;

            if (!string.IsNullOrWhiteSpace(examResultSearchParameters.StudentId.ToString()) && string.IsNullOrWhiteSpace(examResultSearchParameters.CourseId.ToString()))
            {
               examResults = examResults.Where(p => p.StudentId == examResultSearchParameters.StudentId);
            }

            if (!string.IsNullOrWhiteSpace(examResultSearchParameters.CourseId.ToString()) && string.IsNullOrWhiteSpace(examResultSearchParameters.CourseId.ToString()))
            {
                examResults = examResults.Where(p => p.CourseId == examResultSearchParameters.CourseId);
            }

            if (!string.IsNullOrWhiteSpace(examResultSearchParameters.ExamId.ToString()) && string.IsNullOrWhiteSpace(examResultSearchParameters.ExamId.ToString()))
            {
                examResults = examResults.Where(p => p.QAExamId == examResultSearchParameters.ExamId);
            }

            if (!string.IsNullOrWhiteSpace(examResultSearchParameters.TeacherId.ToString()) && string.IsNullOrWhiteSpace(examResultSearchParameters.TeacherId.ToString()))
            {
                examResults = examResults.Where(p => p.CheckedByTeacherId == examResultSearchParameters.TeacherId);
            }


            examResults = examResultSearchParameters.Sort.ToLower() switch
            {
                "id" => examResults.OrderBy(p => p.Id).AsQueryable(),       
                "id_desc" => examResults.OrderByDescending(p => p.Id).AsQueryable(),
                "studentId" => examResults.OrderBy(p => p.StudentId).AsQueryable(),
                "studentId_desc" => examResults.OrderByDescending(p => p.StudentId).AsQueryable(),
                "courseId" => examResults.OrderBy(p => p.CourseId).AsQueryable(),
                "courseId_desc" => examResults.OrderByDescending(p => p.CourseId).AsQueryable(),
                "examId" => examResults.OrderBy(p => p.QAExamId).AsQueryable(),
                "examId_desc" => examResults.OrderByDescending(p => p.QAExamId).AsQueryable(),

                _ => examResults.OrderBy(p => p.Id).AsQueryable(),
            };

            if (examResultSearchParameters.PageSize > 0 && examResultSearchParameters.PageNumber > 0) //todo : kan korter
            {
                if (examResultSearchParameters.PageSize > 30)
                {
                    pageSize = 30;
                }

                examResults = examResults.Skip(examResultSearchParameters.PageSize * (examResultSearchParameters.PageNumber - 1)).Take(pageSize);
            }

            return await examResults.ToListAsync();
        }       

        public async Task UpdateExamResultAsync(ExamResult examResult)
        {
            _context.ExamResults.Update(examResult);
            await _context.SaveChangesAsync();
        }
    }
}
