using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class CourierDbContext : DbContext
    {
        public CourierDbContext(DbContextOptions<CourierDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=admin;Password=admin");

        public DbSet<User> AppUsers { get; set; }
    }

    
}
