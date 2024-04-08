using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class ProductRepository(TheBigStoreContext dbContext) : GenericRepository<Item>(dbContext), IProductRepository
    {
    }
}
