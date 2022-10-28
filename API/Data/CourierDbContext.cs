using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class CourierDbContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public CourierDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        }
        public DbSet<User> AppUsers { get; set; }
    }

    
}
