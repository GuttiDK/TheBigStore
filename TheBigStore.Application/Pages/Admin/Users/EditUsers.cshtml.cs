using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.UserServices;

namespace TheBigStore.Application.Pages.Admin.Users
{
    public class EditUsersModel : PageModel
    {

        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public UserDto User { get; set; }
        [BindProperty]
        public ObservableCollection<RoleDto> Roles { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public string Usernamemessage;
        public string Passwordmessage;
        public string Rolemessage;

        public EditUsersModel(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService=userService;
        }

        public async Task OnGetAsync(int id)
        {
            User = await _userService.GetById(id);
           
            Roles = await _roleService.GetAllAsync();
            if (User.RoleId != 0)
            {
                User.Role = await _roleService.GetById(User.RoleId);
                foreach(var role in Roles)
                {
                    if(role.Id==User.RoleId)
                    {
                        Roles.Remove(role);
                    }
                }
            }

            // If the user already has a role
        }

        public async Task<IActionResult> OnPostUpdateUser()
        {
            if (ModelState.IsValid)
            {
                UserDto userDto = await _userService.GetById(User.Id);
                if (userDto != null)
                {
                    userDto.Id = User.Id;
                    userDto.UserName = User.UserName;
                    userDto.Password = User.Password;
                    userDto.Email = User.Email;
                    userDto.RoleId = User.RoleId;
                    await _userService.UpdateAsync(userDto);
                    SuccessMessage = "User updated successfully";
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
