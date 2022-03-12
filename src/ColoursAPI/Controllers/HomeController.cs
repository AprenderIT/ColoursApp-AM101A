using Microsoft.AspNetCore.Mvc;

namespace ColoursAPI.Controllers;

[Route("{controller=Home}/{action=Index}")]
public class HomeController : Controller
{

    [HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Index()
        => Redirect("swagger");

}