using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBigStore.Repository.Domain;

namespace TheBigStore.UnitTesting.UnitTestConfig
{

    public class UnitTheBigStoreContext
    {
        public static TheBigStoreContext Create()
        {
            return new TheBigStoreContext();
        }

        public static void RecreateDatabase()
        {
            using var context = Create();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
