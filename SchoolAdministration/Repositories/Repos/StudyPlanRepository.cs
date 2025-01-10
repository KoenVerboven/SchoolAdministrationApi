using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudyPlanRepository : IStudyPlanRepository
    {
        private readonly AppDbContext _context;

        public StudyPlanRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddStudyPlanAsync(StudyPlan studyPlan)
        {
            await _context.StudyPlans.AddAsync(studyPlan);
            await _context.SaveChangesAsync(); ;
        }

        public async Task DeleteStudyPlanAsync(int id)
        {
            var studyPlanInDb = await _context.StudyPlans.FindAsync(id) ?? throw new KeyNotFoundException($"StudyPlan with id {id} was not found.");
            _context.StudyPlans.Remove(studyPlanInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudyPlan>> GetAllAsync()
        {
            return await _context.StudyPlans.ToListAsync();
        }

        public async Task<StudyPlan?> GetByIdAsync(int id)
        {
            return await _context.StudyPlans.FindAsync(id);
        }

        public async Task UpdateStudyPlanAsync(StudyPlan studyPlan)
        {
            _context.StudyPlans.Update(studyPlan);
            await _context.SaveChangesAsync();
        }
    }
}
