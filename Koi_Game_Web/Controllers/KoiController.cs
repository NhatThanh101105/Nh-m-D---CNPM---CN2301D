using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class KoiController : Controller
    {
        private readonly IKoiService _koiService;
        public KoiController (IKoiService koiService)
        {
            _koiService = koiService;
        }
        public async Task<IActionResult> Koi()
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var koiingame = await _koiService.GetAllKoiFishes();
            var koiingameViewModel = koiingame.Select(k => new KoiViewModel
            {
                
                ImageURL=k.ImageURL,
                name=k.KoiName,
                rare=k.Rare,
                price=k.Price,
                color=k.Color
                
            }).ToList();
            Console.WriteLine(koiingameViewModel.Count.ToString());
            return View("~/Views/Game/KoiInGame.cshtml",koiingameViewModel);
        }
    }
}
