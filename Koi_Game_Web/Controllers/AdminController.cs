using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Admin()
        {
            var idplayer = HttpContext.Session.GetInt32("playerId");
            
            if (!idplayer.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            var player= _adminService.getAllPlayer( idplayer.Value);
           var playerViewModel=player.Select(p=>new PlayerViewModel
           {
               id=p.PlayerId,
               name=p.Name,
               username=p.UserName,
               coin=p.Coin,
               countKoi=p.PlayerKois.Count()
           }).ToList();

            var model = new AdminViewModel
            {
                player = playerViewModel,
            };
           return View("~/Views/Game/Admin.cshtml",model);
        }
        [HttpPost]
        public IActionResult Admin_Del(int idplayer)
        {
            bool del= _adminService.DelPlayer(idplayer);
            if (del)
            {
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Admin", "Admin");
            }

            return RedirectToAction("Admin", "Admin");
        }
    }
}
