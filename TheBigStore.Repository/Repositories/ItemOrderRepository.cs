using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class ItemOrderRepository(TheBigStoreContext dbContext) : GenericRepository<ItemOrder>(dbContext), IItemOrderRepository
    {
    }
}
