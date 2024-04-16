using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Login
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public LoginModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService=roleService;
        }

        readonly string Successmessage = string.Empty;
        string Errormessage = string.Empty;
        public string? Status { get; set; }
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public int Userid { get; set; }
        public bool IsAdmin { get; } = true;
        public async Task<IActionResult> OnPostLogin(string username, string password)
        {
            if (ModelState.IsValid)
            {
                UserDto? founduser = await _userService.GetUserAsync(username, password);
                if (founduser == null)
                {
                    Errormessage = "Username or Password was incorrect";
                }
                else if (UserName == founduser.UserName && Password == founduser.Password)
                {
                    if (founduser.Id != 0)
                    {
                        HttpContext.Session.SetInt32("id", founduser.Id);
                        if (founduser.RoleId != null)
                        {

                            RoleDto role = await _roleService.GetById((int)founduser.RoleId);
                            if (role == null)
                            {
                                HttpContext.Session.SetInt32("role", 2);
                                return RedirectToPage("/Index");
                            }
                            if (role.IsAdmin == true)
                            {
                                HttpContext.Session.SetInt32("role", 1);

                                return RedirectToPage("/Admin/Admin");
                            }
                            else if (role.IsAdmin == false)
                            {
                                HttpContext.Session.SetInt32("role", 2);
                                return RedirectToPage("/Index");
                            }
                        }
                    }
                    return RedirectToPage("/Index");
                }

            }
            return RedirectToPagePermanent("Index", new { status = "ErrUser" });
        }

        public IActionResult OnPostLogOut()
        {
            HttpContext.Session.Remove("id");
            return Page();
        }

    }
}
