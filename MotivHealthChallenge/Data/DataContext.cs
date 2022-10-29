using Microsoft.EntityFrameworkCore;

namespace MotivHealthChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<User> Users { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
    }
}
