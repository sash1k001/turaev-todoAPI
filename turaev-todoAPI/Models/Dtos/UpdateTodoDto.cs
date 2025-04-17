namespace turaev_todoAPI.Models.Dtos
{
    public class UpdateTodoDto
    {
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
