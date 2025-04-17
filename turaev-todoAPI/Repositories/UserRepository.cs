using Microsoft.EntityFrameworkCore;
using turaev_todoAPI.Data;
using turaev_todoAPI.Models;
using turaev_todoAPI.Repositories.Interfaces;

namespace turaev_todoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TuraevDbContext _context;

        public UserRepository(TuraevDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Login.ToLower() == login.ToLower());
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }
    }
}
