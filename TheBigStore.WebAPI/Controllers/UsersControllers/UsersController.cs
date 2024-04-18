using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a list of all Users.
        /// </summary>
        /// <returns>Users list</returns>
        [HttpGet]
        public async Task<ObservableCollection<UserDto>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }
    }
}
