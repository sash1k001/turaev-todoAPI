using turaev_todoAPI.Models;

namespace turaev_todoAPI.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId);
        Task<Todo?> GetTodoByIdAsync(int id);
        Task<Todo> UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}