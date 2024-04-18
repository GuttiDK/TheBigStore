using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.WebAPI.Controllers.RolesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Get a list of all Roles.
        /// </summary>
        /// <returns>Roles list</returns>
        [HttpGet]
        public async Task<ObservableCollection<RoleDto>> GetRoles()
        {
            return await _roleService.GetAllAsync();
        }
    }
}
