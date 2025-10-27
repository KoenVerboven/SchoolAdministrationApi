using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministration.Repositories.Repos
{
    public class MessageRepository : IMessageRepository
    {
        public Task AddMessageWorkAsync(Models.Domain.Message message)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Domain.Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Domain.Message?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessageAsync(Models.Domain.Message message)
        {
            throw new NotImplementedException();
        }
    }
}
