using Koi_Game_Reposities.Entities;
using Koi_Game_Services.Class.nhanca_newplayer;
using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class StatusController : Controller
    {
        private readonly IGameStatusService _gameStatusService;
        private readonly IXuLiNhanCaLanDau _xuLiNhanCaLanDau;    
        public StatusController(IGameStatusService gameStatusService, IXuLiNhanCaLanDau xuLiNhanCaLanDau)
        {
            _gameStatusService = gameStatusService;
            _xuLiNhanCaLanDau = xuLiNhanCaLanDau;
        }
        public async Task<IActionResult> Status()
        {

            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue) { return RedirectToAction("Login", "Account"); }
            bool check = await _xuLiNhanCaLanDau.kiemtraNewPlayer(idplayer.Value);
            if (check)
            {
                return View("~/Views/Game/SelectKoi.cshtml");
            }
            // lays trangj thais ddax choiw game truocw ddos
            var playerStatus = _gameStatusService.getPlayerStatus(idplayer.Value);

            if (playerStatus == null) 
            {
                return RedirectToAction("Inventory", "Inventory");
            }
            // ganw cacs sesssion 
            HttpContext.Session.SetInt32("pondId",playerStatus.PondId);
            HttpContext.Session.SetInt32("playerPondId",playerStatus.PlayerPondId);
            return RedirectToAction("KoiGame", "Game");
                
        }
    }
}
