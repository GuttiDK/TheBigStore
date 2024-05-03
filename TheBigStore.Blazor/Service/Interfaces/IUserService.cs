using TheBigStore.Blazor.Models;

namespace TheBigStore.Blazor.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> CreateUser(User user);
    }
}
