using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;

namespace TheBigStore.Repository
{
    public class Program
    {
        public static void Main()
        {
            DbContextOptions<TheBigStoreContext> dbContext = new DbContextOptions<TheBigStoreContext>();
            TheBigStoreContext context = new TheBigStoreContext(dbContext);
            Console.WriteLine("Hello World!");
        }
    }
}
