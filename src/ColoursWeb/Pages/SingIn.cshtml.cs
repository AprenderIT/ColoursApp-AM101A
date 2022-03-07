using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ColoursWeb.Pages
{
    public class SingInModel : PageModel
    {

        public IActionResult OnGet()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/"
            });
        }
    }
}
