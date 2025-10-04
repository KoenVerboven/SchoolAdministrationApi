using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class ParentRepository : IParentRepository
    {
        private readonly AppDbContext _context;

        public ParentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddParentAsync(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.Teachers.CountAsync();
        }

        public async Task DeleteParentAsync(int id)
        {
            var parentInDb = _context.Parents.Find(id) ?? throw new KeyNotFoundException($"Parent with id {id} was not found.");
            _context.Parents.Remove(parentInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Parent>> FindByStudentIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents.FindAsync(id);
        }

        public bool ParentExist(Parent parent)
        {
            return _context.Parents.Any(p => p.LastName.Trim().ToLower().Equals(parent.LastName.Trim().ToLower())
                                                                   && p.FirstName.Trim().ToLower().Equals(parent.FirstName.Trim().ToLower())
                                                                   && p.DateOfBirth.Equals(parent.DateOfBirth)
                                                                   );
        }

        public async Task UpdateParentAsync(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
        }
    }
}
