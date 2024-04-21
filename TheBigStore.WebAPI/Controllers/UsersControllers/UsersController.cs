using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        #region
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        #endregion

        #region Constructor
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        #endregion



        [HttpGet]
        [Route("GetDeffered")]
        public async IAsyncEnumerable<UserDto> GetAsync()
        {
            foreach (var user in await _userService.GetAllAsync())
            {
                yield return user;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAllAsync();
        }
    }
}
