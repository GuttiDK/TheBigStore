using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class CategoryRepository(TheBigStoreContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
    {
    }
}
