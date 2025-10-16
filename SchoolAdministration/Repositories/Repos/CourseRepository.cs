using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;


namespace SchoolAdministration.Repositories.Repos
{
    public class CourseRepository : ICourseRepository
    {

        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.Courses.CountAsync();
        }

        public bool CourseExist(Course course)
        {
            return _context.Courses.Any(p=>p.CourseName.Trim().ToLower() == course.CourseName.Trim().ToLower());
        }

        public async Task DeleteCourseAsync(int id)
        {
            var courseInDb = await _context.Courses.FindAsync(id) ?? throw new KeyNotFoundException($"Course with id {id} was not found.");
            _context.Courses.Remove(courseInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetSearchAsync(CourseSearchParameters courseSearchParameters)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(courseSearchParameters.CourseName) && string.IsNullOrWhiteSpace(courseSearchParameters.CourseCode))
            {
                query = query.Where(p => p.CourseName.ToLower().Contains(courseSearchParameters.CourseName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(courseSearchParameters.CourseName) && !string.IsNullOrWhiteSpace(courseSearchParameters.CourseCode))
            {
                query = query.Where(p => p.CourseName.ToLower().Contains(courseSearchParameters.CourseName.ToLower())
                                         && p.CourseCode.ToLower().Contains(courseSearchParameters.CourseCode.ToLower()));//todo courseCode may be null
                          
            }

            return await query.ToListAsync();
        }

       

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
