using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Wedding> Weddings { get; set; }

        public DbSet<GuestConnection> GuestConnections { get; set; }
    }
}