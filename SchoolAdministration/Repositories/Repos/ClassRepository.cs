using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context  )
        {
            _context = context;
        }

        public async Task AddClassAsync(SchoolClass schoolClass)
        {
            await _context.SchoolClasses.AddAsync( schoolClass );
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.SchoolClasses.CountAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var classInDb = await _context.SchoolClasses.FindAsync(id) ?? throw new KeyNotFoundException($"Class with id {id} was not found.");
            _context.SchoolClasses.Remove(classInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SchoolClass>> GetAllAsync()
        {
            return await _context.SchoolClasses.ToListAsync();
        }

        public async Task<SchoolClass?> GetByIdAsync(int id)
        {
            return await _context.SchoolClasses.FindAsync(id);
        }

        public async Task<IEnumerable<SchoolClass>> GetClassesBySchoolIdAsync(int schoolId)
        {
            return await _context.SchoolClasses.Where(p =>p.SchoolId == schoolId).ToListAsync();
        }

        public async Task UpdateClassAsync(SchoolClass schoolClass)
        {
            _context.SchoolClasses.Update(schoolClass);
            await _context.SaveChangesAsync();
        }
    }
}
