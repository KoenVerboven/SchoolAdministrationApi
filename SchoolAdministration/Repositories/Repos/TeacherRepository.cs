using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class TeacherRepository : ITeacherRepository
    {
        public Task AddTeacherAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAllAsyn()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher?> GetAsynById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
