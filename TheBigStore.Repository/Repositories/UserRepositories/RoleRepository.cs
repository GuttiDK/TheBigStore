using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class RoleRepository(TheBigStoreContext context) : GenericRepository<Role>(context), IRoleRepository
    {
        #region Backing fields
        private readonly TheBigStoreContext _dbContext = context;

        #endregion

        new public async Task<List<Role>> GetAllAsync()
        {
            List<Role> temp = await _dbContext.Roles.AsNoTracking().Include(r => r.Users).ToListAsync();

            return temp;
        }

        new public async Task<Role> GetByIdAsync(int id)
        {
            Role entity = await _dbContext.Roles.AsNoTracking().Include(r => r.Users).SingleOrDefaultAsync(r => r.Id == id);
            return entity;
        }

    }
}
