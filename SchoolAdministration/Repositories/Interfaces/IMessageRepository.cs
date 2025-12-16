using SchoolAdministration.Models.Domain.General;

namespace SchoolAdministration.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int id);
        Task AddMessageWorkAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(int id);
        Task<int> CountAsync();
    }
}
