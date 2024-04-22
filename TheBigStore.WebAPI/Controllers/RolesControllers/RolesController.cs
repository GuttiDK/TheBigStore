using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.UserServices;

namespace TheBigStore.WebAPI.Controllers.RolesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        #region
        private readonly IRoleService _roleService;
        private readonly ILogger<RolesController> _logger;
        #endregion

        #region Constructor
        public RolesController(IRoleService roleService, ILogger<RolesController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        #endregion

        // Get GetPagnatedList of users with int for page and int count for page size
        [HttpGet]
        [Route("getpagnatedlist")]
        public async Task<IActionResult> GetPagnatedList(int page, int count)
        {
            var temp = await _roleService.GetPagnatedList(page, count);

            if (temp != null)
            {
                return Ok(temp);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<RoleDto>> Get()
        {
            return await _roleService.GetAllAsync();
        }
    }
}
