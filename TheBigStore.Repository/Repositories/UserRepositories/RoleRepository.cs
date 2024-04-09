using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class RoleRepository(TheBigStoreContext dbContext) : GenericRepository<Role>(dbContext), IRoleRepository
    {
    }
}
