using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Application.Pages.Login
{
    public class LoginModel(IUserService userService) : PageModel
    {
        private readonly IUserService _userService = userService;

        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;

        // OnPostLogin
        public async Task<IActionResult> OnPostLogin()
        {
            var user = await _userService.CheckUserAsync(Username, Password);
            if (user)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
