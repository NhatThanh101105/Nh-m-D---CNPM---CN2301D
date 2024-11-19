using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;

namespace Koi_Game_Web.Controllers
{
    public class PondController : Controller
    {
        private readonly IPondKoiService _pondKoiService;
        private readonly IPlayerPondService _playerPondService;
        private readonly IHienThiCaService _hienThiCaService;
        public PondController(IPondKoiService pondKoiService, IPlayerPondService playerPondService,IHienThiCaService hienThiCaService)
        {
            _pondKoiService = pondKoiService;
            _playerPondService = playerPondService;
            _hienThiCaService= hienThiCaService;
        }

        public IActionResult ViewPond(int pondId)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            var playerPondId = HttpContext.Session.GetInt32("playerPondId");
            if (!idplayer.HasValue) { return RedirectToAction("Login", "Account"); }

            //int playerPondId = _playerPondService.getPlayerPondId(idplayer.Value, pondId);

            var koiInPond= _hienThiCaService.GetKoiInPond(idplayer.Value,playerPondId.Value);// lay cac con ca trong ho
            var koiInPond_1= koiInPond.Where(k=>!k.IsOnTrade).ToList();// cho ẩn nếu cá đó lỡ bán trên ttcn

            var allKoi= _hienThiCaService.getAllKoiPlayer(idplayer.Value);// lay tat car cas cuar nguoiwf cvhoiw


            var koiNotInPond = allKoi.Where(k => !koiInPond.Any(kinPond => kinPond.PlayerKoiId == k.PlayerKoiId)&& !k.IsOnTrade).ToList();
            // lovj ra cacs con ca k cos trong hoof vaf treen ttcn =)))


            var koiInPondViewModel=koiInPond_1.Select(pk=>new KoiViewModel
            {
                playerKoiId=pk.PlayerKoiId,
                koiId=pk.Koi.KoiId,
                color=pk.Koi.Color,
                ImageURL=pk.Koi.ImageURL,
                name=pk.Koi.KoiName
            }).ToList();
            var koiNotInPondViewModel = koiNotInPond.Select(k => new KoiViewModel
            {
                playerKoiId=k.PlayerKoiId,
                koiId = k.Koi.KoiId,
                color = k.Koi.Color,
                ImageURL = k.Koi.ImageURL,
                name = k.Koi.KoiName
            }).ToList();

            var model = new PondDetailViewModel
            {
                playerPondId = playerPondId.Value,
                pondId = pondId,
                koilist = koiInPondViewModel,
                koiNotInPond = koiNotInPondViewModel
            };
            return View("~/Views/Game/ViewPond.cshtml",model);
        }

        [HttpPost]
        public async Task<IActionResult> addKoiToPond(int playerPondId, int playerKoiId)
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue) return RedirectToAction("Login","Account");
            Console.WriteLine( playerPondId);
            Console.WriteLine(playerKoiId);
            
            var add= await  _pondKoiService.addKoiToPond(playerKoiId, playerPondId, idplayer.Value);
            if (add)
            {
                Console.WriteLine("da check");
                TempData["Success"] = "Thêm cá thành công";
                return RedirectToAction("KoiGame","Game");
            }
            Console.WriteLine("that bai");
            TempData["Fail"] = "Hồ đã đầy";
            return RedirectToAction("KoiGame", "Game");
        }

        [HttpPost]
        public async Task<IActionResult> removeKoiFromPond(int playerPondId, int playerKoiId)
        {
            var idplayer =  HttpContext.Session.GetInt32("playerId");
            if(!idplayer.HasValue) { return RedirectToAction("Login","Account"); }
            var remove =await _pondKoiService.removeKoiFromPond(playerKoiId,playerPondId,idplayer.Value);
            if (remove)
            {
                return RedirectToAction("KoiGame", "Game");
            }
            return View();
        }
    }
}
