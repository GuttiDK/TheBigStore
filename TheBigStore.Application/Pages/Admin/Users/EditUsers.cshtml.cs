using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Users
{
    public class EditUsersModel : PageModel
    {

        private readonly IRoleService _roleService;

        [BindProperty]
        public RoleDto Role { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public EditUsersModel(IRoleService roleService)
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

       

            if (ModelState.IsValid)
            {
                RoleDto roleDto = await _roleService.GetById(Role.Id);
                if (roleDto != null)
                {
                    roleDto.Id = Role.Id;
                    roleDto.RoleName = Role.RoleName;
                    await _roleService.UpdateAsync(roleDto);
                    SuccessMessage = "Role updated successfully";
                }
                else
                {
                    ErrorMessage = "Role not found";
                }
            }

            return Page();

        }

    }
}
