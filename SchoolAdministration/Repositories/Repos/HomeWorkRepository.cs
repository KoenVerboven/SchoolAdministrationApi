using Microsoft.EntityFrameworkCore;
using SchoolAdministration.Data;
using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos           
{
    public class HomeWorkRepository(AppDbContext context) : IHomeWorkRepository
    {
        private readonly AppDbContext _context = context;
        const int MaxPageSize = 30;


        public async Task AddHomeWorkAsync(HomeWork homeWork)
        {
            await _context.HomeWorks.AddAsync(homeWork);
            await _context.SaveChangesAsync();          
        }

        public Task<int> CountAsync()
        {
            return _context.HomeWorks.CountAsync();
        }

        public async Task DeleteHomeWorkAsync(int id)
        {
            var homeWorkInDb = await _context.HomeWorks.FindAsync(id) ?? throw new KeyNotFoundException($"HomeWork with id {id} was not found.");
            _context.HomeWorks.Remove(homeWorkInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HomeWork>> GetAllAsync()
        {
            return await _context.HomeWorks
                           .AsNoTracking()
                           .ToListAsync();
        }       

        public async Task<HomeWork?> GetByIdAsync(int id)
        {
            return await _context.HomeWorks
                           .AsNoTracking()
                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateHomeWorkAsync(HomeWork homeWork)
        {
            _context.HomeWorks.Update(homeWork);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateIsActive(int id, bool isActive)
        {

            int rowsAffected = await _context.HomeWorks
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.IsActive, isActive));

        }
    }
}
