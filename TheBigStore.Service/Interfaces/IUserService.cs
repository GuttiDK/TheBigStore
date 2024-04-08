using TheBigStore.Repository.Models;

namespace TheBigStore.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDto>
    {
        /// <summary>
        /// Checks for if the inputted username and password are correct
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if its correct else returns false</returns>
        Task<bool> CheckUserAsync(string username, string password);

        /// <summary>
        /// Checks for if the user is an admin
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns true if its correct else returns false</returns>
        Task<bool> CheckAdminAsync(int userId);
    }
}
