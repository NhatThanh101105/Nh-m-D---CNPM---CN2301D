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
        private readonly IHienThiCaService _hienThiCaService;
        public GameController(IXuLiNhanCaLanDau xuLiNhanCaLanDau,IPlayerService playerService, IHienThiCaService hienThiCaService)
        {
            _xuLiNhanCaLanDau = xuLiNhanCaLanDau;
            _playerService = playerService;
            _hienThiCaService = hienThiCaService;
        }
        
        public async Task<IActionResult> KoiGame()
        {

            // lay session dda luu tu trang ddang nhaap
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
                Console.WriteLine(coin);
                //kiem tra xem co phai nguoi choiw moiws k, neeu laf nguoi choiw mowis thi cho nhan quaf
                bool check=await _xuLiNhanCaLanDau.kiemtraNewPlayer(playerId.Value);
                if (check)
                {
                    return View("SelectKoi");
                }
                //
                var playerPondId = HttpContext.Session.GetInt32("playerPondId");
                // doanj pondid tis nauwx lamf rieeng database dder luuw
                var pondId = HttpContext.Session.GetInt32("pondId");

                // 
                if (!playerPondId.HasValue || !pondId.HasValue) { return RedirectToAction("Inventory", "Inventory"); }

                var koilist = _hienThiCaService.GetKoiInPond(playerId.Value,playerPondId.Value)
                    .Select(k=> new KoiViewModel
                    {
                        playerKoiId=k.PlayerKoiId,
                        koiId= k.Koi.KoiId,
                        color= k.Koi.Color,
                        ImageURL=k.Koi.ImageURL,
                        name=k.Koi.KoiName

                    }).ToList();
                var koi= _hienThiCaService.getAllKoiPlayer(playerId.Value)
                    .Select(k=>new KoiViewModel
                {    
                    koiId=k.Koi.KoiId,
                    color= k.Koi.Color,
                    name=k.Koi.KoiName,
                    ImageURL=k.Koi.ImageURL
                }).ToList();
                var pondDetail = new PondDetailViewModel
                {
                    playerPondId = playerPondId.Value,
                    pondId = pondId.Value,
                    koilist = koilist,

                };
                var model = new GameViewModel
                {
                    player = player,
                    PondDetail = pondDetail,
                    Koi = koi
                };
                return View("~/Views/Game/home_game.cshtml", model);
            }
            return RedirectToAction("Login", "Account");
        } 

    }
}
