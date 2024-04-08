using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class OrderRepository(TheBigStoreContext dbContext) : GenericRepository<Order>(dbContext), IOrderRepository
    {
    }
}
