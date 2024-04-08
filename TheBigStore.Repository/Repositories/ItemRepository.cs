using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class ItemRepository(TheBigStoreContext dbContext) : GenericRepository<Item>(dbContext), IItemRepository
    {
    }
}
