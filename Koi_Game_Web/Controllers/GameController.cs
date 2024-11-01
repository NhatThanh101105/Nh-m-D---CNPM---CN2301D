using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IPlayerService _playerService;
        public GameController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IActionResult> KoiGame()
        {
            var playerId = HttpContext.Session.GetInt32("playerId");
            var userName = HttpContext.Session.GetString("userName");
            string name= HttpContext.Session.GetString("name");
            if (playerId.HasValue && !string.IsNullOrEmpty(userName))
            {
                int coins= await _playerService.GetCoinPlayer(playerId.Value);
                // Truyền thông tin người dùng vào View
                var player = new PlayerViewModel
                {
                    id = playerId.Value,
                    username = userName,
                    coin = coins,
                    name=name
                };
                return View("~/Views/Game/Index.cshtml", player);
            }
            else
            {
                // Nếu chưa đăng nhập, có thể chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
