using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using turaev_todoAPI.Models.Dtos;
using turaev_todoAPI.Services.Interfaces;

namespace turaev_todoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTodos()
        {
            var userId = GetUserId();
            var todos = await _todoService.GetTodosByUserIdAsync(userId);
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] string title)
        {
            var userId = GetUserId();
            var todo = await _todoService.CreateTodoAsync(title, userId);
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoDto dto)
        {
            var userId = GetUserId();
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo == null || todo.UserId != userId)
                return Forbid();

            var updated = await _todoService.UpdateTodoAsync(id, dto.Title, dto.IsCompleted);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var userId = GetUserId();
            var todo = await _todoService.GetTodoByIdAsync(id);

            if (todo == null || todo.UserId != userId)
                return Forbid();

            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

    }
}
