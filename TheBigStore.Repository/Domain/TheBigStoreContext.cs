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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> OrderItems { get; set; }
        public DbSet<Category> Category { get; set; }

        // how to add a new migration in PMC
        // Add-Migration InitialCreate
        // Update-Database

        public TheBigStoreContext(DbContextOptions<TheBigStoreContext> options) : base(options)
        {
        }

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
            // Customer setup - One to One
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserId);
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(c => c.AddressId);
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            // Role setup - One to Many
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            // Address setup - One to One
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Customer)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(a => a.CustomerId);

            // User setup - One to One
            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.Id);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

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

            // Order setup - One to Many
            modelBuilder.Entity<Order>()
                .HasMany(o => o.ItemOrders)
                .WithOne(io => io.Order)
                .HasForeignKey(io => io.OrderId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Item setup - One to Many
            modelBuilder.Entity<Item>()
                .HasMany(i => i.ItemOrders)
                .WithOne(io => io.Item)
                .HasForeignKey(io => io.ItemId);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            // Category setup - One to Many
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

        }

    }
}
