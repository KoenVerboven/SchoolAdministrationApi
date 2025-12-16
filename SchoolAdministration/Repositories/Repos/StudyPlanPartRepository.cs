using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudyPlanPartRepository : IStudyPlanPartRepository
    {
        private readonly AppDbContext _context;

        public StudyPlanPartRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddStudyPlanPartAsync(StudyPlanPart studyPlanPart)
        {
            await _context.StudyPlanParts.AddAsync(studyPlanPart);
            await _context.SaveChangesAsync(); ;
        }

        public async Task DeleteStudyPlanPartAsync(int id)
        {
            var studyPlanPartInDb = await _context.StudyPlanParts.FindAsync(id) ?? throw new KeyNotFoundException($"StudyPlanPart with id {id} was not found.");
            _context.StudyPlanParts.Remove(studyPlanPartInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudyPlanPart>> GetAllAsync()
        {
            return await _context.StudyPlanParts.ToListAsync();
        }

        public async Task<StudyPlanPart?> GetByIdAsync(int id)
        {
            return await _context.StudyPlanParts.FindAsync(id);
        }

        public async Task<IEnumerable<StudyPlanPart>> GetStudyPlanPartFilterAsync(DateTime start)
        {
            var startDayMinus_1 = start.AddDays(-1);
            var startDayPlus_1 = start.AddDays(+1);
            return await _context.StudyPlanParts.Where(p => p.Start > startDayMinus_1 && p.Start < startDayPlus_1).ToListAsync();
        }

        public async Task UpdateStudyPlanPartAsync(StudyPlanPart studyPlanPart)
        {
            _context.StudyPlanParts.Update(studyPlanPart);
            await _context.SaveChangesAsync();
        }
    }
}
