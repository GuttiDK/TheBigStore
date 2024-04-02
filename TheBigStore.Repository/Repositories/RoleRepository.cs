using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class RoleRepository(TheBigStoreContext dbContext) : GenericRepository<Role>(dbContext), IRoleRepository
    {
    }
}
