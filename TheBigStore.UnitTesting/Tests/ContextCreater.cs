using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TheBigStore.Repository.Domain;

namespace TheBigStore.UnitTesting.Tests
{
    public class ContextCreater
    {
        public static TheBigStoreContext CreateContext([CallerMemberName] string dbname = "")
        {
            DbContextOptionsBuilder builder = new();
            builder.UseInMemoryDatabase(dbname);
            builder.EnableSensitiveDataLogging();
            var context = new TheBigStoreContext(builder.Options);
            return context;
        }
    }
}
