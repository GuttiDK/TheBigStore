using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TheBigStore.Repository.Enums;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Domain
{
    public class TheBigStoreContext : DbContext
    {
        public TheBigStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        // how to add a new migration in PMC
        // Add-Migration InitialCreate
        // Update-Database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=dESktoP-V8\\SQLEXPRESS; Database=TheBigStoreApp; Trusted_Connection=True; TrustServerCertificate=True;");
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(new ServiceCollection()
                              .AddLogging(builder => builder.AddConsole()
                                                            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                               .BuildServiceProvider().GetService<ILoggerFactory>());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ItemOrder setup - Many to Many
            modelBuilder.Entity<ItemOrder>()
                .HasKey(io => new { io.ItemId, io.OrderId });
            modelBuilder.Entity<ItemOrder>()
                .HasOne(io => io.Item)
                .WithMany(i => i.ItemOrders)
                .HasForeignKey(io => io.ItemId);
            modelBuilder.Entity<ItemOrder>()
                .HasOne(io => io.Order)
                .WithMany(o => o.ItemOrders)
                .HasForeignKey(io => io.OrderId);

            // Hard code roles Admin and User
            modelBuilder.Entity<Role>().HasData(
                               new Role { Id = 1, RoleName = "Admin", IsAdmin = true },
                                              new Role { Id = 2, RoleName = "User", IsAdmin = false }
                                                         );
        }

    }
}
