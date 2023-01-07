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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Sender)
                .WithMany(u => u.senderPackages)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Receiver)
                .WithMany(u => u.receiverPackages)
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>()
                .HasOne(p => p.receiverAddress)
                .WithMany(a => a.receiverPackages)
                .HasForeignKey(p => p.receiverAddressId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>()
                .HasOne(p => p.senderAddress)
                .WithMany(a => a.senderPackages)
                .HasForeignKey(p => p.senderAddressId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Package>()
                .HasOne(p => p.order)
                .WithOne(o => o.package)
                .HasForeignKey<Order>(o => o.packageId);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.courier)
                .WithMany(c => c.orders)
                .HasForeignKey(o => o.courierId);

            modelBuilder.Entity<Status>()
                .HasOne(s => s.StatusName)
                .WithMany(r => r.status)
                .HasForeignKey(s => s.idStatusName);
            modelBuilder.Entity<Status>()
                .HasOne(s => s.package)
                .WithMany(p => p.statuses)
                .HasForeignKey(s => s.idPackage);

            modelBuilder.Entity<User>()
                .HasOne(u=>u.defaultAddress)
                .WithOne(a=>a.user)
                .HasForeignKey<User>(u=>u.defaultAddressId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.loginCredentials)
                .WithOne(l => l.user)
                .HasForeignKey<User>(u => u.loginCredentialsId);

            modelBuilder.Entity<Region>()
                .HasOne(r => r.courier)
                .WithOne(c => c.region)
                .HasForeignKey<Region>(r => r.courierId);
            modelBuilder.Entity<RegionPins>()
                .HasOne(p => p.region)
                .WithMany(r => r.regionPins)
                .HasForeignKey(p => p.regionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<loginCredentials> LoginCredentials { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<statusNames> StatusNames { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<RegionPins> RegionPins { get; set; }

    }
}
