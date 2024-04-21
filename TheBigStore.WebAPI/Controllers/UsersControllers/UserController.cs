using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace TheBigStore.WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region Constructor
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        #endregion





        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetUser(int UserId)
        {
            var temp = await _userService.GetByIdAsync(UserId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(UserDto user)
        {
            try
            {
                user.Customer = new CustomerDto();
                user = await _userService.CreateAsync(user);
                return CreatedAtAction("GetUser", new { UserId = user.Id }, user);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> Remove(int UserId)
        {
            var User = await _userService.GetByIdAsync(UserId);

            if (User == null)
                return NotFound();

            try
            {
                await _userService.DeleteAsync(User);
                return NoContent(); // Success
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(UserDto user)
        {
            try
            {
                await _userService.UpdateAsync(user);
                return CreatedAtAction("GetUser", new { UserId = user.Id }, user);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int UserId, [FromBody] JsonPatchDocument<UserDto> patchDocument)
        {
            var User = await _userService.GetByIdAsync(UserId);
            if (User == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(User);
                await _userService.UpdateAsync(User);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetUser", new { UserId = User.Id }, User);
        }
    }
}
