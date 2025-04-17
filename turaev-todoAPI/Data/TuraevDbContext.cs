using Microsoft.EntityFrameworkCore;
using turaev_todoAPI.Models;

namespace turaev_todoAPI.Data
{
    public class TuraevDbContext : DbContext
    {
        public TuraevDbContext(DbContextOptions<TuraevDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=turaevdb.db");
            }
        }

    }
}
