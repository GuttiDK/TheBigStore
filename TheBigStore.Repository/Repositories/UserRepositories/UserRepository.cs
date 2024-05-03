using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public UserRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        new public async Task<User> GetByIdAsync(int id)
        {
            User temp = await _dbContext.Users.AsNoTracking()
                .Include(r => r.Role)
                .Include(r => r.Customer)
                .ThenInclude(r => r.Address)
                .FirstOrDefaultAsync(x => x.Id == id);

            return temp;
        }

        new public async Task<List<User>> GetAllAsync()
        {
            List<User> temp = await _dbContext.Users.AsNoTracking().Include(r => r.Role).ToListAsync();

            return temp;
        }

        // Check for user by username to see if it already exists or is correct
        public async Task<bool> CheckUserAsync(string username)
        {
            var user = await _dbContext.Users.AnyAsync(u => u.UserName == username);
            return user;
        }

        // Check for if user is roleid 1 (admin)
        public async Task<bool> CheckAdminAsync(int userId)
        {
            var user = await _dbContext.Users.AnyAsync(u => u.Id == userId && u.RoleId == 1);
            return user;
        }

        // Get user by username and password
        public async Task<User?> GetUserAsync(string username, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
