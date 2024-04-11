using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages.Login
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
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
                    if (founduser.Id != null)
                    {
                        HttpContext.Session.SetSessionString(founduser.Id.ToString(), "id");
                        if (founduser.RoleId == 1)
                        {
                            HttpContext.Session.SetSessionString(founduser.RoleId.ToString(), "role");
                            return RedirectToPage("/Index");
                        }
                        else if (founduser.RoleId == 2)
                        {
                            HttpContext.Session.SetSessionString(founduser.RoleId.ToString(), "role");
                            return RedirectToPage("/Index");
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
