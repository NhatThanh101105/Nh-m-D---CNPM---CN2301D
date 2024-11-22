
using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IPlayerPondService _playerPondService;
        public InventoryController(IInventoryService inventoryService,IPlayerPondService playerPondService)
        {
            _inventoryService = inventoryService;
            _playerPondService = playerPondService;
        }

        public IActionResult Inventory()
        {
            //kiemr tra session nguoi choiw con tonf taij k
            var username=HttpContext.Session.GetString("username");
            var idplayer=HttpContext.Session.GetInt32("playerId");


            if (idplayer.HasValue && !string.IsNullOrEmpty(username))
            {
                var inventoryItems = _inventoryService.getItemByNameType(idplayer.Value, "ho")
                    .Select(i => new InventoryViewModel
                    {
                        itemId = i.ItemId,
                        nameType = "ho"
                    }).ToList() ;
                return View("~/Views/Game/Inventory.cshtml",inventoryItems);
            }
            return RedirectToAction("Login","Account");
            
        }
        public IActionResult SelectPond(int pondId)
        {
            var username = HttpContext.Session.GetString("username");
            var idplayer = HttpContext.Session.GetInt32("playerId");

            if (idplayer.HasValue && !string.IsNullOrEmpty(username))
            {
                var playerPondId= _playerPondService.getPlayerPondId(idplayer.Value,pondId);
                Console.WriteLine(playerPondId);
                if (playerPondId !=null)
                {
                    HttpContext.Session.SetInt32("playerPondId", playerPondId);
                    HttpContext.Session.SetInt32("pondId", pondId);
                    return RedirectToAction("KoiGame", "Game");
                }
            }
  //          Console.WriteLine($"Username: {username}, PlayerId: {idplayer}");

            return RedirectToAction("Login", "Account");
        }

    }
}
