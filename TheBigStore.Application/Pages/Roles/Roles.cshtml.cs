using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Application.Pages.Roles
{
    public class RolesModel : PageModel
    {
        private readonly IRoleService _roleService;

        public RolesModel(IRoleService roleService)
        {
            _roleService=roleService;
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

            return RedirectToPage("/ToDoList/UnCompletedToDoList");
        }
    }
}
