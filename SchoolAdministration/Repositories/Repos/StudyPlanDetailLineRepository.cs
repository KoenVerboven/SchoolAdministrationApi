using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudyPlanDetailLineRepository : IStudyPlanDetailLineRepository
    {
        private readonly AppDbContext _context;

        public StudyPlanDetailLineRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddStudyPlanDetailLineAsync(StudyPlanDetailLine studyPlanDetailLine)
        {
            await _context.StudyPlanDetailLines.AddAsync(studyPlanDetailLine);
            await _context.SaveChangesAsync(); ;
        }

        public async Task DeleteStudyPlanDetailLineAsync(int id)
        {
            var studyPlanDetailLineInDb = await _context.StudyPlanDetailLines.FindAsync(id) ?? throw new KeyNotFoundException($"StudyPlanDetailLine with id {id} was not found.");
            _context.StudyPlanDetailLines.Remove(studyPlanDetailLineInDb);
            await _context.SaveChangesAsync();
        }

        public Task DeleteStudyPlandetailLineAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudyPlanDetailLine>> GetAllAsync()
        {
            return await _context.StudyPlanDetailLines.ToListAsync();
        }

        public async Task<StudyPlanDetailLine?> GetByIdAsync(int id)
        {
            return await _context.StudyPlanDetailLines.FindAsync(id);
        }

        public async Task<IEnumerable<StudyPlanDetailLine>> GetStudyPlanDetailLinesFilterAsync(DateTime start)
        {
            var startDayMinus_1 = start.AddDays(-1);
            var startDayPlus_1 = start.AddDays(+1);
            return await _context.StudyPlanDetailLines.Where(p => p.StartLearning > startDayMinus_1 && p.StartLearning < startDayPlus_1).ToListAsync();
        }

        public async Task UpdateStudyPlanDetailLineAsync(StudyPlanDetailLine studyPlanDetailLine)
        {
            _context.StudyPlanDetailLines.Update(studyPlanDetailLine);
            await _context.SaveChangesAsync();
        }
    }
}
