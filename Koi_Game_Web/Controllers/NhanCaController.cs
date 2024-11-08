using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class NhanCaController : Controller
    {
        private readonly IXuLiNhanCaLanDau _xuLiNhanCaLanDau;
        public NhanCaController(IXuLiNhanCaLanDau xuLiNhanCaLanDau)
        {
            _xuLiNhanCaLanDau = xuLiNhanCaLanDau;
        }

        [HttpPost]
        public IActionResult NhanCa(string idKois)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            var username = HttpContext.Session.GetString("username");
            if (idplayer.HasValue && !string.IsNullOrEmpty(username))
            {
                List<int> koiIds = idKois.Split(',').Select(int.Parse).ToList();
                _xuLiNhanCaLanDau.NhanCa(idplayer.Value,koiIds);
                return RedirectToAction("KoiGame","Game");
            }
            return RedirectToAction("Login","Account");
        }
    }
}
