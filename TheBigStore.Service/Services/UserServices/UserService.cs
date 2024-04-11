using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.UserRepositories;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.UserServices
{
    public class UserService(MappingService mappingService, IUserRepository userRepository) : GenericService<UserDto, IUserRepository, User>(mappingService, userRepository), IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly MappingService _mappingService = mappingService;

        public async Task<bool> CheckUserAsync(string username)
        {
            return await _userRepository.CheckUserAsync(username);
        }

        public async Task<bool> CheckAdminAsync(int userId)
        {
            return await _userRepository.CheckAdminAsync(userId);
        }

        // Get user by username and password
        public async Task<UserDto?> GetUserAsync(string username, string password)
        {
            return _mappingService._mapper.Map<UserDto?>(await _userRepository.GetUserAsync(username, password));
        }
    }
}
