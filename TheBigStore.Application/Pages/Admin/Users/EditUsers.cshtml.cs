using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Users
{
    public class EditUsersModel : PageModel
    {

        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        [BindProperty]
        public new UserDto User { get; set; }
        [BindProperty]
        public RoleDto Role { get; set; }
        [BindProperty]
        public ObservableCollection<RoleDto> Roles { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public string Usernamemessage = string.Empty;
        public string Passwordmessage = string.Empty;
        public string Rolemessage = string.Empty;

        public EditUsersModel(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService=userService;
        }

        public async Task OnGetAsync(int id)
        {
            User = await _userService.GetById(id);
            if (User.RoleId != null)
                Role = await _roleService.GetById((int)User.RoleId);

            Roles = await _roleService.GetAllAsync();

            var test = Roles.SingleOrDefault(x => x.Id == User.RoleId);
            if (User.RoleId != null && test != null)
            {
                Roles.Remove(test);
            }
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
                    return RedirectToPage($@"/Admin/Users/Users");
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
