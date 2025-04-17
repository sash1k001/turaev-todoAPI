using turaev_todoAPI.Models;
using turaev_todoAPI.Repositories.Interfaces;
using turaev_todoAPI.Services.Interfaces;

namespace turaev_todoAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> CreateTodoAsync(string title, int userId)
        {
            var todo = new Todo
            {
                Title = title,
                UserId = userId
            };

            return await _todoRepository.CreateTodoAsync(todo);
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId)
        {
            return await _todoRepository.GetTodosByUserIdAsync(userId);
        }

        public async Task<Todo?> GetTodoByIdAsync(int userId)
        {
            return await _todoRepository.GetTodoByIdAsync(userId);
        }

        public async Task<Todo> UpdateTodoAsync(int id, string? title, bool isCompleted)
        {
            var todo = await _todoRepository.GetTodoByIdAsync(id);

            if (todo == null)
                throw new Exception("задача не найдена.");

            if (title != null)
                todo.Title = title;

            todo.IsCompleted = isCompleted;

            return await _todoRepository.UpdateTodoAsync(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}