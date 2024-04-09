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

        /// <summary>
        /// Gets a user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Returns a user if its found else returns null</returns>
        Task<UserDto?> GetUserAsync(string username, string password);
    }
}
