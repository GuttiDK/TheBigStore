using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public CategoryRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        new public async Task<List<Category>> GetAllAsync()
        {
            List<Category> temp = await _dbContext.Categories.AsNoTracking().Include(w => w.Items).ToListAsync();

            return temp;
        }

        new public async Task<Category> GetByIdAsync(int id)
        {
            var temp = await _dbContext.Categories.AsNoTracking().Include(w => w.Items).SingleOrDefaultAsync(w => w.Id == id);

            return temp;
        }
    }
}
