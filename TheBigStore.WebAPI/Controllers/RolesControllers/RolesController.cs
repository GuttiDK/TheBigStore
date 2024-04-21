using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

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


        [HttpGet]
        public async Task<IEnumerable<RoleDto>> Get()
        {
            return await _roleService.GetAllAsync();
        }
    }
}
