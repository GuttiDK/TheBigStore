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


        [HttpGet(Name = "GetRole")]
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
        public async Task<IActionResult> Create(RoleDto Role)
        {
            try
            {
                Role = await _roleService.CreateAsync(Role);
                return CreatedAtAction("GetRole", new { RoleId = Role.Id }, Role);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> Remove(int RoleId)
        {
            var Role = await _roleService.GetByIdAsync(RoleId);

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
        public async Task<IActionResult> Edit(RoleDto Role)
        {
            try
            {
                await _roleService.UpdateAsync(Role);
                return CreatedAtAction("GetRole", new { RoleId = Role.Id }, Role);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int RoleId, [FromBody] JsonPatchDocument<RoleDto> patchDocument)
        {
            var Role = await _roleService.GetByIdAsync(RoleId);
            if (Role == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Role);
                await _roleService.UpdateAsync(Role);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetRole", new { RoleId = Role.Id }, Role);
        }
    }
}
