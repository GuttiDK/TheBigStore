using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.WebAPI.Extensions;
using TheBigStore.WebAPI.Models;

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


        [HttpGet("{id:int}", Name = "getrole")]
        public async Task<IActionResult> GetRole(int RoleId)
        {
            var temp = await _roleService.GetByIdAsync(RoleId);

            if (temp != null)
            {
                return Ok(temp);
            }

            _logger.LogError("Role not found");
            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoleModel role)
        {
            var roleDto = role.MapRoleToDto();

            try
            {
                roleDto = await _roleService.CreateAsync(roleDto);
                return CreatedAtAction("getrole", new { Id = roleDto.Id }, roleDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var temp = await _roleService.GetByIdAsync(id);

            if (temp == null)
                return NotFound();

            try
            {
                await _roleService.DeleteAsync(temp);
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
                return CreatedAtAction("getrole", new { Id = role.Id }, role);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{id:int}")]
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

            return CreatedAtAction("getrole", new { Id = role.Id }, role);
        }
    }
}
