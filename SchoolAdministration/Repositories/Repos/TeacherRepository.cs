using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;         
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacherInDb = _context.Teachers.Find(id) ?? throw new KeyNotFoundException($"Teachter with id {id} was not found.");
            _context.Teachers.Remove(teacherInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsyn()
        {
            return await _context.Teachers.ToListAsync();   
        }

        public async Task<Teacher?> GetAsynById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
