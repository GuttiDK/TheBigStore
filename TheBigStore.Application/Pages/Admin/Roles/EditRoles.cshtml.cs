using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Repository.Extensions;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Roles
{
    public class EditRolesModel : PageModel
    {

        private readonly IRoleService _roleService;

        [BindProperty]
        public RoleDto Role { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public EditRolesModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task OnGetAsync(int id)
        {
            RoleDto roleDto = await _roleService.GetByIdAsync(id);

            if (roleDto != null)
            {
                Role = roleDto;
            }
        }

        public async Task<IActionResult> OnPostUpdateRole()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Role.RoleName.FirstCharToUpper();
                    await _roleService.UpdateAsync(Role);
                    SuccessMessage = "Role updated successfully";
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }
            return RedirectToPage();
        }

    }
}
