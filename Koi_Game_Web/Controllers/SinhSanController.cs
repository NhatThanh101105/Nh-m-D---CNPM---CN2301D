using Koi_Game_Services.Class.cakoi;
using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class SinhSanController : Controller
    {

        private ISinhsanService _sinhsanService;
        private IHienThiCaService _hienThiCaService;
        public SinhSanController(ISinhsanService sinhsanService, IHienThiCaService hienThiCaService)
        {
            _sinhsanService = sinhsanService;
            _hienThiCaService = hienThiCaService;
        }

        [HttpGet]
        public IActionResult BreedKoi()
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            var playerPondId = HttpContext.Session.GetInt32("playerPondId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Lấy danh sách cá không có trong hồ để sinh sản
            var koiInPond = _hienThiCaService.GetKoiInPond(idplayer.Value, playerPondId.Value);

            var koiList= _hienThiCaService.getAllKoiPlayer(idplayer.Value);


            var koiNotInPond = koiList.Where(k=>!koiInPond.Any(kip=>kip.PlayerKoiId==k.PlayerKoiId) && !k.IsOnTrade).ToList();

            var koiNotInPondViewModel = koiNotInPond.Select(k => new KoiViewModel
            {
                playerKoiId = k.PlayerKoiId,
                koiId = k.Koi.KoiId,
                color = k.Koi.Color,
                ImageURL = k.Koi.ImageURL,
                name = k.Koi.KoiName
            }).ToList();

            var model = new PondDetailViewModel
            {
                koiNotInPond = koiNotInPondViewModel
            };

            return View("~/Views/Game/BreedView.cshtml",model);
        }

        [HttpPost]
        public async Task<IActionResult> SinhSan(int[] selectedKoiIds)
        {
            if (selectedKoiIds.Length != 2)
            {
                TempData["ErrorMessage"] = "Vui lòng chọn đúng 2 con cá để sinh sản.";
                return RedirectToAction("BreedKoi");
            }

            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Thực hiện sinh sản
            bool breed = await _sinhsanService.SinhSan(selectedKoiIds[0], selectedKoiIds[1], idplayer.Value);

            if (breed)
            {
                TempData["Message"] = "Cá đã được sinh sản thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Sinh sản thất bại. Vui lòng thử lại.";
            }
            return RedirectToAction("BreedKoi");
        }
    }
}
