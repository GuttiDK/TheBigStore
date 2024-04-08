using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public UserRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Check for user by username and password has to be safe
        public async Task<bool> CheckUserAsync(string username, string password)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user != null;
        }

        // Check for if user is roleid 1 (admin)
        public async Task<bool> CheckAdminAsync(int userId)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId && u.RoleId == 1);
            return user != null;
        }
    }
}
