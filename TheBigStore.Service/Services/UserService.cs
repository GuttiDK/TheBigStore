using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Service.Services
{
    public class UserService(MappingService mappingService, IUserRepository userRepository) : GenericService<UserDto, IUserRepository, User>(mappingService, userRepository), IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly MappingService _mappingService = mappingService;

        public async Task<bool> CheckUserAsync(string username, string password)
        {
            return await _userRepository.CheckUserAsync(username, password);
        }

        public async Task<bool> CheckAdminAsync(int userId)
        {
            return await _userRepository.CheckAdminAsync(userId);
        }
    }
}
