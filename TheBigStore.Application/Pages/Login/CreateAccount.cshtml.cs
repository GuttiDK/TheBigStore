using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Models;
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

        string Successmessage = string.Empty;
        string Errormessage = string.Empty;
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
                bool founduser = await _userService.CheckUserAsync(username, password);
                if (founduser != false)
                {
                    Errormessage = "Username already exists";
                }
                else if (password != confirmpassword)
                {
                    Errormessage = "Passwords do not match";
                }
                else
                {
                    UserDto user = new()
                    {
                        UserName = username,
                        Password = password,
                        Email = email,
                        RoleId = 1,
                    };
                    await _userService.CreateAsync(user);
                    Successmessage = "Account created successfully";
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }

    }
}
