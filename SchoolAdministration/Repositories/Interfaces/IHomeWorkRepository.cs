using SchoolAdministration.Models.Domain.Student;


namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IHomeWorkRepository
    {
        Task<IEnumerable<HomeWork>> GetAllAsync();
        Task<HomeWork?> GetByIdAsync(int id);
        Task AddHomeWorkAsync(HomeWork homeWork);
        Task UpdateHomeWorkAsync(HomeWork homeWork);
        Task DeleteHomeWorkAsync(int id);
        Task<int> CountAsync();
    }
}
