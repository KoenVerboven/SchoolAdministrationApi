using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Models.Domain;

namespace SchoolAdministration.Repositories.Repos
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context) 
        {
            _context = context;
        }

        public AppDbContext Context { get; }

        public async Task AddDepartmentAsync(SchoolDepartment schoolDepartment)
        {
            await _context.SchoolDepartments.AddAsync(schoolDepartment);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            return _context.SchoolDepartments.CountAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var departmentInDb = await _context.SchoolDepartments.FindAsync(id) ?? throw new KeyNotFoundException($"Department with id {id} was not found.");
            _context.SchoolDepartments.Remove(departmentInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SchoolDepartment>> GetAllAsync()
        {
            return await _context.SchoolDepartments.ToListAsync();
        }

        public async Task<SchoolDepartment?> GetByIdAsync(int id)
        {
            return await _context.SchoolDepartments.FindAsync(id);
        }

        public async Task<IEnumerable<SchoolDepartment>> GetDepartmentBySchoolIdAsync(int schoolId)
        {
            return await _context.SchoolDepartments
                .Where(department => department.SchoolId == schoolId)
                .ToListAsync();
        }

        public async Task UpdateDepartmentAsync(SchoolDepartment schoolDepartment)
        {
            _context.SchoolDepartments.Update(schoolDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
