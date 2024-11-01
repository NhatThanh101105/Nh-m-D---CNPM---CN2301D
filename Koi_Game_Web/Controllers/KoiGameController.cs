using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class KoiGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
