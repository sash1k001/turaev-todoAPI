using turaev_todoAPI.Models;
using turaev_todoAPI.Models.Dtos;

namespace turaev_todoAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
