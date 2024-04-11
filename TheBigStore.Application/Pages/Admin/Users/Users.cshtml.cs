using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Users
{
    public class UsersModel : PageModel
    {
        private readonly IRoleService _roleService;

        public UsersModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string RoleName { get; set; }

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
                await _roleService.DeleteAsync(role);
            }
            return RedirectToPage("/Roles/Roles");
        }
    }
}
