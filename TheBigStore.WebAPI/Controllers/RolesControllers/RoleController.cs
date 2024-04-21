using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.WebAPI.Controllers.RolesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RoleController : ControllerBase
    {
        #region
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        #endregion

        #region Constructor
        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        #endregion


        [HttpGet("{id:int}", Name = "GetRole")]
        public async Task<IActionResult> GetRole(int RoleId)
        {
            var temp = await _roleService.GetByIdAsync(RoleId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoleDto role)
        {
            try
            {
                role = await _roleService.CreateAsync(role);
                return CreatedAtAction("GetRole", new { RoleId = role.Id }, role);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var Role = await _roleService.GetByIdAsync(id);

            if (Role == null)
                return NotFound();

            try
            {
                await _roleService.DeleteAsync(Role);
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
        public async Task<IActionResult> Edit(RoleDto role)
        {
            try
            {
                await _roleService.UpdateAsync(role);
                return CreatedAtAction("GetRole", new { RoleId = role.Id }, role);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int id, [FromBody] JsonPatchDocument<RoleDto> patchDocument)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(role);
                await _roleService.UpdateAsync(role);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetRole", new { RoleId = role.Id }, role);
        }
    }
}
