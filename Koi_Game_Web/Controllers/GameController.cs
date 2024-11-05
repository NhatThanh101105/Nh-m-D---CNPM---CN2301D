using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Koi_Game_Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IXuLiNhanCaLanDau _xuLiNhanCaLanDau;
        private readonly IPlayerService _playerService;
        public GameController(IXuLiNhanCaLanDau xuLiNhanCaLanDau,IPlayerService playerService)
        {
            _xuLiNhanCaLanDau = xuLiNhanCaLanDau;
            _playerService = playerService;
        }
        
        public async Task<IActionResult> KoiGame()
        {
            var playerId = HttpContext.Session.GetInt32("playerId");
            var username= HttpContext.Session.GetString("username");
            var name= HttpContext.Session.GetString("name");
            if (playerId.HasValue && !string.IsNullOrEmpty(username))
            {
                int coin= await _playerService.GetCoinPlayer(playerId.Value);
                var player = new PlayerViewModel
                {
                    name = name,
                    coin = coin,
                    username = username,
                    id=playerId.Value
                };
                bool check=await _xuLiNhanCaLanDau.kiemtraNewPlayer(playerId.Value);
                if (check)
                {
                    return View("SelectKoi");
                }
            }
  
            return View("~/Views/Game/Index.cshtml");
        } 
    }
}
