using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class CategoryRepository(TheBigStoreContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
    {
    }
}
