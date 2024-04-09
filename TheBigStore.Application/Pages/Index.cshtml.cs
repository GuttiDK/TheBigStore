using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Application.SessionHelper;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;

namespace TheBigStore.Application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        public IndexModel(IUserService userService)
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
                    HttpContext.Session.SetSessionString(founduser.UserName, "username");
                    if (founduser.RoleId == 1)
                    {
                        HttpContext.Session.SetSessionString(founduser.RoleId.ToString(), "isadmin");
                    }

                    return RedirectToPage("/TeacherSite");
                }

            }
            return RedirectToPagePermanent("Index", new { status = "ErrUser" });
        }

        public IActionResult OnPostLogOut()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

    }
}
