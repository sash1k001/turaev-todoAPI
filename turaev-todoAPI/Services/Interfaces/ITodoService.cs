using turaev_todoAPI.Models;

namespace turaev_todoAPI.Services.Interfaces
{
    public interface ITodoService
    {
        Task<Todo> CreateTodoAsync(string title, int userId);
        Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId);
        Task<Todo?> GetTodoByIdAsync(int id);
        Task<Todo> UpdateTodoAsync(int id, string title, bool isCompleted);
        Task DeleteTodoAsync(int id);
    }
}