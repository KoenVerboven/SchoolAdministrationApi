using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudentPresenceRepository(AppDbContext context) : IStudentPresenceRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddStudentPresenceAsync(StudentPresence student)
        {
            await _context.StudentsPresence.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentsPresenceAsync(IEnumerable<StudentPresence> studentsPresence)
        {
            _context.StudentsPresence.AddRange(studentsPresence);
            await _context.SaveChangesAsync();
        }

        public Task DeleteStudentPresenceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentPresence>> GetAllAsync()
        {
            return await _context.StudentsPresence.ToListAsync();
        }

        public async Task<StudentPresence?> GetByIdAsync(int id)
        {
            return await _context.StudentsPresence.FindAsync(id);
        }

        public Task UpdateStudentPresenceAsync(StudentPresence student)
        {
            throw new NotImplementedException();
        }
    }
}
