﻿using TheBigStore.Repository.Interfaces.GenericInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Interfaces.UserInterfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Checks for if the inputted username are correct or is used
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns true if its correct else returns false</returns>
        Task<bool> CheckUserAsync(string username);

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
        Task<User?> GetUserAsync(string username, string password);
    }
}
