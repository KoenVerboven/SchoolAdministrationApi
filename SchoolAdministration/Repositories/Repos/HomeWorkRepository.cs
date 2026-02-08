using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class HomeWorkRepository : IHomeWorkRepository
    {
        public Task AddHomeWorkAsync(HomeWork homeWork)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteHomeWorkAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HomeWork>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HomeWork?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHomeWorkAsync(HomeWork homeWork)
        {
            throw new NotImplementedException();
        }
    }
}
