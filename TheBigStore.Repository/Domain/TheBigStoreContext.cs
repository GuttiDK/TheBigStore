using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Domain
{
    public class TheBigStoreContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


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
            base.OnModelCreating(modelBuilder);
        }

    }
}
