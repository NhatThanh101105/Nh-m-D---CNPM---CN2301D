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
            
                // Ki?m tra xem ng??i dùng ?ã ??ng nh?p ch?a
                var playerId = HttpContext.Session.GetInt32("playerId");
                var userName = HttpContext.Session.GetString("userName");

                if (playerId.HasValue && !string.IsNullOrEmpty(userName))
                {
                    // Truy?n thông tin ng??i dùng vào View
                    ViewBag.PlayerId = playerId.Value;
                    ViewBag.UserName = userName;
                }
                else
                {
                    // N?u ch?a ??ng nh?p, có th? chuy?n h??ng ??n trang ??ng nh?p
                    return RedirectToAction("Login", "Account");
                }

                return View(); // Tr? v? View Index
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
