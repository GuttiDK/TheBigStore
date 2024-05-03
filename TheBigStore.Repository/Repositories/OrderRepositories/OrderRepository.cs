using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly TheBigStoreContext _dbContext;

        public OrderRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        new public async Task<List<Order>> GetAllAsync()
        {
            var temp = await _dbContext.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.ItemOrders)
                .ThenInclude(x => x.Item)
                .ToListAsync();

            return temp;
        }

        new public async Task<Order> GetByIdAsync(int id)
        {
            var temp = await _dbContext.Orders.AsNoTracking()
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .Include(x => x.ItemOrders)
                .ThenInclude(x => x.Item)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return temp;
        }
    }
}
