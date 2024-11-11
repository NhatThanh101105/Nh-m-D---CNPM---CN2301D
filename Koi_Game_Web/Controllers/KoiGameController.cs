using Microsoft.AspNetCore.Mvc;

namespace KoiBreedingGame.Controllers
{
    public class KoiGameController : Controller
    {
        // GET: KoiGame/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
