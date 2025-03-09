using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;
using System.Collections.Generic;

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

        public async Task<IEnumerable<Teacher>> GetAllAsynSort(string sort)
        {
            List<Teacher>? teachers = sort.ToLower() switch
            {
                "name" => await _context.Teachers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToListAsync(),
                "email" => await _context.Teachers.OrderBy(p => p.Email).ToListAsync(),
                "phone" => await _context.Teachers.OrderBy(p => p.Phone).ToListAsync(),
                _ => await _context.Teachers.OrderBy(p => p.Id).ToListAsync(),
            };
            return teachers;
        }

        public async Task<Teacher?> GetAsynById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public bool TeacherExist(Teacher teacher)
        {
            return _context.Students.Any(p => p.LastName.Trim().ToLower().Equals(teacher.LastName.Trim().ToLower())
                                                                   && p.FirstName.Trim().ToLower().Equals(teacher.FirstName.Trim().ToLower())
                                                                   && p.DateOfBirth.Equals(teacher.DateOfBirth)
                                                                   );
        }


        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
