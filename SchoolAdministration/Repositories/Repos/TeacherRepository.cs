using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.Domain.Teacher;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Specifications;

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

        public Task<int> CountAsync()
        {
            return _context.Teachers.CountAsync();
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

        //todo : is obsolete ? use GetTeachersByTeachersSearchParamsFilterAsync instead
        public async Task<IEnumerable<Teacher>> GetFilterAsyn(string sort, int pageSize, int pageNumber)
        {
            IQueryable<Teacher>? teachers;

            teachers = sort.ToLower() switch
            {
                "name" =>  _context.Teachers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
                "email" =>  _context.Teachers.OrderBy(p => p.Email).AsQueryable(),
                "phone" =>  _context.Teachers.OrderBy(p => p.Phone).AsQueryable(),
                "dateofbirth" => _context.Teachers.OrderBy(p => p.DateOfBirth).AsQueryable(),
                _ =>  _context.Teachers.OrderBy(p => p.Id).AsQueryable(),
            };

            if (pageSize > 0)
            {
                if (pageSize > 30)
                {
                    pageSize = 30;
                }
                teachers = teachers.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }

            return await teachers.ToListAsync(); 
        }

        public async Task<IEnumerable<Teacher>> GetAllAsynSort(string sort)
        {
            List<Teacher>? teachers = sort.ToLower() switch
            {
                "id" => await _context.Teachers.OrderBy(p => p.Id).ToListAsync(),
                "id_desc" => await _context.Teachers.OrderByDescending(p => p.Id).ToListAsync(),
                "name" => await _context.Teachers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToListAsync(),
                "name_desc" => await _context.Teachers.OrderByDescending(p => p.LastName).ThenBy(p => p.FirstName).ToListAsync(),
                "email" => await _context.Teachers.OrderBy(p => p.Email).ToListAsync(),
                "email_desc" => await _context.Teachers.OrderByDescending(p => p.Email).ToListAsync(),
                "phone" => await _context.Teachers.OrderBy(p => p.Phone).ToListAsync(),
                "phone_desc" => await _context.Teachers.OrderByDescending(p => p.Phone).ToListAsync(),
                "dateofbirth" => await _context.Teachers.OrderBy(p => p.DateOfBirth).ToListAsync(),
                "dateofbirth_desc" => await _context.Teachers.OrderByDescending(p => p.DateOfBirth).ToListAsync(),
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

        public async Task<IEnumerable<Teacher>> GetTeachersByTeachersSearchParamsFilterAsync(TeacherSearchParams teacherSearchParams)
        {
            int pageSize = teacherSearchParams.PageSize;
            IQueryable<Teacher> teachers;

            teachers = _context.Teachers;

            if (teacherSearchParams.Name is not null)
            {
                if (teacherSearchParams.Name.Trim() != string.Empty)
                {
                    teachers = teachers.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(teacherSearchParams.Name.ToLower())).AsQueryable();
                }
            }

            if (teacherSearchParams.Email is not null)
            {
                if (teacherSearchParams.Email.Trim() != string.Empty)
                {
                    teachers = teachers.Where(p => p.Email.ToLower().Contains(teacherSearchParams.Email.ToLower())).AsQueryable();
                }
            }

            if (teacherSearchParams.DateOfBirth is not null)
            {
                var dob = teacherSearchParams.DateOfBirth.Value;

                var start = new DateTime(dob.Year, dob.Month, dob.Day);
                var end = start.AddDays(1);
                teachers = teachers.Where(p => p.DateOfBirth >= start && p.DateOfBirth < end).AsQueryable();
            }

            teachers = teacherSearchParams.Sort.ToLower() switch
            {
                "id" => teachers.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => teachers.OrderByDescending(p => p.Id).AsQueryable(),
                "name" => teachers.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
                "name_desc" => teachers.OrderByDescending(p => p.LastName).ThenBy(p => p.FirstName).AsQueryable(),
                "email" => teachers.OrderBy(p => p.Email).AsQueryable(),
                "email_desc" => teachers.OrderByDescending(p => p.Email).AsQueryable(),
                "phone" => teachers.OrderBy(p => p.Phone).AsQueryable(),
                "phone_desc" => teachers.OrderByDescending(p => p.Phone).AsQueryable(),
                "dateofbirth" => teachers.OrderBy(p => p.DateOfBirth).AsQueryable(),
                "dateofbirth_desc" => teachers.OrderByDescending(p => p.DateOfBirth).AsQueryable(),
                "gender" => teachers.OrderBy(p => p.Gender).AsQueryable(),
                "gender_desc" => teachers.OrderByDescending(p => p.Gender).AsQueryable(),
                _ => teachers.OrderBy(p => p.Id).AsQueryable(),
            };

            if (teacherSearchParams.PageSize > 0)
            {
                if (teacherSearchParams.PageSize > 30)
                {
                    pageSize = 30;
                }

                teachers = teachers.Skip(pageSize * (teacherSearchParams.PageNumber - 1)).Take(pageSize);
            }

            return await teachers.ToListAsync();
        }
    }
}
