using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages
{
    public class CreateAccountModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public CreateAccountModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public string Usernamemessage = string.Empty;
        public string Passwordmessage = string.Empty;
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public string ConfirmPassword { get; set; } = string.Empty;
        [BindProperty]
        public string Email { get; set; } = string.Empty;


        // This method is used to create a new user account with roleid 2 (customer) and checks if the user already exists and if the password and confirm password match
        public async Task<IActionResult> OnPostCreateAccount(string username, string email, string password, string confirmpassword)
        {
            if (ModelState.IsValid)
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
                        RoleId = 2,
                    };
                    await _userService.CreateAsync(user);
                    return RedirectToPage("/Login/Login");
                }
            }
            return Page();
        }

    }
}
