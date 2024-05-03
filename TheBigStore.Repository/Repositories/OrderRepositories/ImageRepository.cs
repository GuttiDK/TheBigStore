using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public ImageRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Image>> GetAllImagesByItemId(int itemId)
        {
            return await _dbContext.Images.AsNoTracking().Include(x => x.Item).Where(x => x.Item.Id == itemId).ToListAsync();
        }
    }
}
