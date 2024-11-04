using Koi_Game_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koi_Game_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("username");
            var idplayer = HttpContext.Session.GetInt32("playerId");
            if(!string.IsNullOrEmpty(username)&& idplayer.HasValue)
            {
               ViewBag.UserName = username;
               ViewBag.Idplayer = idplayer.Value;
            }
            else return RedirectToAction("Login", "Account");
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
