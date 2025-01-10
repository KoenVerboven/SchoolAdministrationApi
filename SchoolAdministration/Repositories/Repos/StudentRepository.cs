using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studentInDb = await _context.Students.FindAsync(id) ?? throw new KeyNotFoundException($"Student with id {id} was not found.");
            _context.Students.Remove(studentInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetByNameStartWithAsync(string name)
        {
            return await _context.Students.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(name.ToLower())).ToListAsync();
        }

        public bool StudentExist(Student student)
        {
            var studentFind = _context.Students.FirstOrDefault(p => p.LastName.Trim().ToLower().Equals(student.LastName.Trim().ToLower()) 
                                                                   && p.FirstName.Trim().ToLower().Equals(student.FirstName.Trim().ToLower())
                                                                   && p.DateOfBirth.Equals(student.DateOfBirth)
                                                                   );
            if(studentFind == null)
            {
                return false;
            }
            return true;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
