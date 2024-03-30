using Microsoft.EntityFrameworkCore;

namespace TheBigStore.Repository.Domain
{
    public class TheBigStoreContext : DbContext
    {
        public TheBigStoreContext(DbContextOptions<TheBigStoreContext> options) : base(options)
        {
        }

    }
}
