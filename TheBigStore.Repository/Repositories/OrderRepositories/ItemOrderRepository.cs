using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class ItemOrderRepository : GenericRepository<ItemOrder>, IItemOrderRepository
    {
        private readonly TheBigStoreContext _dbContext;

        public ItemOrderRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemOrder>> GetAllByOrderId(int orderId) => await _dbContext.OrderItems
        .AsNoTracking()
        .Include(io => io.Item)
        .ThenInclude(io => io.Image)
        .Where(io => io.OrderId == orderId)
        .ToListAsync();

    }
}

