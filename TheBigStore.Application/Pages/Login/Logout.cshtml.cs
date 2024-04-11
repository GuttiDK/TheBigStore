using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheBigStore.Application.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.Session.GetString("id") != null)
            {
                HttpContext.Session.Remove("id");
            }
            if (HttpContext.Session.GetString("role") != null)
            {
                HttpContext.Session.Remove("role");
            }
        }
    }
}
