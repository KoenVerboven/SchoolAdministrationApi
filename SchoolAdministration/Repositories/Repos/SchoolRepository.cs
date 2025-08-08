using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppDbContext _context;

        public SchoolRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddSchoolAsync(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.Schools.CountAsync();
        }

        public async Task DeleteSchoolAsync(int id)
        {
            var schoolInDb = await _context.Schools.FindAsync(id) ?? throw new KeyNotFoundException($"School with id {id} was not found.");
            _context.Schools.Remove(schoolInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<School>> GetAllAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public Task<School?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SchoolExist(SchoolCreateDTO school)
        {
            return _context.Schools.Any(p=>p.Name.Trim().ToLower().Equals(school.Name.TrimEnd().ToLower()));
        }

        public async Task UpdateSchoolAsync(School school)
        {
            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
        }
    }
}
