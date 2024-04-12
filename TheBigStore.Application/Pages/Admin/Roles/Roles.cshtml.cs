using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Roles
{
    public class RolesModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RolesModel(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService=userService;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string RoleName { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }

        [BindProperty]
        public ObservableCollection<RoleDto>? Roles { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Roles = await _roleService.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostCreateRole()
        {
            if (ModelState.IsValid)
            {
                if (RoleName != null)
                {
                    RoleDto roleDto = new()
                    {
                        RoleName = RoleName,
                        IsAdmin = IsAdmin
                    };

                    await _roleService.CreateAsync(roleDto);
                }
            }

            return RedirectToPage("/Roles/Roles");
        }

        public async Task<IActionResult> OnPostDeleteRole(int id)
        {

            var role = await _roleService.GetById(id);
            if (role != null)
            {
                var users = await _userService.GetAllAsync();
                foreach (var user in users)
                {
                    if (user.RoleId == role.Id)
                    {
                        user.RoleId = null;
                        await _userService.UpdateAsync(user);
                    }
                }
                await _roleService.DeleteAsync(role);
            }
            return RedirectToPage("/Roles/Roles");
        }
    }
}
