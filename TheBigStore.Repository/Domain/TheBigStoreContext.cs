using Microsoft.EntityFrameworkCore;

namespace TheBigStore.Repository.Domain
{
    public class TheBigStoreContext : DbContext
    {
        public TheBigStoreContext(DbContextOptions<TheBigStoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}
