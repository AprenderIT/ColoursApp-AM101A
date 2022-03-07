using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

namespace ColoursWeb.Pages
{
    public class AccountModel : PageModel
    {
        public string AccessToken { get; set; }
        public async Task OnGet()
        {
            AccessToken = await HttpContext.GetTokenAsync("access_token");
        }
    }
}
