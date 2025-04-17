using Microsoft.EntityFrameworkCore;
using turaev_todoAPI.Data;
using turaev_todoAPI.Models;
using turaev_todoAPI.Repositories.Interfaces;

namespace turaev_todoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TuraevDbContext _context;

        public TodoRepository(TuraevDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAsync(int userId)
        {
            return await _context.Todos
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<Todo?> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Todo> UpdateTodoAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await GetTodoByIdAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}