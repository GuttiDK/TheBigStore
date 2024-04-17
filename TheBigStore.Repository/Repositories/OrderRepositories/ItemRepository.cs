using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public ItemRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> SearchProductByWord(string word)
        {
            return await _dbContext.Products.AsNoTracking().Where(x => x.ItemName.Contains(word)).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

    }
}
