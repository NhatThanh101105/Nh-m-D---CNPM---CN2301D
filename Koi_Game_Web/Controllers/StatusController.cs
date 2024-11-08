using Koi_Game_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class StatusController : Controller
    {
        private readonly IGameStatusService _gameStatusService;
        public StatusController(IGameStatusService gameStatusService)
        {
            _gameStatusService = gameStatusService;
        }
        public IActionResult Status()
        {

            var idplayer = HttpContext.Session.GetInt32("playerId");
            if (!idplayer.HasValue) { return RedirectToAction("Login", "Account"); }
            // lays trangj thais ddax choiw game truocw ddos
            var pondId = _gameStatusService.getPondId(idplayer.Value);
            var playerPondId = _gameStatusService.getPlayerPondId(idplayer.Value);

            // ganw cacs sesssion 
            HttpContext.Session.SetInt32("pondId",pondId);
            HttpContext.Session.SetInt32("playerPondId",playerPondId);


            return RedirectToAction("KoiGame", "Game");
                
        }
    }
}
