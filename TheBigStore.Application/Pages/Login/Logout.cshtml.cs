using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheBigStore.Application.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                HttpContext.Session.SetInt32("lastid", (int)HttpContext.Session.GetInt32("id"));
                HttpContext.Session.Remove("id");
            }
            if (HttpContext.Session.GetInt32("role") != null)
            {
                HttpContext.Session.Remove("role");
            }
        }
    }
}
