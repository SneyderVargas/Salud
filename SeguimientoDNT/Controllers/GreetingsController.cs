using Microsoft.AspNetCore.Mvc;

namespace SeguimientoDNT.Api.Controllers
{
    public class GreetingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
