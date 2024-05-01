using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Extensions;
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


        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            PageOptions options = new()
            {
                CurrentPage = page,
                PageSize = count
            };
            var users = await _userService.GetPagnatedList(options);

            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAllAsync();
        }
    }
}
