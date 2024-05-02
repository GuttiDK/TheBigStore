using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Models.Paging;
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

        new public async Task<List<Item>> GetAllAsync()
        {
            return await _dbContext.Products.AsNoTracking()
                .Include(i => i.Image)
                .ToListAsync();
        }

        new public async Task<Item> GetByIdAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking()
                .Include(i => i.Category)
                .Include(i => i.Image)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Item>> SearchProductByWord(string word)
        {
            return await _dbContext.Products.AsNoTracking().Where(x => x.ItemName.Contains(word)).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Page<Item>> GetItemsbyCategory(int categoryId, PageOptions options)
        {
            var query = _dbContext.Products.AsNoTracking()
                .Include(s => s.Category)
                .Where(s => s.CategoryId == categoryId);

            Page<Item> pageResult = new()
            {
                Total = query.Count(),
                Items = await query.Page(options.CurrentPage, options.PageSize).ToListAsync(),
                CurrentPage = options.CurrentPage,
                PageSize = options.PageSize
            };
            return pageResult;
        }

        // Check stock of an item with amount and id and returns bool
        public async Task<bool> CheckStock(int id, int amount)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (item.Stock >= amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Update stock of an item with amount and id and return the item
        public async Task<Item> UpdateStock(int id, int amount)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (item != null)
            {
                item.Stock -= amount;
                await _dbContext.SaveChangesAsync();
                return item;
            }
            return new Item();
        }

    }
}
