using turaev_todoAPI.Models;

namespace turaev_todoAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByLoginAsync(string login);
        Task<User> CreateAsync(User user);
    }
}
