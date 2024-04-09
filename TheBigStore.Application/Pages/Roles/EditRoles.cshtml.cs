using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Roles
{
    public class EditRolesModel : PageModel
    {

        private readonly IRoleService _roleService;

        [BindProperty]
        public RoleDto Role { get; set; }

        public EditRolesModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task OnGetAsync(int id)
        {
            RoleDto roleDto = await _roleService.GetById(id);

            if (roleDto != null)
            {
                Role = new()
                {
                    Id = roleDto.Id,
                    RoleName = roleDto.RoleName
                };

            }
        }

        public async Task<IActionResult> OnPostUpdateRole()
        {

            RoleDto roleDto = await _roleService.GetById(Role.Id);

            if (ModelState.IsValid)
            {
                if (roleDto != null)
                {
                    roleDto.Id = Role.Id;
                    roleDto.RoleName = Role.RoleName;
                    await _roleService.UpdateAsync(roleDto);
                }
            }

            return Page();

        }

    }
}
