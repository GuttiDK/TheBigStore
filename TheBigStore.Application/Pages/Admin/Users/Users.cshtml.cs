using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Admin.Users
{
    public class UsersModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UsersModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService=roleService;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public int RoleId { get; set; }

        public string Usernamemessage = string.Empty;
        public string Passwordmessage = string.Empty;
        public string Rolemessage = string.Empty;


        [BindProperty]
        public ObservableCollection<UserDto>? Users { get; set; }
        public ObservableCollection<RoleDto>? Roles { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Users = await _userService.GetAllAsync();
            Roles = await _roleService.GetAllAsync();
            foreach (var user in Users)
            {
                if (user.RoleId != null)
                {
                    user.Role = await _roleService.GetById((int)user.RoleId);
                }
                if (user.Role == null)
                {
                    user.Role = new RoleDto();
                }
            }

            return Page();
        }




        public async Task<IActionResult> OnPostCreateAccount(string username, string email, string password, string confirmpassword, int? roleid)
        {
            bool founduser = await _userService.CheckUserAsync(username);
            if (founduser != false)
            {
                Usernamemessage = "Username already exists";
            }
            else if (password != confirmpassword)
            {
                Usernamemessage = "Passwords do not match";
            }
            else
            {
                UserDto user = new()
                {
                    UserName = username,
                    Password = password,
                    Email = email,
                    RoleId = roleid,
                };
                await _userService.CreateAsync(user);
                return RedirectToPage("/Admin/Users/Users");
            }

            return RedirectToPage("/Admin/Users/Users");
        }

        public async Task<IActionResult> OnPostDeleteRole(int id)
        {

            var user = await _userService.GetById(id);
            if (user != null)
            {
                if (user.CustomerId != null)
                {
                }
                await _userService.DeleteAsync(user);
            }
            return RedirectToPage("/Admin/Users/Users");
        }
    }
}
