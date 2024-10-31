using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult KoiGame()
        {
            return View("~/Views/Game/Index.cshtml");
        }
    }
}
