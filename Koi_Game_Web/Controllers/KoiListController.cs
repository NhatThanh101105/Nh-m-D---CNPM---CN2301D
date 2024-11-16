using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class KoiListController : Controller
    {
        private readonly IHienThiCaService _hienThiCaService;
        public KoiListController(IHienThiCaService hienThiCaService)
        {
            _hienThiCaService = hienThiCaService;
        }

        public IActionResult KoiList()
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");   
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            var koilist = _hienThiCaService.getAllKoiPlayer(idplayer.Value);
            var koiList_1=koilist.Where(k=>!k.IsOnTrade).ToList();
            var koilistViewModel= koiList_1.Select(k=>new KoiViewModel
            {
                playerKoiId=k.PlayerKoiId,
                name=k.Koi.KoiName,
                ImageURL=k.Koi.ImageURL,
                rare=k.Koi.Rare,
                price=k.Koi.Price
            }).ToList();

            return View("~/Views/Game/KoiListView.cshtml",koilistViewModel);
        }
    }
}
