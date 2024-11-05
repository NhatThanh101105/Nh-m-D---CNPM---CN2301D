using Koi_Game_Services.Interfaces;
using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koi_Game_Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Inventory()
        {
            var username=HttpContext.Session.GetString("username");
            var idplayer=HttpContext.Session.GetInt32("playerId");
            if (idplayer.HasValue && !string.IsNullOrEmpty(username))
            {
                var items= _inventoryService.getAllItems(idplayer.Value);
                var sl= _inventoryService.getSl(idplayer.Value);
                var inventoryItems=items.Select((item,index)=>new InventoryViewModel
                {
                    itemId=item.Key,
                    nameType=item.Value,
                    quantity = sl[index]
                }).ToList();
                return View(inventoryItems);
            }
            return RedirectToAction("Login","Account");
            
        }
    }
}
