using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;


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

        public async Task<IEnumerable<Course>> GetCoursesByFilterAsync(CourseSearchParams courseSearchParameters)
        {
            var pageSize = courseSearchParameters.PageSize ;
            IQueryable<Course> courses;

            courses = _context.Courses;

            if (!string.IsNullOrWhiteSpace(courseSearchParameters.CourseName))
            {
                courses = courses.Where(p => p.CourseName.ToLower().Contains(courseSearchParameters.CourseName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(courseSearchParameters.CourseCode))
            {
                courses = courses.Where(p => p.CourseName.ToLower().Contains(courseSearchParameters.CourseCode.ToLower()));
            }

            courses = courseSearchParameters.Sort.ToLower() switch
            {
                "id" => courses.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => courses.OrderByDescending(p => p.Id).AsQueryable(),
                "name" => courses.OrderBy(p => p.CourseName).AsQueryable(),
                "name_desc" => courses.OrderByDescending(p => p.CourseName).AsQueryable(),
                "courseCode" => courses.OrderBy(p => p.CourseCode).AsQueryable(),
                "courseCode_desc" => courses.OrderByDescending(p => p.CourseCode).AsQueryable(),
                _ => courses.OrderBy(p => p.Id).AsQueryable(),
            };

            if (courseSearchParameters.PageSize > 0 && courseSearchParameters.PageNumber > 0) //todo : kan korter
            {
                if (courseSearchParameters.PageSize > 30)
                {
                    pageSize = 30;
                }

                courses = courses.Skip(courseSearchParameters.PageSize * (courseSearchParameters.PageNumber - 1)).Take(pageSize);
            }

            return await courses.ToListAsync();
        }
    
        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
