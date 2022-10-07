using Microsoft.AspNetCore.Mvc;

namespace Inleveropdracht_B2C2_WithAuthentication.Controllers
{
    public class KaartenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
